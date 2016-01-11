using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using Registry_Scriptor.Properties;

namespace Registry_Scriptor
{
    public partial class mainFrm : Form
    {
        ThreadedWorker analyzer;
        ThreadedWorker worker;
        public mainFrm()
        {
            analyzer = new ThreadedWorker(() => analyzer_DoWork(), (o) => analyzer_RunWorkerCompleted(o));
            worker = new ThreadedWorker(() => worker_DoWork(), (o) => worker_RunWorkerCompleted(o));
            InitializeComponent();
            watchC.DataBindings.Add("Checked", Settings.Default, "WatchClipboard");
            cbc_cb.DataBindings.Add("Checked", Settings.Default, "BitCounterparts");
            ncm.DataBindings.Add("Checked", Settings.Default, "NoComments");
        }
        #region GUI Code
        public static errorLog logFrm = new errorLog();
        private void action_Click(object sender, EventArgs e)
        {
            if (analyzer.IsBusy || worker.IsBusy)
            {
                if (script)
                {
                    script = false;
                    script_Btn.Enabled = false;
                    script_Btn.Text = "Cancelling";
                    analyzer.CancelAsync();
                    worker.CancelAsync();
                }
                else
                {
                    analyze_Btn.Enabled = false;
                    analyze_Btn.Text = "Cancelling";
                    analyzer.CancelAsync();
                }
            }
            else
            {
                script = script_Btn.Enabled = ((Control)sender).Tag.ToString() == "s";
                analyze_Btn.Enabled = !script;
                if (script) script_Btn.Text = "Cancel"; else analyze_Btn.Text = "Cancel";
                analyzer.RunWorkerAsync();
            }
        }

        System.Timers.Timer anUpdate = new System.Timers.Timer { Interval = 1, AutoReset = true };

        private void Form1_Load(object sender, EventArgs e)
        {
            WCIn.Checked = Settings.Default.IncludeCP;
            WCEx.Checked = !Settings.Default.IncludeCP;
            incexcpanel.Visible = watchC.Checked;
            anUpdate.Elapsed += anUpdate_Elapsed;
            logFrm.relativePos = new Point(this.Width + 5, 0);
            logFrm.Show(this);
        }
        int le = 0;
        private void anUpdate_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                stL.Text = "(" + count.ToString() + " keys)";
                if (errors.Count > 0 && le < errors.Count - 1)
                { logFrm.AddLog(errors[le]); le++; logFrm.ecount.Text = le.ToString(); }
            });
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.StartsWith("HKEY"))
            {
                if (((Control)sender).Tag.ToString() == "i")
                    inc_list.Items.Add(new ListViewItem(textBox1.Text));
                else
                    exc_list.Items.Add(new ListViewItem(textBox1.Text));
            }
            else
            {
                MessageBox.Show("Invalid Key Name: " + textBox1.Text, "Error");
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in inc_list.SelectedItems)
            {
                item.Remove();
            }
        }
        private void removeToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in exc_list.SelectedItems)
            {
                item.Remove();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false, Encoding.ASCII);
                sw.Write(sc_text.Text.Replace("\n", "\r\n"));
                sw.Close();
            }
        }
        #endregion
        bool script = false;
        int count = 0;
        int ccount = 0;
        List<RegistryKey> kNames = new List<RegistryKey>();
        List<string> errors = new List<string>();
        private void analyzer_DoWork()
        {
            count = 0;
            kNames.Clear();
            List<string> keys = new List<string>();
            HashSet<string> excluded = new HashSet<string>();
            this.Invoke((MethodInvoker)delegate
            {
                op.Text = "Analyzing...";
                foreach (ListViewItem item in inc_list.Items)
                {
                    keys.Add(item.Text);
                }
                foreach (ListViewItem item in exc_list.Items)
                {
                    excluded.Add(item.Text);
                }
                anUpdate.Enabled = true;
                anUpdate.Start();
                errors.Clear();
                logFrm.eList.Items.Clear();
                logFrm.ecount.Text = "";
                le = 0;
            });
            Scriptor.ListKeys(keys.ToArray(), ref count, ref kNames, ref errors, excluded);
        }

        private void analyzer_RunWorkerCompleted(ThreadedWorkerOutcome outcome)
        {
            Invoke(new MethodInvoker(delegate
            {
                anUpdate.Enabled = false;
                anUpdate.Stop();
                analyze_Btn.Text = "Analyze";
                if (outcome == ThreadedWorkerOutcome.Cancelled)
                    script_Btn.Text = "Script";
                if (script)
                    worker.RunWorkerAsync();
                else
                {
                    analyze_Btn.Enabled = script_Btn.Enabled = true;
                    op.Text = outcome.ToString();
                    stL.Text = "(" + count + " Keys)";
                }
            }));
        }
        const string scriptHeader = "Windows Registry Editor Version 5.00";
        string sc = "";
        private void worker_DoWork()
        {
            string _32bit = "";
            string _64bit = "";
            ccount = 0;
            this.Invoke((MethodInvoker)delegate
            {
                op.Text = "Scripting..."; stL.Text = "";
            });
            int i = 0;
            sc = scriptHeader + ((CommentsAllowed()) ? "\n;Script generated by Registry Scriptor\n" : "\n");
            foreach (RegistryKey key in kNames)
            {
                this.Invoke((MethodInvoker)delegate { stL.Text = key.Name; });
                string s = ((CommentsAllowed()) ? "\n\n;" + i + "\n" : "\n\n") + Scriptor.GetScript(key);
                i++;
                if (cbc_cb.Checked)
                {
                    if (s.Contains("SOFTWARE\\Wow6432Node"))
                    {
                        _32bit += ((CommentsAllowed()) ? "\n\n;C" : "\n\n") + s.Trim('\n', ';').Replace("SOFTWARE\\Wow6432Node", "SOFTWARE");
                    }
                    else if (s.Contains("SOFTWARE"))
                    {
                        _64bit += ((CommentsAllowed()) ? "\n\n;C" : "\n\n") + s.Trim('\n', ';').Replace("SOFTWARE", "SOFTWARE\\Wow6432Node");
                    }
                }
                sc += s;
                Invoke(new MethodInvoker(() => progr.Value = Math.Min(100, (int)(++ccount / (float)count * 100))));
            }
            sc += ((_32bit != "") ? ((CommentsAllowed()) ? "\n\n;32Bit Copies" + _32bit : _32bit) : "") + ((_64bit != "") ? ((CommentsAllowed()) ? "\n\n;64Bit Copies" + _64bit : _64bit) : "");
        }

        private void worker_RunWorkerCompleted(ThreadedWorkerOutcome outcome)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                analyze_Btn.Enabled = script_Btn.Enabled = true;
                script_Btn.Text = "Script";
                op.Text = outcome.ToString();
                stL.Text = "(Scripted " + ccount + "/" + count + " Keys)" + ((cbc_cb.Checked && ccount > 0) ? " (Added " + ccount + " Copies)" : "");
                sc_text.Text = sc;
            }));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in inc_list.SelectedItems)
            {
                inc_list.Items.Remove(item);
                exc_list.Items.Add(item);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in exc_list.SelectedItems)
            {
                exc_list.Items.Remove(item);
                inc_list.Items.Add(item);
            }
        }
        bool CommentsAllowed()
        {
            return !ncm.Checked;
        }

        private void watchC_CheckedChanged(object sender, EventArgs e)
        {
            incexcpanel.Visible = watchC.Checked;
            WatchClipboard(watchC.Checked);
        }
        Timer WCT;
        private void WatchClipboard(bool stat)
        {
            if (stat)
            {
                lcl = Clipboard.GetText();
                WCT = new Timer { Interval = 500, Enabled = true };
                WCT.Start();
                WCT.Tick += WCTT;
            }
            else
            {
                WCT.Dispose();
            }
        }
        string lcl = "";
        private void WCTT(object sender, EventArgs e)
        {
            string s = Clipboard.GetText();
            if (s != lcl)
            {
                lcl = s;
                if (WCIn.Checked)
                    inc_list.Items.Add(new ListViewItem(s));
                else
                    exc_list.Items.Add(new ListViewItem(s));
            }
        }

        ToolTip tt = new ToolTip();
        private void stL_MouseHover(object sender, EventArgs e)
        {
            tt.Show(stL.Text, stL);
        }

        private void mainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            analyzer.CancelAsync();
            worker.CancelAsync();
            Settings.Default.IncludeCP = WCIn.Checked;
            Settings.Default.Save();
        }

        private void progr_Click(object sender, EventArgs e)
        {

        }

        private void inc_list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void exc_list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void incexcpanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
