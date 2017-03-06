namespace PostTracks
{
    partial class MainForm
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
            this.tb_TrackCode = new System.Windows.Forms.TextBox();
            this.rtb_TrackInformation = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tp_Track_JSON = new System.Windows.Forms.TabPage();
            this.btn_TrackJSONInformation = new System.Windows.Forms.Button();
            this.tp_Ali = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.tp_Track_JSON.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_TrackCode
            // 
            this.tb_TrackCode.Location = new System.Drawing.Point(3, 11);
            this.tb_TrackCode.Name = "tb_TrackCode";
            this.tb_TrackCode.Size = new System.Drawing.Size(237, 20);
            this.tb_TrackCode.TabIndex = 0;
            this.tb_TrackCode.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // rtb_TrackInformation
            // 
            this.rtb_TrackInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_TrackInformation.Location = new System.Drawing.Point(6, 40);
            this.rtb_TrackInformation.Name = "rtb_TrackInformation";
            this.rtb_TrackInformation.Size = new System.Drawing.Size(317, 365);
            this.rtb_TrackInformation.TabIndex = 1;
            this.rtb_TrackInformation.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(339, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tp_Track_JSON);
            this.tabControl.Controls.Add(this.tp_Ali);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(339, 470);
            this.tabControl.TabIndex = 3;
            // 
            // tp_Track_JSON
            // 
            this.tp_Track_JSON.Controls.Add(this.btn_TrackJSONInformation);
            this.tp_Track_JSON.Controls.Add(this.tb_TrackCode);
            this.tp_Track_JSON.Controls.Add(this.rtb_TrackInformation);
            this.tp_Track_JSON.Location = new System.Drawing.Point(4, 22);
            this.tp_Track_JSON.Name = "tp_Track_JSON";
            this.tp_Track_JSON.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Track_JSON.Size = new System.Drawing.Size(331, 444);
            this.tp_Track_JSON.TabIndex = 0;
            this.tp_Track_JSON.Text = "Track JSON";
            this.tp_Track_JSON.UseVisualStyleBackColor = true;
            // 
            // btn_TrackJSONInformation
            // 
            this.btn_TrackJSONInformation.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_TrackJSONInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_TrackJSONInformation.Location = new System.Drawing.Point(246, 6);
            this.btn_TrackJSONInformation.Name = "btn_TrackJSONInformation";
            this.btn_TrackJSONInformation.Size = new System.Drawing.Size(75, 28);
            this.btn_TrackJSONInformation.TabIndex = 2;
            this.btn_TrackJSONInformation.Text = "Track";
            this.btn_TrackJSONInformation.UseVisualStyleBackColor = false;
            this.btn_TrackJSONInformation.Click += new System.EventHandler(this.button1_Click);
            // 
            // tp_Ali
            // 
            this.tp_Ali.Location = new System.Drawing.Point(4, 22);
            this.tp_Ali.Name = "tp_Ali";
            this.tp_Ali.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Ali.Size = new System.Drawing.Size(331, 444);
            this.tp_Ali.TabIndex = 1;
            this.tp_Ali.Text = "Ali";
            this.tp_Ali.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 467);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "PostTrack";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.tp_Track_JSON.ResumeLayout(false);
            this.tp_Track_JSON.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_TrackCode;
        private System.Windows.Forms.RichTextBox rtb_TrackInformation;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tp_Track_JSON;
        private System.Windows.Forms.TabPage tp_Ali;
        private System.Windows.Forms.Button btn_TrackJSONInformation;
    }
}

