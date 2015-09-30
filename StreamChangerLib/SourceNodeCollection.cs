using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace TextToTreeLib
{
    public class SourceNodeCollection
    {
        private List<SourceNode> Nodes = new List<SourceNode>();

        private void CheckExistenceNodes()
        {
            if (Nodes == null)
                Nodes = new List<SourceNode>();
        }

        public void Add(SourceNode sn)
        {
            CheckExistenceNodes();
            Nodes.Add(sn);
        }

        public void AddRange(SourceNodeCollection sn)
        {
            CheckExistenceNodes();
            if (sn != null && sn.Nodes != null)
            {
                Nodes.AddRange(sn.Nodes);
            }
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

        public SourceNode this[int idx]
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

        public void WriteXml(string fileName)
        {
            XmlDocument doc = new XmlDocument();

            XmlElement e1;

            e1 = doc.CreateElement("SourceNodeCollection");
            doc.AppendChild(e1);

            WriteNodes(e1, doc);

            doc.Save(fileName);
        }

        public void WriteNodes(XmlElement parent, XmlDocument doc)
        {
            XmlElement e2, e3;
            if (Nodes != null)
            {
                for (int i = 0; i < Nodes.Count; i++)
                {
                    e2 = doc.CreateElement("SourceNode");
                    parent.AppendChild(e2);

                    e2.SetAttribute("offset", Nodes[i].offset.ToString());
                    e2.SetAttribute("type", Nodes[i].type.ToString());

                    e3 = doc.CreateElement("value");
                    e2.AppendChild(e3);
                    e3.InnerText = Nodes[i].value;

                    e3 = doc.CreateElement("comments");
                    e2.AppendChild(e3);
                    e3.InnerText = Nodes[i].comments;

                    if (Nodes[i].Nodes != null && Nodes[i].Nodes.Count > 0)
                    {
                        e3 = doc.CreateElement("nodes");
                        e2.AppendChild(e3);
                        Nodes[i].Nodes.WriteNodes(e3, doc);
                    }
                }
            }
        }

        public void ReadXml(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            foreach (XmlElement e1 in doc.ChildNodes)
            {
                if (e1.Name.Equals("SourceNodeCollection"))
                {
                    SourceNodeCollection snc = ReadNode(e1, doc);
                    if (snc != null)
                        Nodes = snc.Nodes;
                }
            }
        }

        public SourceNodeCollection ReadNode(XmlElement elem, XmlDocument doc)
        {
            SourceNodeCollection snc = new SourceNodeCollection();
            foreach (XmlElement e2 in elem.ChildNodes)
            {
                if (e2.Name.Equals("SourceNode"))
                {
                    SourceNode sn = new SourceNode();
                    snc.Add(sn);
                    if (e2.HasAttribute("offset"))
                    {
                        long.TryParse(e2.GetAttribute("offset"), out sn.offset);
                    }
                    if (e2.HasAttribute("type"))
                    {
                        sn.type = e2.GetAttribute("type");
                    }

                    foreach (XmlElement e3 in e2.ChildNodes)
                    {
                        if (e3.Name.Equals("value"))
                            sn.value = e3.InnerText;
                        else if (e3.Name.Equals("comments"))
                            sn.comments = e3.InnerText;
                        else if (e3.Name.Equals("nodes"))
                            sn.Nodes = ReadNode(e3, doc);
                    }
                }
            }
            return snc;
        }
    }
}
