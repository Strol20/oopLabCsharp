using System;
using System.Net;
using System.Windows.Forms;
namespace oop_lab
{
    public partial class Form1 : Form
    {
        myEditor editor = myEditor.getInstance();
        public Form1()
        {
            myEditor.getInstance();
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Не робе. Із за пари строчик коду, заважало виправити мерцання навіть з DoubleBuffered = true;
            //Graphics g;
            //g = CreateGraphics();
            Graphics g = e.Graphics;
            editor.paint(sender, e);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
            editor.MouseDown(e, this);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                editor.MouseUp(e, this);
            }
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            editor.MouseMove(e, this);
        }



        //Метод для вибору форми малювання і для оновлення стану кнопок та пунктів меню
        private void SelectShape(string shapeName)
        {
            // Встановлюємо шаблон малювання
            editor.SetShape(shapeName);

            this.Text = "Графічний редактор - " + shapeName;

            // Оновлюємо галочки на ToolStrip
            if (toolStrip1 != null)
            {
                foreach (ToolStripItem item in toolStrip1.Items)
                {
                    if (item is ToolStripButton btn)
                    {
                         btn.Checked = (btn.Text == shapeName);
                    }
                }
            }
            // Оновлюємо галочки в MenuStrip
            if (objectToolStripMenuItem != null)
            {
                // ТІЛЬКИ objectToolStripMenuItem
                foreach (ToolStripItem item in objectToolStripMenuItem.DropDownItems)
                {
                    if (item is ToolStripMenuItem menuItem)
                    {
                            menuItem.Checked = (menuItem.Text == shapeName);
                    }
                }
            }
        }


        // Обробник кліків кнопок і пунктів меню 
        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem clickedItem)
            {
                SelectShape(clickedItem.Text); 
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripButton clickedItem)
            {
                SelectShape(clickedItem.Text); 
            }
        }
    }
}