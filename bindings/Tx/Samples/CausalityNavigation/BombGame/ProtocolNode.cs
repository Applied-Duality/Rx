using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace BombActor
{
    static class ProtocolNode
    {
        static HttpListener _listener;
        static Timer _timer;
        static int _actorId;
        static string[] _actorUris;
        static Action<IBomb, int> _received;
        static TimerCallback _onTimer;
        static DateTime _startTime;
        static int _localCounter;

        public static void Open(Action<IBomb, int> received, TimerCallback onTimer)
        {
            _received = received;
            _onTimer = onTimer;
            int index = 0;
            List<string> actorUris = new List<string>();

            using (TextReader reader = File.OpenText("Actors.txt"))
            {
                while (true)
                {
                    string url = reader.ReadLine();
                    if (url == null)
                        break;

                    actorUris.Add(url);
                }
            }
            _actorUris = actorUris.ToArray();

            for (int i = 0; i < _actorUris.Length; i++)
            {
                if (TryListening(i))
                    Console.WriteLine("* {0} {1}", index, _actorUris[i]);
                else
                    Console.WriteLine("  {0} {1}", index, _actorUris[i]);
            };
            _listener.BeginGetContext(OnRequest, null);
        }

        public static int ActorId
        {
            get { return _actorId; }
        }

        public static string[] Actors
        {
            get { return _actorUris; }
        }

        public static int LocalCounter
        {
            get { return _localCounter++; }
        }
        
        public static void StartAll()
        {
            DateTime startTime = DateTime.Now;
            for (int i = 0; i < _actorUris.Length; i++)
            {
                var req = HttpWebRequest.Create(_actorUris[i] + "?start=" + startTime);
                req.Headers.Add("from", _actorId.ToString());
                req.Headers.Add("messageId", Guid.NewGuid().ToString());
                var resp = req.GetResponse();
            }
        }

        public static void StopAll()
        {
            _timer.Dispose();
            DateTime startTime = DateTime.Now;
            for (int i = 0; i < _actorUris.Length; i++)
            {
                if (i == _actorId)
                    continue;

                var req = HttpWebRequest.Create(_actorUris[i] + "?stop=" + startTime);
                req.Headers.Add("from", _actorId.ToString());
                req.Headers.Add("messageId", Guid.NewGuid().ToString());
                try
                {
                    var resp = req.GetResponse();
                }
                catch (WebException ex)
                {
                    Trace.WriteLine("Exception: " + ex.Message);
                }
            }
        }
        
        public static void Send(IBomb bomb, int to)
        {
            try
            {
                Uri uri = new Uri(Actors[to]);
                string messageId = Guid.NewGuid().ToString();

                Trace.WriteLine(String.Format("{0} P {1} send message {2} to {3}:{4}",
                    _actorId,
                    LocalCounter,
                    messageId,
                    uri.Host,
                    uri.Port));

                var req = HttpWebRequest.Create(_actorUris[to] + "?timebomb=" + DateTime.Now.ToString());
                req.Headers.Add("from", _actorId.ToString());
                req.Headers.Add("messageId", messageId);

                var resp = req.GetResponse();
            }                
            catch (WebException ex)
            {
                Trace.WriteLine("Exception: " + ex.Message);
            }
        }

        static void OnRequest(object state)
        {
            HttpListenerContext context = _listener.EndGetContext((IAsyncResult)state);
            HttpListenerRequest request = context.Request;

            HttpListenerResponse response = context.Response;
            string messageId = request.Headers["messageId"];
            int from = int.Parse(request.Headers["from"]);

            Uri uri = new Uri(Actors[from]);
            Trace.WriteLine(String.Format("{0} P {1} received message {2} from {3}:{4}",
                  _actorId,   
                  LocalCounter,
                  messageId,
                  uri.Host,
                  uri.Port));

            if (request.QueryString["start"] != null)
            {
                _startTime = DateTime.Parse(request.QueryString.Get("start"));
                _timer = new Timer(_onTimer, null, 1000, 1000);
            }

            if (request.QueryString["stop"] != null)
            {
                response.OutputStream.Close(); 
                Environment.Exit(0);
            } 
            
            if (request.QueryString["timebomb"] != null)
            {
                var d = DateTime.Parse(request.QueryString.Get("timebomb"));
                _received(new TimeBomb(), from);
            }
            response.OutputStream.Close();
            _listener.BeginGetContext(OnRequest, null);
        }       

        static bool TryListening(int index)
        {
            if (_listener != null)
                return false;

            if (new Uri(_actorUris[index]).Host.ToLowerInvariant() != Environment.MachineName.ToLowerInvariant())
                return false;

            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(_actorUris[index]);
            try
            {
                listener.Start();
                _listener = listener;
                _actorId = index;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
