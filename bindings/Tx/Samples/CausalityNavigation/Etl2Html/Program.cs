using System;
using System.Net;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Tx;
using System.Text;
using Microsoft.Etw;
using Microsoft.Etw.BombGame;

namespace Trace2Html
{
    class Program
    {
        const string LocalTrace = @"bombs.etl";
        const int linesPerPage = 30;
        static HttpListener listener = new HttpListener();
        static HttpListenerRequest request;
        static StringBuilder sb;
       
        static void Main(string[] args)
        {
            listener.Prefixes.Add("http://" + Environment.MachineName+ ":9000/");
            listener.Start();
            Console.WriteLine("Listening ...");

            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                request = context.Request;

                HttpListenerResponse response = context.Response;

                sb = new StringBuilder("<HTML>\n<HEAD>\n<TITLE>");
                sb.Append("Trace 2 Html");
                sb.Append("</TITLE>\n</HEAD>\n<BODY>\n");
                sb.Append("<pre style=\"font-family:Consolas; font-size: 10pt; width: 5000px;\">");

                if (!request.QueryString.HasKeys())
                {
                    AllHistory(sb, 0);
                }
                else if (request.QueryString["after"]!= null)
                {
                    var after = int.Parse(request.QueryString.Get("after"));
                    AllHistory(sb, after);
                }
                else if (request.QueryString["afterReceive"] != null)
                {
                    string messageId = request.QueryString.Get("afterReceive");
                    AfterReceive(sb, messageId);
                }
                else if (request.QueryString["beforeSend"] != null)
                {
                    string messageId = request.QueryString.Get("beforeSend");
                    BeforeSend(sb, messageId);
                }
                sb.Append("</BODY></HTML>");
                byte[] buffer = Encoding.UTF8.GetBytes(sb.ToString());
                response.ContentLength64 = buffer.Length;
                response.OutputStream.Write(buffer, 0, buffer.Length);
                response.OutputStream.Close();
            }
        }

        static void AllHistory(StringBuilder sb, int start)
        {
            if (start > 0)
            {
                sb.AppendFormat("<A HREF=?after={0}>Previous</A><BR/>", start - linesPerPage);
            }
            Playback pb = new Playback();
            pb.AddEtlFiles(LocalTrace);
            var all = pb.GetObservable<TracedEvent>();

            all.Skip(start).Take(linesPerPage).Subscribe(e => sb.AppendLine(Format(e.Message)));

            pb.Run();
            sb.AppendFormat("<BR/><A HREF=?after={0}>Next</A>", start + linesPerPage);       
        }

        static void AfterReceive(StringBuilder sb, string messageId)
        {
            Playback pb = new Playback();
            pb.AddEtlFiles(LocalTrace);
            var all = pb.GetObservable<TracedEvent>();

            string pattern = "received message " + messageId;
            var received = all.Where(e=>e.Message.Contains(pattern));
            var after = received.SelectMany(all).Take(linesPerPage);
            var output = received.Merge(after);

            output.Subscribe(e => sb.AppendLine(Format(e.Message)));

            pb.Run();
       }

        static void BeforeSend(StringBuilder sb, string messageId)
        {
            Playback pb = new Playback();
            pb.AddEtlFiles(LocalTrace);
            var all = pb.GetObservable<TracedEvent>();

            string pattern = "send message " + messageId;
            var send = all.Where(e => e.Message.Contains(pattern));
            var before = all.TakeUntil(send);
            var output = before.Merge(send);

            output.TakeLast(linesPerPage).Subscribe(e => sb.AppendLine(Format(e.Message)));

            pb.Run();
        }


        static string Format(string message)
        {
            int index = message.IndexOf("send message");
            if (index > 0)
            {
                string[] tokens = message.Split(' ', ':');
                string s = string.Format("{0} {1} {2} send message <A HREF=\"http://{7}:9000/?afterReceive={5}\">{5}</A> to {7}:{8}",
                    tokens[0],
                    tokens[1],
                    tokens[2],
                    tokens[3],
                    tokens[4],
                    tokens[5],
                    tokens[6],
                    tokens[7],
                    tokens[8]);

                return s;
            }

            index = message.IndexOf("received message");
            if (index > 0)
            {
                string[] tokens = message.Split(' ', ':');
                string s = string.Format("{0} {1} {2} received message <A HREF=\"http://{7}:9000/?beforeSend={5}\">{5}</A> to {7}:{8}",
                    tokens[0],
                    tokens[1],
                    tokens[2],
                    tokens[3],
                    tokens[4],
                    tokens[5],
                    tokens[6],
                    tokens[7],
                    tokens[8]);

                return s;
            }
           
            return message;
        }
    }
}
