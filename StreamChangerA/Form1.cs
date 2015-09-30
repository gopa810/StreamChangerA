using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Diagnostics;
using TextToTreeLib;

namespace StreamChangerA
{
    public partial class Form1 : Form
    {
        ListToTreeConvertor cnc = new ListToTreeConvertor();

        SourceNodeCollection outputA = null;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Processing of input stream with script
        /// Output is table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onButtonRunStreamToTable(object sender, EventArgs e)
        {
            string appdir = Path.GetDirectoryName(Application.ExecutablePath);
            StreamToTable stt = new StreamToTable();

            // STEP A - initialization
            stt.Script = richTextBoxScriptA.Text;
            stt.InputText = richTextBoxInputA.Text + "\r\n";

            // STEP A - processing
            stt.Run();

            // STEP A - publish the results
            if (!stt.Success)
            {
                string temp = stt.InputText.Substring(stt.LastPosition);
                textBoxMessageA.Text = stt.Message + "\r\n\r\nLAST POSITION: " + stt.LastPosition + "\r\n\r\n== REST OF THE FILE ==\r\n" + temp;
            }
            else
            {
                textBoxMessageA.Text = stt.Message;
            }

            outputA = stt.Elements;

            DataTable dt = new DataTable();
            dt.Columns.Add("Index", typeof(int));
            dt.Columns.Add("Position", typeof(long));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Value", typeof(string));
            for (int i = 0; i < outputA.Count; i++)
            {
                SourceNode sn = outputA[i];
                DataRow dr = dt.NewRow();
                dr.SetField<int>(0, i);
                dr.SetField<long>(1, sn.offset);
                dr.SetField<string>(2, sn.type);
                dr.SetField<string>(3, sn.value);
                dt.Rows.Add(dr);
            }

            dataGridView1.DataSource = dt;
        }

        private void onButtonProcessTableToTree(object sender, EventArgs e)
        {
            string appdir = Path.GetDirectoryName(Application.ExecutablePath);

            // STEP C - initialization
            cnc = new ListToTreeConvertor();
            cnc.InputSource = outputA;
            cnc.LoadText(richTextBoxScriptC.Text);

            string[] omitFromA = richTextBoxOmitFromA.Lines;
            foreach (string s in omitFromA)
            {
                if (s.Length > 0)
                {
                    cnc.InputFilterTypesRemove.Add(s);
                }
            }

            cnc.MainSymbol = textBoxMainSymbolC.Text;

            
            // STEP C - processing
            cnc.Run();


            // STEP C - publishing results
            treeViewOutputC.Nodes.Clear();
            treeViewParsingC.Nodes.Clear();

            foreach (TreeNode tn in cnc.CurrNode.Nodes)
            {
                tn.ImageIndex = tn.SelectedImageIndex = ImageIndexForNode(tn);
                treeViewParsingC.Nodes.Add(tn);
            }

            if (cnc.OutputSource != null)
                treeViewOutputC.Nodes.Add(SourceNodeToTreeNode(cnc.OutputSource));
        }

        private void AddSourceNodeToCollection(TreeNodeCollection treeNodeCollection, List<TrackPart> sourceNodeCollection)
        {
            if (sourceNodeCollection == null)
                return;

            if (sourceNodeCollection.Count == 0)
                return;

            foreach (TrackPart tp in sourceNodeCollection)
            {
                treeNodeCollection.Add(SourceNodeToTreeNode(tp));
            }
        }

        private TreeNode SourceNodeToTreeNode(TrackPart sourceNode)
        {
            TreeNode tn = new TreeNode();

            tn.Text = sourceNode.symbolText;// +" [" + sourceNode.symbolType.ToString() + "]";
            switch (sourceNode.symbolType)
            {
                case SymbolType.BY_SYMBOL:
                    tn.SelectedImageIndex = tn.ImageIndex = 2;
                    break;
                case SymbolType.BY_TYPE:
                    tn.SelectedImageIndex = tn.ImageIndex = 3;
                    break;
                case SymbolType.BY_VALUE:
                    tn.SelectedImageIndex = tn.ImageIndex = 4;
                    break;
            }

            AddSourceNodeToCollection(tn.Nodes, sourceNode.children);

            return tn;
        }

        private int ImageIndexForNode(TreeNode tn)
        {
            int[] i = new int[] { 0, 0, 0, 0, 0 };
            int ti = 0;
            int cnt = 0;
            if (tn.Nodes.Count > 0)
            {
                foreach (TreeNode cn in tn.Nodes)
                {
                    ti = ImageIndexForNode(cn);
                    cn.ImageIndex = cn.SelectedImageIndex = ti;
                    i[ti] = i[ti] + 1;
                    cnt++;
                }
                for (int a = 0; a < 3; a++)
                {
                    if (i[a] == cnt)
                        return a;
                }

                return 0;
            }

            return tn.ImageIndex;

        }

        private void onButtonReadScriptA(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.DefaultExt = ".sttx";
            ofd.Filter = "Xml configuration (*.sttx)|*.sttx||";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StringBuilder sba = new StringBuilder();
                StringBuilder sbb = new StringBuilder();
                StringBuilder sbbo = new StringBuilder();
                XmlDocument doc = new XmlDocument();
                doc.Load(ofd.FileName);
                foreach (XmlElement xe in doc.ChildNodes)
                {
                    if (xe.Name.Equals("streamtotext"))
                    {
                        foreach (XmlElement xd in xe.ChildNodes)
                        {
                            if (xd.Name.Equals("sa"))
                            {
                                sba.AppendLine(xd.InnerText);
                            }
                            else if (xd.Name.Equals("sb"))
                            {
                                sbb.AppendLine(xd.InnerText);
                            }
                            else if (xd.Name.Equals("sbo"))
                            {
                                sbbo.AppendLine(xd.InnerText);
                            }
                            else if (xd.Name.Equals("sbmain"))
                            {
                                textBoxMainSymbolC.Text = xd.InnerText;
                            }
                        }
                    }
                }
                richTextBoxScriptA.Text = sba.ToString();
                richTextBoxScriptC.Text = sbb.ToString();
                richTextBoxOmitFromA.Text = sbbo.ToString();
                //richTextBoxScriptA.Text = File.ReadAllText(ofd.FileName);
            }
        }

        private void buttonReadInputA_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBoxInputA.Text = File.ReadAllText(ofd.FileName);
            }
        }

        private void buttonReadScriptC_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBoxScriptC.Text = File.ReadAllText(ofd.FileName);
            }
        }

        private void buttonWriteInputC_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                outputA.WriteXml(sfd.FileName);
            }

        }

        private void buttonReadInputC_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SourceNodeCollection snc = new SourceNodeCollection();

                snc.ReadXml(ofd.FileName);
                outputA = snc;
            }
        }

        private void buttonWriteDef_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = ".sttx";
            sfd.Filter = "Xml Configuration file (*.sttx)|*.sttx||";

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                XmlDocument doc = new XmlDocument();
                XmlElement xe, xd, x2;

                xe = doc.CreateElement("streamtotext");
                doc.AppendChild(xe);

                string[] lines = richTextBoxScriptA.Lines;
                foreach (string h in lines)
                {
                    xd = doc.CreateElement("sa");
                    xd.InnerText = h;
                    xe.AppendChild(xd);
                }

                lines = richTextBoxScriptC.Lines;
                foreach (string h in lines)
                {
                    xd = doc.CreateElement("sb");
                    xd.InnerText = h;
                    xe.AppendChild(xd);
                }

                lines = richTextBoxOmitFromA.Lines;
                foreach (string h in lines)
                {
                    if (h.Length != 0)
                    {
                        xd = doc.CreateElement("sbo");
                        xd.InnerText = h;
                        xe.AppendChild(xd);
                    }
                }

                xd = doc.CreateElement("sbmain");
                xd.InnerText = textBoxMainSymbolC.Text;
                xe.AppendChild(xd);


                doc.Save(sfd.FileName);
            }
        }

        private void buttonSaveTree_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = ".xml";
            sfd.Filter = "Xml files (*.xml)|*.xml||";

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (cnc != null)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.AppendChild(cnc.GetXmlNode(doc));
                    doc.Save(sfd.FileName);
                }
            }
        }
    }
}
