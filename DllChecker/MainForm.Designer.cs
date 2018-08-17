namespace DllChecker
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
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.MainStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.ProgressLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DebugPathButton = new System.Windows.Forms.Button();
            this.ReleasePathButton = new System.Windows.Forms.Button();
            this.SnapshotPathButton = new System.Windows.Forms.Button();
            this.SrcPathButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DebugDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.ReleaseDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.SnapshotDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.SrcDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.DecompileButton = new System.Windows.Forms.Button();
            this.ClipboardButton = new System.Windows.Forms.Button();
            this.CheckButton = new System.Windows.Forms.Button();
            this.InfoListBox = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.SrcDirLabel = new System.Windows.Forms.Label();
            this.OldRichTextBox = new System.Windows.Forms.RichTextBox();
            this.ProbeDirLabel = new System.Windows.Forms.Label();
            this.NewRichTextBox = new System.Windows.Forms.RichTextBox();
            this.MainStatusStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainStatusLabel,
            this.MainProgressBar,
            this.ProgressLabel});
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 674);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(1110, 25);
            this.MainStatusStrip.TabIndex = 9;
            this.MainStatusStrip.Text = "statusStrip1";
            // 
            // MainStatusLabel
            // 
            this.MainStatusLabel.AutoSize = false;
            this.MainStatusLabel.Name = "MainStatusLabel";
            this.MainStatusLabel.Size = new System.Drawing.Size(300, 20);
            this.MainStatusLabel.Text = "Проверка...";
            this.MainStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainProgressBar
            // 
            this.MainProgressBar.Name = "MainProgressBar";
            this.MainProgressBar.Size = new System.Drawing.Size(200, 19);
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.AutoSize = false;
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(50, 20);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1110, 674);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DebugPathButton);
            this.tabPage1.Controls.Add(this.ReleasePathButton);
            this.tabPage1.Controls.Add(this.SnapshotPathButton);
            this.tabPage1.Controls.Add(this.SrcPathButton);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.DebugDirectoryTextBox);
            this.tabPage1.Controls.Add(this.ReleaseDirectoryTextBox);
            this.tabPage1.Controls.Add(this.SnapshotDirectoryTextBox);
            this.tabPage1.Controls.Add(this.SrcDirectoryTextBox);
            this.tabPage1.Controls.Add(this.DecompileButton);
            this.tabPage1.Controls.Add(this.ClipboardButton);
            this.tabPage1.Controls.Add(this.CheckButton);
            this.tabPage1.Controls.Add(this.InfoListBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage1.Size = new System.Drawing.Size(1102, 648);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "DllCheck";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DebugPathButton
            // 
            this.DebugPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DebugPathButton.Location = new System.Drawing.Point(1061, 81);
            this.DebugPathButton.Name = "DebugPathButton";
            this.DebugPathButton.Size = new System.Drawing.Size(33, 23);
            this.DebugPathButton.TabIndex = 24;
            this.DebugPathButton.Text = "...";
            this.DebugPathButton.UseVisualStyleBackColor = true;
            this.DebugPathButton.Click += new System.EventHandler(this.DebugPathButtonClick);
            // 
            // ReleasePathButton
            // 
            this.ReleasePathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ReleasePathButton.Location = new System.Drawing.Point(1061, 56);
            this.ReleasePathButton.Name = "ReleasePathButton";
            this.ReleasePathButton.Size = new System.Drawing.Size(33, 23);
            this.ReleasePathButton.TabIndex = 23;
            this.ReleasePathButton.Text = "...";
            this.ReleasePathButton.UseVisualStyleBackColor = true;
            this.ReleasePathButton.Click += new System.EventHandler(this.ReleasePathButtonClick);
            // 
            // SnapshotPathButton
            // 
            this.SnapshotPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SnapshotPathButton.Location = new System.Drawing.Point(1061, 31);
            this.SnapshotPathButton.Name = "SnapshotPathButton";
            this.SnapshotPathButton.Size = new System.Drawing.Size(33, 23);
            this.SnapshotPathButton.TabIndex = 22;
            this.SnapshotPathButton.Text = "...";
            this.SnapshotPathButton.UseVisualStyleBackColor = true;
            this.SnapshotPathButton.Click += new System.EventHandler(this.SnapshotPathButtonClick);
            // 
            // SrcPathButton
            // 
            this.SrcPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SrcPathButton.Location = new System.Drawing.Point(1061, 6);
            this.SrcPathButton.Name = "SrcPathButton";
            this.SrcPathButton.Size = new System.Drawing.Size(33, 23);
            this.SrcPathButton.TabIndex = 21;
            this.SrcPathButton.Text = "...";
            this.SrcPathButton.UseVisualStyleBackColor = true;
            this.SrcPathButton.Click += new System.EventHandler(this.SrcPathButtonClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(93, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Build as \"DEBUG\"";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Build as \"RELEASE\"";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Snapshot path";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Sourse path";
            // 
            // DebugDirectoryTextBox
            // 
            this.DebugDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DebugDirectoryTextBox.Location = new System.Drawing.Point(201, 83);
            this.DebugDirectoryTextBox.Name = "DebugDirectoryTextBox";
            this.DebugDirectoryTextBox.Size = new System.Drawing.Size(854, 20);
            this.DebugDirectoryTextBox.TabIndex = 16;
            // 
            // ReleaseDirectoryTextBox
            // 
            this.ReleaseDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReleaseDirectoryTextBox.Location = new System.Drawing.Point(201, 58);
            this.ReleaseDirectoryTextBox.Name = "ReleaseDirectoryTextBox";
            this.ReleaseDirectoryTextBox.Size = new System.Drawing.Size(854, 20);
            this.ReleaseDirectoryTextBox.TabIndex = 15;
            // 
            // SnapshotDirectoryTextBox
            // 
            this.SnapshotDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SnapshotDirectoryTextBox.Location = new System.Drawing.Point(200, 33);
            this.SnapshotDirectoryTextBox.Name = "SnapshotDirectoryTextBox";
            this.SnapshotDirectoryTextBox.Size = new System.Drawing.Size(855, 20);
            this.SnapshotDirectoryTextBox.TabIndex = 14;
            // 
            // SrcDirectoryTextBox
            // 
            this.SrcDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SrcDirectoryTextBox.Location = new System.Drawing.Point(200, 8);
            this.SrcDirectoryTextBox.Name = "SrcDirectoryTextBox";
            this.SrcDirectoryTextBox.Size = new System.Drawing.Size(855, 20);
            this.SrcDirectoryTextBox.TabIndex = 13;
            // 
            // DecompileButton
            // 
            this.DecompileButton.Location = new System.Drawing.Point(6, 44);
            this.DecompileButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DecompileButton.Name = "DecompileButton";
            this.DecompileButton.Size = new System.Drawing.Size(74, 23);
            this.DecompileButton.TabIndex = 12;
            this.DecompileButton.Text = "Decompile";
            this.DecompileButton.UseVisualStyleBackColor = true;
            this.DecompileButton.Click += new System.EventHandler(this.DecompileButtonClick1);
            // 
            // ClipboardButton
            // 
            this.ClipboardButton.Location = new System.Drawing.Point(5, 73);
            this.ClipboardButton.Name = "ClipboardButton";
            this.ClipboardButton.Size = new System.Drawing.Size(75, 23);
            this.ClipboardButton.TabIndex = 11;
            this.ClipboardButton.Text = "Clipboard";
            this.ClipboardButton.UseVisualStyleBackColor = true;
            this.ClipboardButton.Click += new System.EventHandler(this.ClipboardButtonClick);
            // 
            // CheckButton
            // 
            this.CheckButton.Location = new System.Drawing.Point(6, 15);
            this.CheckButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CheckButton.Name = "CheckButton";
            this.CheckButton.Size = new System.Drawing.Size(74, 23);
            this.CheckButton.TabIndex = 0;
            this.CheckButton.Text = "Check";
            this.CheckButton.UseVisualStyleBackColor = true;
            this.CheckButton.Click += new System.EventHandler(this.CheckButtonClick);
            // 
            // InfoListBox
            // 
            this.InfoListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InfoListBox.FormattingEnabled = true;
            this.InfoListBox.Location = new System.Drawing.Point(7, 110);
            this.InfoListBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.InfoListBox.Name = "InfoListBox";
            this.InfoListBox.Size = new System.Drawing.Size(1088, 524);
            this.InfoListBox.TabIndex = 10;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage2.Size = new System.Drawing.Size(1102, 648);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Decompile";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(4, 6);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.SrcDirLabel);
            this.splitContainer1.Panel1.Controls.Add(this.OldRichTextBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ProbeDirLabel);
            this.splitContainer1.Panel2.Controls.Add(this.NewRichTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(1091, 643);
            this.splitContainer1.SplitterDistance = 541;
            this.splitContainer1.TabIndex = 6;
            // 
            // SrcDirLabel
            // 
            this.SrcDirLabel.AutoSize = true;
            this.SrcDirLabel.Location = new System.Drawing.Point(4, 3);
            this.SrcDirLabel.Name = "SrcDirLabel";
            this.SrcDirLabel.Size = new System.Drawing.Size(23, 13);
            this.SrcDirLabel.TabIndex = 8;
            this.SrcDirLabel.Text = "Src";
            // 
            // OldRichTextBox
            // 
            this.OldRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OldRichTextBox.Location = new System.Drawing.Point(4, 22);
            this.OldRichTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.OldRichTextBox.Name = "OldRichTextBox";
            this.OldRichTextBox.Size = new System.Drawing.Size(532, 614);
            this.OldRichTextBox.TabIndex = 1;
            this.OldRichTextBox.Text = "";
            this.OldRichTextBox.WordWrap = false;
            // 
            // ProbeDirLabel
            // 
            this.ProbeDirLabel.AutoSize = true;
            this.ProbeDirLabel.Location = new System.Drawing.Point(4, 3);
            this.ProbeDirLabel.Name = "ProbeDirLabel";
            this.ProbeDirLabel.Size = new System.Drawing.Size(35, 13);
            this.ProbeDirLabel.TabIndex = 7;
            this.ProbeDirLabel.Text = "Probe";
            // 
            // NewRichTextBox
            // 
            this.NewRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewRichTextBox.Location = new System.Drawing.Point(5, 22);
            this.NewRichTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.NewRichTextBox.Name = "NewRichTextBox";
            this.NewRichTextBox.Size = new System.Drawing.Size(537, 613);
            this.NewRichTextBox.TabIndex = 1;
            this.NewRichTextBox.Text = "";
            this.NewRichTextBox.WordWrap = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 699);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.MainStatusStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MainForm";
            this.Text = "DllChecker";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.MainStatusStrip.ResumeLayout(false);
            this.MainStatusStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel MainStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar MainProgressBar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripStatusLabel ProgressLabel;
        private System.Windows.Forms.RichTextBox OldRichTextBox;
        private System.Windows.Forms.RichTextBox NewRichTextBox;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button DecompileButton;
        private System.Windows.Forms.Button ClipboardButton;
        private System.Windows.Forms.Button CheckButton;
        private System.Windows.Forms.ListBox InfoListBox;
        private System.Windows.Forms.Label ProbeDirLabel;
        private System.Windows.Forms.Label SrcDirLabel;
        private System.Windows.Forms.TextBox DebugDirectoryTextBox;
        private System.Windows.Forms.TextBox ReleaseDirectoryTextBox;
        private System.Windows.Forms.TextBox SnapshotDirectoryTextBox;
        private System.Windows.Forms.TextBox SrcDirectoryTextBox;
        private System.Windows.Forms.Button DebugPathButton;
        private System.Windows.Forms.Button ReleasePathButton;
        private System.Windows.Forms.Button SnapshotPathButton;
        private System.Windows.Forms.Button SrcPathButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}

