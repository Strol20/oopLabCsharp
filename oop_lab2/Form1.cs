using System;
using System.Net;
using System.Windows.Forms;
namespace oop_lab2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }
        Point click;
        Point currentPoint;
        bool isDrawing = false; // Чи малюємо зараз лінію чи ні
        List<Shape> pcshape = new List<Shape>(); // Список фігур, які ми малюємо на формі Окремий метод 
        string currentShapeTemplate = "DotShape";
        private Shape currentDrawingShape = null;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            // Не робе. Із за пари строчик коду, заважало виправити мерцання навіть з DoubleBuffered = true;
            //Graphics g;
            //g = CreateGraphics();

            Graphics g = e.Graphics;
            foreach (var shape in pcshape)
            {
                shape.Draw(g);
            }
            if (isDrawing)
            {
                currentDrawingShape.SetCoordinates(click.X, click.Y, currentPoint.X, currentPoint.Y);
                currentDrawingShape.Draw(g, isDrawing);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                click = e.Location;
                currentPoint = e.Location;
                currentDrawingShape = CreateShapeInstance(currentShapeTemplate);
                this.Invalidate();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentPoint = e.Location;

                currentDrawingShape.SetCoordinates(click.X, click.Y, currentPoint.X, currentPoint.Y);

                // TODO: Новий методля для обмеження динамічного масиву
                pcshape.Add(currentDrawingShape);
                currentDrawingShape = null;
                isDrawing = false;

                this.Invalidate();
            }

        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                currentPoint = e.Location;
                this.Invalidate(); // Запрашиваем перерисовку кадра (для показа превью)


            }
        }

        private Shape CreateShapeInstance(string shapeTemplate)
        {
            if (shapeTemplate == "DotShape")
                return new DotShape();
            else if (shapeTemplate == "LineShape")
                return new LineShape();
            else if (shapeTemplate == "RectangleShape")
                return new RectangleShape();
            else if (shapeTemplate == "EllipseShape")
                return new EllipseShape();
            else
                throw new InvalidOperationException("Unknown shape type");
        }

        //private void curentColor(string shapeTemplate, bool isDrawing ) {
        //    if (shapeTemplate == "DotShape")
        //        return Color;
        //    else if (shapeTemplate == "LineShape")
        //        return new LineShape();
        //    else if (shapeTemplate == "RectangleShape")
        //        return new RectangleShape();
        //    else if (shapeTemplate == "EllipseShape")
        //        return new EllipseShape();
        //    else
        //        throw new InvalidOperationException("Unknown shape type");
        //}

        // Аля RadioButton для ToolStripMenuItem
        private void крапкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var clickedItem = sender as ToolStripMenuItem;
            // Знімаємо вибір з усіньких інших пунктів меню після кліку 
            foreach (ToolStripItem item in clickedItem.GetCurrentParent().Items)
            {
                if (item is ToolStripMenuItem menuItem && item != clickedItem)
                {
                    menuItem.Checked = false;
                    Console.WriteLine(menuItem);
                }
            }

            if (clickedItem != null)
            {
                // Перевіряємо, яка кнопка була натиснута
                switch (clickedItem.Text)
                {
                    case "Крапка":
                        currentShapeTemplate = "DotShape";
                        break;

                    case "Лінія":
                        currentShapeTemplate = "LineShape";
                        break;

                    case "Прямокутник":
                        currentShapeTemplate = "RectangleShape";
                        break;

                    case "Еліпс":
                        currentShapeTemplate = "EllipseShape";
                        break;
                }

                // Вивід назви вибраної кнопки у заголовок форми
                this.Text = "Графічний редактор - " + clickedItem.Text;

                //Встановлюємо прапорець для вибраного пункту меню
                clickedItem.Checked = true;
            }
        }
    }
}