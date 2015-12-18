namespace Registry_Scriptor
{
    partial class errorLog
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
            this.ecount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.eList = new System.Windows.Forms.ListView();
            this.Key = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Error = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // ecount
            // 
            this.ecount.AutoSize = true;
            this.ecount.Location = new System.Drawing.Point(53, 9);
            this.ecount.Name = "ecount";
            this.ecount.Size = new System.Drawing.Size(0, 13);
            this.ecount.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Errors";
            // 
            // eList
            // 
            this.eList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Key,
            this.Error});
            this.eList.ForeColor = System.Drawing.Color.Red;
            this.eList.Location = new System.Drawing.Point(12, 28);
            this.eList.Name = "eList";
            this.eList.Size = new System.Drawing.Size(290, 253);
            this.eList.TabIndex = 10;
            this.eList.UseCompatibleStateImageBehavior = false;
            this.eList.View = System.Windows.Forms.View.Details;
            // 
            // Key
            // 
            this.Key.Text = "Key Name";
            this.Key.Width = 112;
            // 
            // Error
            // 
            this.Error.Text = "Error";
            this.Error.Width = 114;
            // 
            // errorLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 293);
            this.Controls.Add(this.ecount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.eList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "errorLog";
            this.ShowInTaskbar = false;
            this.Text = "Log";
            this.Load += new System.EventHandler(this.Log_Load);
            this.LocationChanged += new System.EventHandler(this.Log_LocationChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader Key;
        private System.Windows.Forms.ColumnHeader Error;
        public System.Windows.Forms.ListView eList;
        public System.Windows.Forms.Label ecount;
        private System.Windows.Forms.Label label2;
    }
}