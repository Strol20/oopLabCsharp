namespace oop_lab3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            обєктиToolStripMenuItem = new ToolStripMenuItem();
            крапкаToolStripMenuItem = new ToolStripMenuItem();
            лініяToolStripMenuItem = new ToolStripMenuItem();
            прямокутникToolStripMenuItem = new ToolStripMenuItem();
            еліпсToolStripMenuItem = new ToolStripMenuItem();
            довідкаToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, обєктиToolStripMenuItem, довідкаToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(640, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(59, 24);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // обєктиToolStripMenuItem
            // 
            обєктиToolStripMenuItem.Checked = true;
            обєктиToolStripMenuItem.CheckState = CheckState.Checked;
            обєктиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { крапкаToolStripMenuItem, лініяToolStripMenuItem, прямокутникToolStripMenuItem, еліпсToolStripMenuItem });
            обєктиToolStripMenuItem.Name = "обєктиToolStripMenuItem";
            обєктиToolStripMenuItem.Size = new Size(75, 24);
            обєктиToolStripMenuItem.Text = "Об'єкти";
            // 
            // крапкаToolStripMenuItem
            // 
            крапкаToolStripMenuItem.CheckOnClick = true;
            крапкаToolStripMenuItem.Name = "крапкаToolStripMenuItem";
            крапкаToolStripMenuItem.Size = new Size(224, 26);
            крапкаToolStripMenuItem.Text = "Крапка";
            крапкаToolStripMenuItem.ToolTipText = "Малює чорну крапку";
            крапкаToolStripMenuItem.Click += toolStripMenuItem_Click;
            // 
            // лініяToolStripMenuItem
            // 
            лініяToolStripMenuItem.CheckOnClick = true;
            лініяToolStripMenuItem.Name = "лініяToolStripMenuItem";
            лініяToolStripMenuItem.Size = new Size(224, 26);
            лініяToolStripMenuItem.Text = "Лінія";
            лініяToolStripMenuItem.ToolTipText = "Малює чорну лінію";
            лініяToolStripMenuItem.Click += toolStripMenuItem_Click;
            // 
            // прямокутникToolStripMenuItem
            // 
            прямокутникToolStripMenuItem.CheckOnClick = true;
            прямокутникToolStripMenuItem.Name = "прямокутникToolStripMenuItem";
            прямокутникToolStripMenuItem.Size = new Size(224, 26);
            прямокутникToolStripMenuItem.Text = "Прямокутник";
            прямокутникToolStripMenuItem.ToolTipText = "Малює оранжевий прямокутник";
            прямокутникToolStripMenuItem.Click += toolStripMenuItem_Click;
            // 
            // еліпсToolStripMenuItem
            // 
            еліпсToolStripMenuItem.CheckOnClick = true;
            еліпсToolStripMenuItem.Name = "еліпсToolStripMenuItem";
            еліпсToolStripMenuItem.Size = new Size(224, 26);
            еліпсToolStripMenuItem.Text = "Еліпс";
            еліпсToolStripMenuItem.ToolTipText = "Малює пустий, синій еліпс";
            еліпсToolStripMenuItem.Click += toolStripMenuItem_Click;
            // 
            // довідкаToolStripMenuItem
            // 
            довідкаToolStripMenuItem.Name = "довідкаToolStripMenuItem";
            довідкаToolStripMenuItem.Size = new Size(77, 24);
            довідкаToolStripMenuItem.Text = "Довідка";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 360);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2, 2, 2, 2);
            Name = "Form1";
            Text = "Form1";
            Paint += Form1_Paint;
            MouseDown += Form1_MouseDown;
            MouseMove += Form1_MouseMove;
            MouseUp += Form1_MouseUp;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem обєктиToolStripMenuItem;
        private ToolStripMenuItem крапкаToolStripMenuItem;
        private ToolStripMenuItem лініяToolStripMenuItem;
        private ToolStripMenuItem прямокутникToolStripMenuItem;
        private ToolStripMenuItem еліпсToolStripMenuItem;
        private ToolStripMenuItem довідкаToolStripMenuItem;
    }
}
