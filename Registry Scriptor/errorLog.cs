using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Registry_Scriptor
{
    public partial class errorLog : Form
    {
        public errorLog()
        {
            InitializeComponent();
        }

        public Point relativePos;
        private void Log_Load(object sender, EventArgs e)
        {
            lastSize = this.Size;
            this.Location = new Point(this.Owner.Location.X + relativePos.X, this.Owner.Location.Y + relativePos.Y);
            this.Owner.LocationChanged += lch;
        }

        private void lch(object sender, EventArgs e)
        {
            this.Location = new Point(this.Owner.Location.X + relativePos.X, this.Owner.Location.Y + relativePos.Y);
            Application.DoEvents();
        }

        public void AddLog(string p)
        {
            string[] data = Regex.Split(p, "%%##");
            ListViewItem item = new ListViewItem(data[0]);
            item.SubItems.Add(new ListViewItem.ListViewSubItem { Text = data[1] });
            this.Invoke((MethodInvoker)delegate { eList.Items.Add(item); });
            this.Invoke((MethodInvoker)delegate { eList.EnsureVisible(eList.Items.Count - 1); });
        }

        private void Log_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Shrink();
            }
        }
        private void sBtn_Click(object sender, EventArgs e)
        {
            Expand();
        }
        Size lastSize;
        private void Shrink()
        {
            lastSize = this.Size;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            eList.Visible = false;
            //this.Size = sBtn.Size;
            //this.sBtn.Visible = true;
        }
        private void Expand()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.eList.Visible = true;
            this.Size = lastSize;
            //this.sBtn.Visible = false;
        }
        bool init = false;
        private void Log_LocationChanged(object sender, EventArgs e)
        {
            if (init)
                relativePos = new Point(this.Location.X - this.Owner.Location.X, this.Location.Y - this.Owner.Location.Y);
            else
                init = true;
        }
    }
}
