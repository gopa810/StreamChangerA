using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;

namespace TextToTreeLib
{
    public class StreamToTable: GPOMProcess
    {
        public String InputText { get; set; }

        public String Script { get; set; }

        public SourceNodeCollection Elements { get; set; }

        public int LastPosition { get; set; }

        private class rgx
        {
            public int state = 0;
            public string name = string.Empty;
            public Regex regex = null;
            public bool printMatch = true;
            public int nextState = 0;
        }

        private List<rgx> Regexes = new List<rgx>();


        public override void Run()
        {
            StringBuilder sb = new StringBuilder();

            makeRegexes(Script);

            int start = 0;
            int state = 0;

            Elements = new SourceNodeCollection();

            Success = true;

            while (start < InputText.Length)
            {
                bool b = false;
                foreach (rgx r in Regexes)
                {
                    if (r.state == state)
                    {
                        Match m = r.regex.Match(InputText, start);
                        if (m.Success && m.Length > 0 && m.Index == start)
                        {
                            SourceNode dr = new SourceNode();
                            dr.offset = start;
                            dr.type = r.name;
                            dr.value = (r.printMatch ? InputText.Substring(start, m.Length) : "");
                            Elements.Add(dr);

                            start += m.Length;
                            b = true;
                            if (r.nextState >= 0)
                                state = r.nextState;
                            break;
                        }
                    }
                }
                if (!b)
                {
                    sb.AppendFormat("unrecognized sequence at {0} for state {1}\n", start, state);

                    LastPosition = start;

                    Success = false;
                    break;
                }
            }

            Message = sb.ToString();
        }

        private void makeRegexes(string s)
        {
            string[] lines = s.Split('\n');
            Regexes.Clear();
            foreach (string line in lines)
            {
                string[] parts = line.Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                rgx nr = new rgx();

                if (parts.Length > 0)
                {
                    int.TryParse(parts[0], out nr.state);
                    if (parts.Length > 1)
                    {
                        nr.name = parts[1];
                    }

                    if (parts.Length > 2)
                    {
                        nr.regex = new Regex(parts[2]);
                    }

                    if (parts.Length > 3)
                    {
                        bool.TryParse(parts[3], out nr.printMatch);
                    }

                    if (parts.Length > 4)
                    {
                        int.TryParse(parts[4], out nr.nextState);
                    }

                    Regexes.Add(nr);
                }
            }
        }


    }
}
