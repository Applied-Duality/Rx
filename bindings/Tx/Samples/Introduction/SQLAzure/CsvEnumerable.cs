namespace SQLAzure
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;

    class TraceLine
    {
        public DateTime Timeflag { get; set; }
        public string Detail { get; set; }

        public TraceLine(string line)
        {
            Timeflag = DateTime.Parse(line.Substring(0, 20));
            Detail = line.Substring(22);
        }

        public override string ToString()
        {
            return Timeflag  + " : " + Detail;
        }
    }

    static class CsvEnumerable
    {
        public static IEnumerable<TraceLine> ReadFile(string filename)
        {
            using (TextReader reader = File.OpenText(filename))
            {
                for (; ; )
                {
                    string line = reader.ReadLine();
                    if (line == null)
                        yield break;

                    //Thread.Sleep(1);
                    yield return new TraceLine(line);
                }
            }
        }
    }
}
