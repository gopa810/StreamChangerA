using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StreamChangerLib;
using System.IO;

namespace StreamChangerB
{
    public partial class Form1 : Form
    {

        string fileTableInput = "f3.xml";


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string appdir = Path.GetDirectoryName(Application.ExecutablePath);

            DataTable dtin = new DataTable();
            dtin.ReadXml(Path.Combine(appdir, "f3.xml"));



        
        }

    }
}
