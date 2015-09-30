namespace StreamChangerA
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageStream = new System.Windows.Forms.TabPage();
            this.richTextBoxInputA = new System.Windows.Forms.RichTextBox();
            this.buttonReadInputA = new System.Windows.Forms.Button();
            this.tabPageS2TControl = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBoxScriptA = new System.Windows.Forms.RichTextBox();
            this.tabPageTable = new System.Windows.Forms.TabPage();
            this.buttonWriteInputC = new System.Windows.Forms.Button();
            this.buttonReadInputC = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPageT2TControl = new System.Windows.Forms.TabPage();
            this.richTextBoxScriptC = new System.Windows.Forms.RichTextBox();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.tabPageTree = new System.Windows.Forms.TabPage();
            this.treeViewOutputC = new System.Windows.Forms.TreeView();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBoxOmitFromA = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxMainSymbolC = new System.Windows.Forms.TextBox();
            this.buttonWriteDef = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonSaveTree = new System.Windows.Forms.Button();
            this.tabPageProcessing = new System.Windows.Forms.TabPage();
            this.textBoxMessageA = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.treeViewParsingC = new System.Windows.Forms.TreeView();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageStream.SuspendLayout();
            this.tabPageS2TControl.SuspendLayout();
            this.tabPageTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPageT2TControl.SuspendLayout();
            this.tabPageTree.SuspendLayout();
            this.tabPageProcessing.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "tree_group.png");
            this.imageList1.Images.SetKeyName(1, "tree_list.png");
            this.imageList1.Images.SetKeyName(2, "tree_term.png");
            this.imageList1.Images.SetKeyName(3, "tree_type.png");
            this.imageList1.Images.SetKeyName(4, "tree_value.png");
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageS2TControl);
            this.tabControl1.Controls.Add(this.tabPageT2TControl);
            this.tabControl1.Controls.Add(this.tabPageProcessing);
            this.tabControl1.Controls.Add(this.tabPageStream);
            this.tabControl1.Controls.Add(this.tabPageTable);
            this.tabControl1.Controls.Add(this.tabPageTree);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 604);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPageStream
            // 
            this.tabPageStream.Controls.Add(this.richTextBoxInputA);
            this.tabPageStream.Controls.Add(this.buttonReadInputA);
            this.tabPageStream.Location = new System.Drawing.Point(4, 22);
            this.tabPageStream.Name = "tabPageStream";
            this.tabPageStream.Size = new System.Drawing.Size(776, 578);
            this.tabPageStream.TabIndex = 5;
            this.tabPageStream.Text = "Stream";
            this.tabPageStream.UseVisualStyleBackColor = true;
            // 
            // richTextBoxInputA
            // 
            this.richTextBoxInputA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxInputA.Location = new System.Drawing.Point(3, 43);
            this.richTextBoxInputA.Name = "richTextBoxInputA";
            this.richTextBoxInputA.Size = new System.Drawing.Size(770, 520);
            this.richTextBoxInputA.TabIndex = 1;
            this.richTextBoxInputA.Text = "";
            // 
            // buttonReadInputA
            // 
            this.buttonReadInputA.Location = new System.Drawing.Point(3, 14);
            this.buttonReadInputA.Name = "buttonReadInputA";
            this.buttonReadInputA.Size = new System.Drawing.Size(129, 23);
            this.buttonReadInputA.TabIndex = 0;
            this.buttonReadInputA.Text = "Read Input File";
            this.buttonReadInputA.UseVisualStyleBackColor = true;
            this.buttonReadInputA.Click += new System.EventHandler(this.buttonReadInputA_Click);
            // 
            // tabPageS2TControl
            // 
            this.tabPageS2TControl.Controls.Add(this.label7);
            this.tabPageS2TControl.Controls.Add(this.buttonWriteDef);
            this.tabPageS2TControl.Controls.Add(this.label8);
            this.tabPageS2TControl.Controls.Add(this.button2);
            this.tabPageS2TControl.Controls.Add(this.label2);
            this.tabPageS2TControl.Controls.Add(this.richTextBoxScriptA);
            this.tabPageS2TControl.Location = new System.Drawing.Point(4, 22);
            this.tabPageS2TControl.Name = "tabPageS2TControl";
            this.tabPageS2TControl.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageS2TControl.Size = new System.Drawing.Size(776, 578);
            this.tabPageS2TControl.TabIndex = 0;
            this.tabPageS2TControl.Text = "S2T Control";
            this.tabPageS2TControl.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(483, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Read definition file";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(459, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Read from file";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.onButtonReadScriptA);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "This textbox contains definitions for Stream-to-table engine";
            // 
            // richTextBoxScriptA
            // 
            this.richTextBoxScriptA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxScriptA.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxScriptA.Location = new System.Drawing.Point(6, 68);
            this.richTextBoxScriptA.Name = "richTextBoxScriptA";
            this.richTextBoxScriptA.Size = new System.Drawing.Size(751, 504);
            this.richTextBoxScriptA.TabIndex = 5;
            this.richTextBoxScriptA.Text = "";
            // 
            // tabPageTable
            // 
            this.tabPageTable.Controls.Add(this.buttonWriteInputC);
            this.tabPageTable.Controls.Add(this.buttonReadInputC);
            this.tabPageTable.Controls.Add(this.dataGridView1);
            this.tabPageTable.Location = new System.Drawing.Point(4, 22);
            this.tabPageTable.Name = "tabPageTable";
            this.tabPageTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTable.Size = new System.Drawing.Size(776, 578);
            this.tabPageTable.TabIndex = 1;
            this.tabPageTable.Text = "Table";
            this.tabPageTable.UseVisualStyleBackColor = true;
            // 
            // buttonWriteInputC
            // 
            this.buttonWriteInputC.Location = new System.Drawing.Point(87, 6);
            this.buttonWriteInputC.Name = "buttonWriteInputC";
            this.buttonWriteInputC.Size = new System.Drawing.Size(75, 23);
            this.buttonWriteInputC.TabIndex = 2;
            this.buttonWriteInputC.Text = "Write File";
            this.buttonWriteInputC.UseVisualStyleBackColor = true;
            this.buttonWriteInputC.Click += new System.EventHandler(this.buttonWriteInputC_Click);
            // 
            // buttonReadInputC
            // 
            this.buttonReadInputC.Location = new System.Drawing.Point(6, 6);
            this.buttonReadInputC.Name = "buttonReadInputC";
            this.buttonReadInputC.Size = new System.Drawing.Size(75, 23);
            this.buttonReadInputC.TabIndex = 1;
            this.buttonReadInputC.Text = "Read File";
            this.buttonReadInputC.UseVisualStyleBackColor = true;
            this.buttonReadInputC.Click += new System.EventHandler(this.buttonReadInputC_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(764, 537);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPageT2TControl
            // 
            this.tabPageT2TControl.Controls.Add(this.label9);
            this.tabPageT2TControl.Controls.Add(this.textBoxMainSymbolC);
            this.tabPageT2TControl.Controls.Add(this.label6);
            this.tabPageT2TControl.Controls.Add(this.richTextBoxOmitFromA);
            this.tabPageT2TControl.Controls.Add(this.label5);
            this.tabPageT2TControl.Controls.Add(this.richTextBoxScriptC);
            this.tabPageT2TControl.Location = new System.Drawing.Point(4, 22);
            this.tabPageT2TControl.Name = "tabPageT2TControl";
            this.tabPageT2TControl.Size = new System.Drawing.Size(776, 578);
            this.tabPageT2TControl.TabIndex = 4;
            this.tabPageT2TControl.Text = "T2T Control";
            this.tabPageT2TControl.UseVisualStyleBackColor = true;
            // 
            // richTextBoxScriptC
            // 
            this.richTextBoxScriptC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxScriptC.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxScriptC.Location = new System.Drawing.Point(13, 43);
            this.richTextBoxScriptC.Name = "richTextBoxScriptC";
            this.richTextBoxScriptC.Size = new System.Drawing.Size(744, 366);
            this.richTextBoxScriptC.TabIndex = 10;
            this.richTextBoxScriptC.Text = "";
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "tree_st_pend.png");
            this.imageList2.Images.SetKeyName(1, "tree_st_ok.png");
            this.imageList2.Images.SetKeyName(2, "tree_st_fail.png");
            this.imageList2.Images.SetKeyName(3, "tree_st_opt.png");
            // 
            // tabPageTree
            // 
            this.tabPageTree.Controls.Add(this.buttonSaveTree);
            this.tabPageTree.Controls.Add(this.treeViewOutputC);
            this.tabPageTree.Location = new System.Drawing.Point(4, 22);
            this.tabPageTree.Name = "tabPageTree";
            this.tabPageTree.Size = new System.Drawing.Size(776, 578);
            this.tabPageTree.TabIndex = 3;
            this.tabPageTree.Text = "Tree";
            this.tabPageTree.UseVisualStyleBackColor = true;
            // 
            // treeViewOutputC
            // 
            this.treeViewOutputC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewOutputC.ImageIndex = 0;
            this.treeViewOutputC.ImageList = this.imageList1;
            this.treeViewOutputC.Location = new System.Drawing.Point(3, 52);
            this.treeViewOutputC.Name = "treeViewOutputC";
            this.treeViewOutputC.SelectedImageIndex = 0;
            this.treeViewOutputC.Size = new System.Drawing.Size(770, 523);
            this.treeViewOutputC.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 430);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "List of types to omit from input";
            // 
            // richTextBoxOmitFromA
            // 
            this.richTextBoxOmitFromA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxOmitFromA.Location = new System.Drawing.Point(13, 446);
            this.richTextBoxOmitFromA.Name = "richTextBoxOmitFromA";
            this.richTextBoxOmitFromA.Size = new System.Drawing.Size(218, 116);
            this.richTextBoxOmitFromA.TabIndex = 12;
            this.richTextBoxOmitFromA.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(283, 430);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Main Symbol";
            // 
            // textBoxMainSymbolC
            // 
            this.textBoxMainSymbolC.Location = new System.Drawing.Point(286, 446);
            this.textBoxMainSymbolC.Name = "textBoxMainSymbolC";
            this.textBoxMainSymbolC.Size = new System.Drawing.Size(246, 20);
            this.textBoxMainSymbolC.TabIndex = 14;
            // 
            // buttonWriteDef
            // 
            this.buttonWriteDef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonWriteDef.Location = new System.Drawing.Point(611, 12);
            this.buttonWriteDef.Name = "buttonWriteDef";
            this.buttonWriteDef.Size = new System.Drawing.Size(146, 23);
            this.buttonWriteDef.TabIndex = 13;
            this.buttonWriteDef.Text = "Write to File";
            this.buttonWriteDef.UseVisualStyleBackColor = true;
            this.buttonWriteDef.Click += new System.EventHandler(this.buttonWriteDef_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(640, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Write definition file";
            // 
            // buttonSaveTree
            // 
            this.buttonSaveTree.Location = new System.Drawing.Point(3, 14);
            this.buttonSaveTree.Name = "buttonSaveTree";
            this.buttonSaveTree.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveTree.TabIndex = 1;
            this.buttonSaveTree.Text = "Save";
            this.buttonSaveTree.UseVisualStyleBackColor = true;
            this.buttonSaveTree.Click += new System.EventHandler(this.buttonSaveTree_Click);
            // 
            // tabPageProcessing
            // 
            this.tabPageProcessing.Controls.Add(this.treeViewParsingC);
            this.tabPageProcessing.Controls.Add(this.label3);
            this.tabPageProcessing.Controls.Add(this.button3);
            this.tabPageProcessing.Controls.Add(this.textBoxMessageA);
            this.tabPageProcessing.Controls.Add(this.label4);
            this.tabPageProcessing.Controls.Add(this.button1);
            this.tabPageProcessing.Controls.Add(this.label1);
            this.tabPageProcessing.Location = new System.Drawing.Point(4, 22);
            this.tabPageProcessing.Name = "tabPageProcessing";
            this.tabPageProcessing.Size = new System.Drawing.Size(776, 578);
            this.tabPageProcessing.TabIndex = 6;
            this.tabPageProcessing.Text = "Processing";
            this.tabPageProcessing.UseVisualStyleBackColor = true;
            // 
            // textBoxMessageA
            // 
            this.textBoxMessageA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxMessageA.Location = new System.Drawing.Point(19, 92);
            this.textBoxMessageA.Name = "textBoxMessageA";
            this.textBoxMessageA.Size = new System.Drawing.Size(735, 65);
            this.textBoxMessageA.TabIndex = 16;
            this.textBoxMessageA.Text = "";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Message from engine:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(326, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Stream to Table";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.onButtonRunStreamToTable);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(267, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Transform stream of characters into list of source nodes";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(306, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Apply list to tree transformation rules";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(326, 213);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "Table to Tree";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.onButtonProcessTableToTree);
            // 
            // treeViewParsingC
            // 
            this.treeViewParsingC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewParsingC.ImageIndex = 0;
            this.treeViewParsingC.ImageList = this.imageList2;
            this.treeViewParsingC.Location = new System.Drawing.Point(19, 269);
            this.treeViewParsingC.Name = "treeViewParsingC";
            this.treeViewParsingC.SelectedImageIndex = 0;
            this.treeViewParsingC.Size = new System.Drawing.Size(735, 295);
            this.treeViewParsingC.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(174, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Table to Tree definitions (BNF form)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 628);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "StreamChanger";
            this.tabControl1.ResumeLayout(false);
            this.tabPageStream.ResumeLayout(false);
            this.tabPageS2TControl.ResumeLayout(false);
            this.tabPageS2TControl.PerformLayout();
            this.tabPageTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPageT2TControl.ResumeLayout(false);
            this.tabPageT2TControl.PerformLayout();
            this.tabPageTree.ResumeLayout(false);
            this.tabPageProcessing.ResumeLayout(false);
            this.tabPageProcessing.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageS2TControl;
        private System.Windows.Forms.TabPage tabPageTable;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.TabPage tabPageTree;
        private System.Windows.Forms.TreeView treeViewOutputC;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBoxScriptA;
        private System.Windows.Forms.TabPage tabPageT2TControl;
        private System.Windows.Forms.TabPage tabPageStream;
        private System.Windows.Forms.RichTextBox richTextBoxInputA;
        private System.Windows.Forms.Button buttonReadInputA;
        private System.Windows.Forms.Button buttonWriteInputC;
        private System.Windows.Forms.Button buttonReadInputC;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RichTextBox richTextBoxScriptC;
        private System.Windows.Forms.TextBox textBoxMainSymbolC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox richTextBoxOmitFromA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonWriteDef;
        private System.Windows.Forms.Button buttonSaveTree;
        private System.Windows.Forms.TabPage tabPageProcessing;
        private System.Windows.Forms.TreeView treeViewParsingC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox textBoxMessageA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
    }
}

