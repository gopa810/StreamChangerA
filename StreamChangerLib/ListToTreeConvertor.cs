using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml;

namespace TextToTreeLib
{
    public class ListToTreeConvertor: GPOMProcess
    {
        private TreeNode mainNode = new TreeNode();
        public TreeNode CurrNode
        {
            get
            {
                return mainNode;
            }
            set
            {
                mainNode = value;
            }
        }

        public TreeNode PushNode(TreeNode tnp, string s)
        {
            TreeNode tn = tnp.Nodes.Add(s);
            tn.SelectedImageIndex = 0;
            tn.ImageIndex = 0;
            return tn;
        }

        public TreeNode PushNode(TreeNode tnp, string fmt, params object[] args)
        {
            string s = string.Format(fmt, args);
            return PushNode(tnp, s);
        }

        /// <summary>
        /// RAWSRC
        /// </summary>
        public SourceNodeCollection InputSource;

        /// <summary>
        /// Tabulka SRC (su to indexy do tabulky RAWSRC, takze ide o virtualnu tabulku, ktora je pouzita
        /// pri parsovani vstupu
        /// </summary>
        public List<int> FilteredSource = new List<int>();

        public TrackPart OutputSource;


        /// <summary>
        /// Input filter specification
        /// </summary>
        public HashSet<string> InputFilterTypesRemove = new HashSet<string>();
        public HashSet<string> InputFilterValuesRemove = new HashSet<string>();

        /// <summary>
        /// Table of SYMBOLS
        /// </summary>
        public List<SymbolDefinition> symbolsList = new List<SymbolDefinition>();
        public Dictionary<string, SymbolDefinition> symbolsMap = new Dictionary<string,SymbolDefinition>();

        /// <summary>
        /// empty list of integers, should stay empty for all operations
        /// </summary>
        public HashSet<int> emptyIntHash = new HashSet<int>();

        /// <summary>
        /// First element index
        /// </summary>
        /// 

        public Dictionary<string, HashSet<int>> failedSymbols = new Dictionary<string, HashSet<int>>();
        public Dictionary<int, Dictionary<string, TrackPart>> successSymbols = new Dictionary<int, Dictionary<string, TrackPart>>();

        /// <summary>
        /// This flag means, that if we find some node which is not defined in translation list
        /// we skip it and proceed with next node in source list.
        /// </summary>
        public string MainSymbol = "";

        /// <summary>
        /// Removes items from inputsource specified in filtering lists
        /// and produced list of indexes to InputSource, where valid items are placed
        /// </summary>
        public void FilterInput()
        {
            FilteredSource.Clear();

            for (int i = 0; i < InputSource.Count; i++)
            {
                SourceNode sn = InputSource[i];
                if (!InputFilterTypesRemove.Contains(sn.type) && !InputFilterValuesRemove.Contains(sn.value))
                {
                    FilteredSource.Add(i);
                }
            }

            for (int i = 0; i < FilteredSource.Count; i++)
            {
                Debugger.Log(0, "", "FILTERED [" + i + "] = " + InputSource[FilteredSource[i]].type + "  =>  " + InputSource[FilteredSource[i]].value + "\n");
            }
        }

        public override void Run()
        {
            OutputSource = new TrackPart();

            FilterInput();

            SymbolLineDefinitionItem si = new SymbolLineDefinitionItem();
            si.text = MainSymbol;
            si.type = SymbolType.BY_SYMBOL;
            OutputSource = TrySymbol(mainNode, si, 0);
            if (OutputSource.end < FilteredSource.Count)
                Message = "Error: file was not recognized completely, last matched index is " + OutputSource.end.ToString();

        }

        private TrackPart TrySymbol(TreeNode tnp, SymbolLineDefinitionItem si, int p)
        {
            SymbolDefinition sd;
            TrackPart part = new TrackPart();

            part.symbolType = si.type;
            part.symbolText = si.text;
            part.status = TrackStatus.FAILED;
            part.position = p;

            if (p >= FilteredSource.Count)
                return part;

            TreeNode tn;
            if (si.type == SymbolType.BY_SYMBOL)
            {
                if (successSymbols.ContainsKey(p))
                {
                    if (successSymbols[p].ContainsKey(si.text))
                    {
                        tn = PushNode(tnp, si.type + " " + si.text);
                        tn.ImageIndex = tn.SelectedImageIndex = 1;
                        TrackPart tpp = successSymbols[p][si.text];
                        part.end = tpp.end;
                        part.children = tpp.children;
                        part.status = TrackStatus.MATCHED;
                        return part;
                    }
                }
                if (failedSymbols.ContainsKey(si.text))
                {
                    if (failedSymbols[si.text].Contains(p))
                    {
                        tn = PushNode(tnp, si.type + " " + si.text);
                        tn.ImageIndex = tn.SelectedImageIndex = 2;
                        return part;
                    }
                }
            }

            tn = PushNode(tnp, "{0} {1} [pos {2}]", si.type, si.text, p);
            if (si.type == SymbolType.BY_TYPE)
            {
                SourceNode sn = InputSource[FilteredSource[p]];
                if (sn.type.Equals(si.text))
                {
                    part.status = TrackStatus.MATCHED;
                    part.end = p;
                }
            }
            else if (si.type == SymbolType.BY_VALUE)
            {
                SourceNode sn = InputSource[FilteredSource[p]];
                if (sn.value.Equals(si.text))
                {
                    part.status = TrackStatus.MATCHED;
                    part.end = p;
                }
            }
            else if (si.type == SymbolType.BY_SYMBOL && symbolsMap.ContainsKey(si.text))
            {
                sd = symbolsMap[si.text];
                foreach (SymbolLineDefinition line in sd.lines)
                {
                    if (MatchSymbolLine(p, part, tn, line))
                        break;
                }

                // we have matched line and lp with list of trackparts
                // now we should try recursive definitions, if there are any
                if (part.status == TrackStatus.MATCHED)
                {
                    part = MatchRecursiveLines(sd, part, tn);

                }
            }

            tn.Text = tn.Text + " [end " + part.end + "]";
            tn.ImageIndex = tn.SelectedImageIndex = (part.status == TrackStatus.MATCHED ? 1 : (part.status == TrackStatus.FAILED ? 2 : 0));

            if (si.type == SymbolType.BY_SYMBOL)
            {
                if (part.status == TrackStatus.FAILED)
                {
                    if (!failedSymbols.ContainsKey(si.text))
                        failedSymbols.Add(si.text, new HashSet<int>());
                    failedSymbols[si.text].Add(p);
                }
                else if (part.status == TrackStatus.MATCHED)
                {
                    if (!successSymbols.ContainsKey(p))
                        successSymbols.Add(p, new Dictionary<string, TrackPart>());
                    TrackPart tpp = new TrackPart();
                    tpp.children = part.children;
                    tpp.end = part.end;
                    successSymbols[p].Add(si.text, tpp);
                }
            }

            return part;
        }

        /// <summary>
        /// we try all recursive definitions again and again
        /// until none of recursive definitions can be satisfied
        /// </summary>
        /// <param name="sd"></param>
        /// <param name="part"></param>
        /// <param name="tn"></param>
        /// <returns></returns>
        private TrackPart MatchRecursiveLines(SymbolDefinition sd, TrackPart part, TreeNode tn)
        {
            // TrackPart prevtrack = part;
            int subStartIndex = part.end + 1;
            TrackPart newTrack = null;
            TrackPart lastNew = null;

            do
            {
                // Try all recursive definitions.
                // If given recursive definition succeeded, then encapsulating TrackPart
                // is returned. Original part is inserted at first place in children.
                // If none of definitions succeeded, then original part is returned.
                newTrack = null;
                foreach (SymbolLineDefinition line in sd.recursive)
                {
                    newTrack = MatchSymbolLineFromSecond(tn, line, subStartIndex);
                    if (newTrack != null)
                    {
                        lastNew = newTrack;
                        newTrack.symbolText = part.symbolText;
                        newTrack.symbolType = part.symbolType;
                        newTrack.position = part.position;
                        newTrack.status = TrackStatus.MATCHED;
                        newTrack.children.Insert(0, part);
                        subStartIndex = newTrack.end + 1;
                        part = newTrack;
                        break;
                    }
                }

            } while (newTrack != null);

            return part;
        }

        /// <summary>
        /// Tries tp match SymbolDefinitionLine against input source
        /// </summary>
        /// <param name="iIndex"></param>
        /// <param name="part">Parent TrackPart entity</param>
        /// <param name="trackingNode"></param>
        /// <param name="line"></param>
        private bool MatchSymbolLine(int iIndex, TrackPart part, TreeNode trackingNode, SymbolLineDefinition line)
        {
            int startIndex = iIndex;

            TrackPart tempart = null;
            SymbolLineDefinition matchedLine = line;
            List<TrackPart> lp = new List<TrackPart>();
            //ddt(+1, "LINE DEF");
            TreeNode tn2 = PushNode(trackingNode, line.ToString());

            foreach (SymbolLineDefinitionItem sdi in line)
            {
                UInt32 numberOfOccurences = 0;
                while (numberOfOccurences < sdi.max)
                {
                    tempart = TrySymbol(tn2, sdi, startIndex);
                    if (tempart.status != TrackStatus.MATCHED)
                        break;

                    lp.Add(tempart);
                    startIndex = tempart.end + 1;
                    numberOfOccurences++;
                }

                if (numberOfOccurences < sdi.min)
                {
                    if (part.end < startIndex - 1)
                    {
                        part.end = startIndex - 1;
                        part.children = lp;
                    }
                    matchedLine = null;
                    break;
                }
            }

            if (matchedLine != null)
            {
                // line was matched
                // we have to subtract 1 from startIndex, because value
                // in startIndex was prepared for next item, but now we are
                // ending with comparision, so we need not next item
                // but we need last item, which is 1 step back
                part.end = startIndex - 1;
                part.status = TrackStatus.MATCHED;
                part.children = lp;
                //ddt(-1, "--LINE DEF - SUCC");
                tn2.SelectedImageIndex = tn2.ImageIndex = 1;
                return true;
            }
            else
            {
                // line failed, go to next line
                //ddt(-1, "--LINE DEF - FAIL");
                tn2.SelectedImageIndex = tn2.ImageIndex = 2;
            }

            return false;

        }

        /// <summary>


        /// <summary>
        /// For given line definition, do throug all items (except first)
        /// and try to match
        /// If item fails, then return null, which is signal to caller method
        /// that this line was not matched
        /// </summary>
        /// <param name="line"></param>
        /// <param name="p"></param>
        /// <returns>TrackPart is returned, but only children, end 
        /// and status is used in caller function</returns>
        private TrackPart MatchSymbolLineFromSecond(TreeNode tn, SymbolLineDefinition line, int p)
        {
            TrackPart result = new TrackPart();
            result.children = new List<TrackPart>();
            TrackPart part;
            int startIndex = p;
            for (int j = 1; j < line.Count; j++ )
            {
                SymbolLineDefinitionItem sdi = line[j];
                part = TrySymbol(tn, sdi, startIndex);
                if (part.status == TrackStatus.MATCHED)
                {
                    result.children.Add(part);
                    startIndex = part.end + 1;
                }
                else
                {
                    return null;
                }
            }

            // line was matched
            result.end = startIndex - 1;
            result.status = TrackStatus.MATCHED;
            return result;
        }

        /// <summary>
        /// Reads definition of BNF analyzer. Lines starting with 
        /// 4 spaces are child lines to those
        /// that starts with letter
        /// </summary>
        /// <param name="script"></param>
        public void LoadText(string script)
        {
            SymbolDefinition symbol = null;
            string[] lines = script.Split('\r', '\n');

            foreach(string line in lines)
            {
                if (line.Length > 0)
                {
                    if (line.StartsWith("    "))
                    {
                        if (symbol != null)
                        {
                            SymbolLineDefinition sd = new SymbolLineDefinition();
                            sd.SetString(line.Substring(4));
                            symbol.InsertLine(sd);
                        }
                    }
                    else
                    {
                        symbol = new SymbolDefinition();
                        symbol.symbolText = line;

                        symbolsList.Add(symbol);
                        symbolsMap.Add(line, symbol);
                    }
                }
            }

        }

        /// <summary>
        /// Generates XML tree for output tree
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public XmlNode GetXmlNode(XmlDocument doc)
        {
            return GetXmlNode(doc, OutputSource);
        }

        /// <summary>
        /// Generates XML tree for given node
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="tp"></param>
        /// <returns></returns>
        public XmlNode GetXmlNode(XmlDocument doc, TrackPart tp)
        {
            XmlElement xe = doc.CreateElement("node");
            xe.SetAttribute("type", tp.symbolType.ToString());
            xe.SetAttribute("value", tp.symbolText);
            if (tp.end == tp.position)
                xe.SetAttribute("source", InputSource[FilteredSource[tp.position]].value);

            if (tp.children != null && tp.children.Count > 0)
            {
                foreach (TrackPart ts in tp.children)
                {
                    XmlNode xs = GetXmlNode(doc, ts);
                    xe.AppendChild(xs);
                }
            }

            return xe;
        }
    }
}
