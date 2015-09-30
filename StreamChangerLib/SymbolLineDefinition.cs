using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextToTreeLib
{

    public class SymbolLineDefinition : List<SymbolLineDefinitionItem>
    {
        public void SetString(string ss)
        {
            string[] parts = ss.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            SymbolLineDefinitionItem sdi;
            SymbolLineDefinitionItem lastItem = null;
            foreach (string pp in parts)
            {
                sdi = null;

                if (pp.Equals("+"))
                {
                    if (lastItem != null)
                    {
                        lastItem.min = 1;
                        lastItem.max = UInt32.MaxValue;
                    }
                }
                else if (pp.Equals("?"))
                {
                    if (lastItem != null)
                    {
                        lastItem.min = 0;
                        lastItem.max = 1;
                    }
                }
                else if (pp.Equals("*"))
                {
                    if (lastItem != null)
                    {
                        lastItem.min = 0;
                        lastItem.max = UInt32.MaxValue;
                    }
                }
                else if (pp.StartsWith("\'"))
                {
                    sdi = new SymbolLineDefinitionItem();
                    sdi.type = SymbolType.BY_VALUE;
                    sdi.text = pp.Substring(1);
                    this.Add(sdi);
                }
                else if (pp.StartsWith("/"))
                {
                    sdi = new SymbolLineDefinitionItem();
                    sdi.type = SymbolType.BY_TYPE;
                    sdi.text = pp.Substring(1);
                    this.Add(sdi);
                }
                else
                {
                    sdi = new SymbolLineDefinitionItem();
                    sdi.type = SymbolType.BY_SYMBOL;
                    sdi.text = pp;
                    this.Add(sdi);
                }

                lastItem = sdi;
            }
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (SymbolLineDefinitionItem sdi in this)
            {
                sb.AppendFormat("{0} ", sdi.text);
            }
            return sb.ToString();
        }
    }

    public class SymbolDefinition
    {
        public string symbolText;
        public List<SymbolLineDefinition> lines = new List<SymbolLineDefinition>();
        public List<SymbolLineDefinition> recursive = new List<SymbolLineDefinition>();

        public void InsertLine(SymbolLineDefinition sd)
        {
            List<SymbolLineDefinition> lst = this.lines;
            bool inserted = false;

            if (sd.Count > 0 && sd[0].type == SymbolType.BY_SYMBOL && sd[0].text.Equals(symbolText))
            {
                lst = this.recursive;
            }

            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i].Count < sd.Count)
                {
                    lst.Insert(i, sd);
                    inserted = true;
                    break;
                }
            }

            if (!inserted)
                lst.Add(sd);
        }

    }


    public class TrackPart
    {
        public string symbolText = string.Empty;
        public SymbolType symbolType = SymbolType.BY_SYMBOL;
        public int position = -1;
        public int end = -1;
        public TrackStatus status = TrackStatus.PENDING;
        public List<TrackPart> children = null;
    }


}
