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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            objectToolStripMenuItem = new ToolStripMenuItem();
            pointToolStripMenuItem = new ToolStripMenuItem();
            lineToolStripMenuItem = new ToolStripMenuItem();
            regectalesToolStripMenuItem = new ToolStripMenuItem();
            elipseToolStripMenuItem = new ToolStripMenuItem();
            tipsToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            toolStripButton4 = new ToolStripButton();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
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
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton2, toolStripButton3, toolStripButton4 });
            toolStrip1.Location = new Point(0, 28);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(640, 27);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(29, 24);
            toolStripButton1.Text = "Крапка";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(29, 24);
            toolStripButton2.Text = "Лінія";
            toolStripButton2.Click += toolStripButton1_Click;
            // 
            // toolStripButton3
            // 
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(29, 24);
            toolStripButton3.Text = "Прямокутник";
            toolStripButton3.Click += toolStripButton1_Click;
            // 
            // toolStripButton4
            // 
            toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton4.Image = (Image)resources.GetObject("toolStripButton4.Image");
            toolStripButton4.ImageTransparentColor = Color.Magenta;
            toolStripButton4.Name = "toolStripButton4";
            toolStripButton4.Size = new Size(29, 24);
            toolStripButton4.Text = "Еліпс";
            toolStripButton4.Click += toolStripButton1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 360);
            Controls.Add(toolStrip1);
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
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
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
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
    }
}
