using System;
using System.Windows.Forms;
namespace oop_lab2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        Point click;
        Point currentPoint;
        bool isDrawing = false; // Чи малюємо зараз лінію чи ні
        List<Shape> pcshape = new List<Shape>(); // Список фігур, які ми малюємо на формі


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g;
            g = CreateGraphics();
            g.DrawLine(Pens.Gray, 100, 100, 500, 100);
            foreach (var shape in pcshape)
            {
                //shape.Draw(g);
            }
            if(isDrawing)
            {
                g.DrawLine(Pens.Black, click.X, click.Y, currentPoint.X, currentPoint.Y);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                click = e.Location;
                isDrawing = true;
                
            }
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                
                this.Invalidate(); // Запрашиваем перерисовку кадра (для показа превью)
                currentPoint = e.Location;

            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = false;
            }
            //if (isDrawing && e.Button == MouseButtons.Left)
            //{
            //    isDrawing = false;
            //    currentPoint = e.Location;

            //    // Фиксируем фигуру НАВСЕГДА на фоновом Bitmap
            //    DrawShape(canvasGraphics, startPoint, currentPoint);
            //    this.Invalidate();
            //}
        }

        // Аля RadioButton для ToolStripMenuItem
        private void крапкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var clickedItem = sender as ToolStripMenuItem;
            // Знімаємо вибір з усіньких інших пунктів меню після кліку 
            foreach (ToolStripItem item in clickedItem.GetCurrentParent().Items)
            {
                //
                if (item is ToolStripMenuItem menuItem && item != clickedItem)
                {
                    menuItem.Checked = false;
                    Console.WriteLine(menuItem);
                }
            }

            clickedItem.Checked = true; // Оставляем выбранным текущий
        }
    }
}
