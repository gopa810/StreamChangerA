using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextToTreeLib
{
    public class SourceNode
    {
        public long offset;
        public string type;
        public string value;
        public string comments;

        public SourceNodeCollection Nodes = null;

        public SourceNode()
        {
        }

        public SourceNode(string inType)
        {
            type = inType;
        }

        public SourceNode(string inType, string inValue)
        {
            type = inType;
            value = inValue;
        }

        public SourceNode(string inType, string inValue, string inComment)
        {
            type = inType;
            value = inValue;
            comments = inComment;
        }

        public void AddNode(SourceNode sn)
        {
            if (Nodes == null)
                Nodes = new SourceNodeCollection();
            Nodes.Add(sn);
        }

        public void AddSubnodes(SourceNode sn)
        {
            if (Nodes == null)
                Nodes = new SourceNodeCollection();
            Nodes.AddRange(sn.Nodes);
        }

        public void ClearNodes()
        {
            if (Nodes != null)
                Nodes.Clear();
        }
    }
}
