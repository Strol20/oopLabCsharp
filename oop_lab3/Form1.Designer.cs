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
            fileToolStripMenuItem = new ToolStripMenuItem();
            objectToolStripMenuItem = new ToolStripMenuItem();
            pointToolStripMenuItem = new ToolStripMenuItem();
            lineToolStripMenuItem = new ToolStripMenuItem();
            regectalesToolStripMenuItem = new ToolStripMenuItem();
            elipseToolStripMenuItem = new ToolStripMenuItem();
            tipsToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, objectToolStripMenuItem, tipsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(640, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(59, 24);
            fileToolStripMenuItem.Text = "Файл";
            // 
            // objectToolStripMenuItem
            // 
            objectToolStripMenuItem.Checked = true;
            objectToolStripMenuItem.CheckState = CheckState.Checked;
            objectToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pointToolStripMenuItem, lineToolStripMenuItem, regectalesToolStripMenuItem, elipseToolStripMenuItem });
            objectToolStripMenuItem.Name = "objectToolStripMenuItem";
            objectToolStripMenuItem.Size = new Size(75, 24);
            objectToolStripMenuItem.Text = "Об'єкти";
            // 
            // pointToolStripMenuItem
            // 
            pointToolStripMenuItem.CheckOnClick = true;
            pointToolStripMenuItem.Name = "pointToolStripMenuItem";
            pointToolStripMenuItem.Size = new Size(224, 26);
            pointToolStripMenuItem.Text = "Крапка";
            pointToolStripMenuItem.ToolTipText = "Малює чорну крапку";
            pointToolStripMenuItem.Click += toolStripMenuItem_Click;
            // 
            // lineToolStripMenuItem
            // 
            lineToolStripMenuItem.CheckOnClick = true;
            lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            lineToolStripMenuItem.Size = new Size(224, 26);
            lineToolStripMenuItem.Text = "Лінія";
            lineToolStripMenuItem.ToolTipText = "Малює чорну лінію";
            lineToolStripMenuItem.Click += toolStripMenuItem_Click;
            // 
            // regectalesToolStripMenuItem
            // 
            regectalesToolStripMenuItem.CheckOnClick = true;
            regectalesToolStripMenuItem.Name = "regectalesToolStripMenuItem";
            regectalesToolStripMenuItem.Size = new Size(224, 26);
            regectalesToolStripMenuItem.Text = "Прямокутник";
            regectalesToolStripMenuItem.ToolTipText = "Малює оранжевий прямокутник";
            regectalesToolStripMenuItem.Click += toolStripMenuItem_Click;
            // 
            // elipseToolStripMenuItem
            // 
            elipseToolStripMenuItem.CheckOnClick = true;
            elipseToolStripMenuItem.Name = "elipseToolStripMenuItem";
            elipseToolStripMenuItem.Size = new Size(224, 26);
            elipseToolStripMenuItem.Text = "Еліпс";
            elipseToolStripMenuItem.ToolTipText = "Малює пустий, синій еліпс";
            elipseToolStripMenuItem.Click += toolStripMenuItem_Click;
            // 
            // tipsToolStripMenuItem
            // 
            tipsToolStripMenuItem.Name = "tipsToolStripMenuItem";
            tipsToolStripMenuItem.Size = new Size(77, 24);
            tipsToolStripMenuItem.Text = "Довідка";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 360);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2);
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
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem objectToolStripMenuItem;
        private ToolStripMenuItem pointToolStripMenuItem;
        private ToolStripMenuItem lineToolStripMenuItem;
        private ToolStripMenuItem regectalesToolStripMenuItem;
        private ToolStripMenuItem elipseToolStripMenuItem;
        private ToolStripMenuItem tipsToolStripMenuItem;
    }
}
