namespace PostTracks
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tp_Track_JSON = new System.Windows.Forms.TabPage();
            this.tp_Ali = new System.Windows.Forms.TabPage();
            this.webBrowser_Ali = new System.Windows.Forms.WebBrowser();
            this.tabControl.SuspendLayout();
            this.tp_Track_JSON.SuspendLayout();
            this.tp_Ali.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(237, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 32);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(362, 373);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(452, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tp_Track_JSON);
            this.tabControl.Controls.Add(this.tp_Ali);
            this.tabControl.Location = new System.Drawing.Point(0, 28);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(452, 442);
            this.tabControl.TabIndex = 3;
            // 
            // tp_Track_JSON
            // 
            this.tp_Track_JSON.Controls.Add(this.textBox1);
            this.tp_Track_JSON.Controls.Add(this.richTextBox1);
            this.tp_Track_JSON.Location = new System.Drawing.Point(4, 22);
            this.tp_Track_JSON.Name = "tp_Track_JSON";
            this.tp_Track_JSON.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Track_JSON.Size = new System.Drawing.Size(444, 416);
            this.tp_Track_JSON.TabIndex = 0;
            this.tp_Track_JSON.Text = "Track JSON";
            this.tp_Track_JSON.UseVisualStyleBackColor = true;
            // 
            // tp_Ali
            // 
            this.tp_Ali.Controls.Add(this.webBrowser_Ali);
            this.tp_Ali.Location = new System.Drawing.Point(4, 22);
            this.tp_Ali.Name = "tp_Ali";
            this.tp_Ali.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Ali.Size = new System.Drawing.Size(444, 416);
            this.tp_Ali.TabIndex = 1;
            this.tp_Ali.Text = "Ali";
            this.tp_Ali.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser_Ali.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser_Ali.Location = new System.Drawing.Point(3, 3);
            this.webBrowser_Ali.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser_Ali.Name = "webBrowser1";
            this.webBrowser_Ali.Size = new System.Drawing.Size(438, 410);
            this.webBrowser_Ali.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 467);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Track24";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.tp_Track_JSON.ResumeLayout(false);
            this.tp_Track_JSON.PerformLayout();
            this.tp_Ali.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tp_Track_JSON;
        private System.Windows.Forms.TabPage tp_Ali;
        private System.Windows.Forms.WebBrowser webBrowser_Ali;
    }
}

