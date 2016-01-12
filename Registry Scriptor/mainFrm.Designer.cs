namespace Registry_Scriptor
{
    partial class mainFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainFrm));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.inc_list = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sc_text = new System.Windows.Forms.RichTextBox();
            this.script_Btn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.stL = new System.Windows.Forms.Label();
            this.progr = new System.Windows.Forms.ProgressBar();
            this.op = new System.Windows.Forms.Label();
            this.analyze_Btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.exc_list = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.cbc_cb = new System.Windows.Forms.CheckBox();
            this.ncm = new System.Windows.Forms.CheckBox();
            this.watchC = new System.Windows.Forms.CheckBox();
            this.incexcpanel = new System.Windows.Forms.Panel();
            this.WCEx = new System.Windows.Forms.RadioButton();
            this.WCIn = new System.Windows.Forms.RadioButton();
            this.inputpanel = new System.Windows.Forms.Panel();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.incexcpanel.SuspendLayout();
            this.inputpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(73, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(259, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Key Name";
            // 
            // inc_list
            // 
            this.inc_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.inc_list.ContextMenuStrip = this.contextMenuStrip1;
            this.inc_list.Location = new System.Drawing.Point(13, 49);
            this.inc_list.Name = "inc_list";
            this.inc_list.Size = new System.Drawing.Size(308, 101);
            this.inc_list.TabIndex = 2;
            this.inc_list.UseCompatibleStateImageBehavior = false;
            this.inc_list.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Key Name";
            this.columnHeader1.Width = 443;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(93, 26);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // sc_text
            // 
            this.sc_text.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sc_text.Location = new System.Drawing.Point(0, 235);
            this.sc_text.Name = "sc_text";
            this.sc_text.Size = new System.Drawing.Size(661, 275);
            this.sc_text.TabIndex = 3;
            this.sc_text.Text = "";
            this.sc_text.WordWrap = false;
            // 
            // script_Btn
            // 
            this.script_Btn.Location = new System.Drawing.Point(492, 206);
            this.script_Btn.Name = "script_Btn";
            this.script_Btn.Size = new System.Drawing.Size(75, 23);
            this.script_Btn.TabIndex = 4;
            this.script_Btn.Tag = "s";
            this.script_Btn.Text = "Script";
            this.script_Btn.UseVisualStyleBackColor = true;
            this.script_Btn.Click += new System.EventHandler(this.action_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(573, 206);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(338, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Tag = "i";
            this.button3.Text = "Include";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Registry Script|*.reg;*.key";
            this.saveFileDialog1.Title = "Save File";
            // 
            // stL
            // 
            this.stL.Location = new System.Drawing.Point(73, 186);
            this.stL.Name = "stL";
            this.stL.Size = new System.Drawing.Size(576, 12);
            this.stL.TabIndex = 5;
            this.stL.MouseHover += new System.EventHandler(this.stL_MouseHover);
            // 
            // progr
            // 
            this.progr.Location = new System.Drawing.Point(12, 206);
            this.progr.Name = "progr";
            this.progr.Size = new System.Drawing.Size(393, 23);
            this.progr.TabIndex = 6;
            // 
            // op
            // 
            this.op.AutoSize = true;
            this.op.Location = new System.Drawing.Point(12, 185);
            this.op.Name = "op";
            this.op.Size = new System.Drawing.Size(0, 13);
            this.op.TabIndex = 5;
            // 
            // analyze_Btn
            // 
            this.analyze_Btn.Location = new System.Drawing.Point(411, 206);
            this.analyze_Btn.Name = "analyze_Btn";
            this.analyze_Btn.Size = new System.Drawing.Size(75, 23);
            this.analyze_Btn.TabIndex = 4;
            this.analyze_Btn.Tag = "a";
            this.analyze_Btn.Text = "Analyze";
            this.analyze_Btn.UseVisualStyleBackColor = true;
            this.analyze_Btn.Click += new System.EventHandler(this.action_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(419, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Tag = "e";
            this.button1.Text = "Exclude";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button3_Click);
            // 
            // exc_list
            // 
            this.exc_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.exc_list.ContextMenuStrip = this.contextMenuStrip2;
            this.exc_list.Location = new System.Drawing.Point(352, 49);
            this.exc_list.Name = "exc_list";
            this.exc_list.Size = new System.Drawing.Size(297, 101);
            this.exc_list.TabIndex = 2;
            this.exc_list.UseCompatibleStateImageBehavior = false;
            this.exc_list.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Key Name";
            this.columnHeader2.Width = 443;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(118, 26);
            // 
            // removeToolStripMenuItem1
            // 
            this.removeToolStripMenuItem1.Name = "removeToolStripMenuItem1";
            this.removeToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem1.Text = "Remove";
            this.removeToolStripMenuItem1.Click += new System.EventHandler(this.removeToolStripMenuItem2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Included Keys";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(349, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Excluded Keys";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(328, 72);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(18, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = ">";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(328, 101);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(18, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "<";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // cbc_cb
            // 
            this.cbc_cb.AutoSize = true;
            this.cbc_cb.Location = new System.Drawing.Point(352, 163);
            this.cbc_cb.Name = "cbc_cb";
            this.cbc_cb.Size = new System.Drawing.Size(180, 17);
            this.cbc_cb.TabIndex = 8;
            this.cbc_cb.Text = "Include 32Bit/64Bit Counterparts";
            this.cbc_cb.UseVisualStyleBackColor = true;
            // 
            // ncm
            // 
            this.ncm.AutoSize = true;
            this.ncm.Location = new System.Drawing.Point(556, 162);
            this.ncm.Name = "ncm";
            this.ncm.Size = new System.Drawing.Size(92, 17);
            this.ncm.TabIndex = 9;
            this.ncm.Text = "No Comments";
            this.ncm.UseVisualStyleBackColor = true;
            // 
            // watchC
            // 
            this.watchC.AutoSize = true;
            this.watchC.Location = new System.Drawing.Point(500, 8);
            this.watchC.Name = "watchC";
            this.watchC.Size = new System.Drawing.Size(104, 17);
            this.watchC.TabIndex = 10;
            this.watchC.Text = "Watch clipboard";
            this.watchC.UseVisualStyleBackColor = true;
            this.watchC.CheckedChanged += new System.EventHandler(this.watchC_CheckedChanged);
            // 
            // incexcpanel
            // 
            this.incexcpanel.Controls.Add(this.WCEx);
            this.incexcpanel.Controls.Add(this.WCIn);
            this.incexcpanel.Location = new System.Drawing.Point(500, 27);
            this.incexcpanel.Name = "incexcpanel";
            this.incexcpanel.Size = new System.Drawing.Size(149, 19);
            this.incexcpanel.TabIndex = 11;
            // 
            // WCEx
            // 
            this.WCEx.AutoSize = true;
            this.WCEx.Dock = System.Windows.Forms.DockStyle.Right;
            this.WCEx.Location = new System.Drawing.Point(86, 0);
            this.WCEx.Name = "WCEx";
            this.WCEx.Size = new System.Drawing.Size(63, 19);
            this.WCEx.TabIndex = 0;
            this.WCEx.TabStop = true;
            this.WCEx.Text = "Exclude";
            this.WCEx.UseVisualStyleBackColor = true;
            // 
            // WCIn
            // 
            this.WCIn.AutoSize = true;
            this.WCIn.Dock = System.Windows.Forms.DockStyle.Left;
            this.WCIn.Location = new System.Drawing.Point(0, 0);
            this.WCIn.Name = "WCIn";
            this.WCIn.Size = new System.Drawing.Size(60, 19);
            this.WCIn.TabIndex = 0;
            this.WCIn.TabStop = true;
            this.WCIn.Text = "Include";
            this.WCIn.UseVisualStyleBackColor = true;
            // 
            // inputpanel
            // 
            this.inputpanel.Controls.Add(this.ncm);
            this.inputpanel.Controls.Add(this.cbc_cb);
            this.inputpanel.Controls.Add(this.label1);
            this.inputpanel.Controls.Add(this.textBox1);
            this.inputpanel.Controls.Add(this.incexcpanel);
            this.inputpanel.Controls.Add(this.label2);
            this.inputpanel.Controls.Add(this.watchC);
            this.inputpanel.Controls.Add(this.label3);
            this.inputpanel.Controls.Add(this.button5);
            this.inputpanel.Controls.Add(this.inc_list);
            this.inputpanel.Controls.Add(this.button4);
            this.inputpanel.Controls.Add(this.exc_list);
            this.inputpanel.Controls.Add(this.button3);
            this.inputpanel.Controls.Add(this.button1);
            this.inputpanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.inputpanel.Location = new System.Drawing.Point(0, 0);
            this.inputpanel.Name = "inputpanel";
            this.inputpanel.Size = new System.Drawing.Size(661, 182);
            this.inputpanel.TabIndex = 12;
            // 
            // mainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 510);
            this.Controls.Add(this.stL);
            this.Controls.Add(this.op);
            this.Controls.Add(this.progr);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.sc_text);
            this.Controls.Add(this.analyze_Btn);
            this.Controls.Add(this.script_Btn);
            this.Controls.Add(this.inputpanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "mainFrm";
            this.Text = "Registry Scriptor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainFrm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.incexcpanel.ResumeLayout(false);
            this.incexcpanel.PerformLayout();
            this.inputpanel.ResumeLayout(false);
            this.inputpanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView inc_list;
        private System.Windows.Forms.RichTextBox sc_text;
        private System.Windows.Forms.Button script_Btn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label stL;
        private System.Windows.Forms.ProgressBar progr;
        private System.Windows.Forms.Label op;
        private System.Windows.Forms.Button analyze_Btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView exc_list;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox cbc_cb;
        private System.Windows.Forms.CheckBox ncm;
        private System.Windows.Forms.CheckBox watchC;
        private System.Windows.Forms.Panel incexcpanel;
        private System.Windows.Forms.RadioButton WCEx;
        private System.Windows.Forms.RadioButton WCIn;
        private System.Windows.Forms.Panel inputpanel;
    }
}

