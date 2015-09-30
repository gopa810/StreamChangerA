using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextToTreeLib
{
    public class TransNode
    {
        public string type;
        public string value;
        public int min = 1;
        public int max = 1;

        public TransNodeCollection Nodes = null;

        public TransNode()
        {
        }

        public TransNode(string inType)
        {
            type = inType;
        }

        public TransNode(string inType, string inValue)
        {
            type = inType;
            value = inValue;
        }

        public void AddNode(TransNode sn)
        {
            if (Nodes == null)
                Nodes = new TransNodeCollection();
            Nodes.Add(sn);
        }

        public void ClearNodes()
        {
            if (Nodes != null)
                Nodes.Clear();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class TransNodeCollection
    {
        private List<TransNode> Nodes = new List<TransNode>();

        private void CheckExistenceNodes()
        {
            if (Nodes == null)
                Nodes = new List<TransNode>();
        }

        public void Add(TransNode sn)
        {
            CheckExistenceNodes();
            Nodes.Add(sn);
        }

        public int Count
        {
            get
            {
                if (Nodes == null)
                    return 0;
                return Nodes.Count;
            }
        }

        public void Clear()
        {
            if (Nodes != null)
                Nodes.Clear();
        }

        public TransNode this[int idx]
        {
            get
            {
                if (Nodes == null || idx < 0 || idx >= Nodes.Count)
                {
                    return null;
                }
                return Nodes[idx];
            }
        }



    }
}
