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

        }
        Point click;
        Point currentPoint;
        bool isDrawing = false; // Чи малюємо зараз лінію чи ні
        List<Shape> pcshape = new List<Shape>(); // Список фігур, які ми малюємо на формі
        string currentShapeTemplate = "DotShape";


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g;
            g = CreateGraphics();
            g.DrawLine(Pens.Gray, 100, 100, 500, 100);
            foreach (var shape in pcshape)
            {
                shape.Draw(g); // TODO: Замінити на DrawShape
            }
            if (isDrawing)
            {
                Shape tempShape = CreateShapeInstance(currentShapeTemplate);
                DrawShape(g, tempShape, click, currentPoint);
                //g.DrawLine(Pens.Black, click.X, click.Y, currentPoint.X, currentPoint.Y);// TODO: Замінити на DrawShape
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                click = e.Location;

            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentPoint = e.Location;
                Shape newShape = CreateShapeInstance(currentShapeTemplate);

                newShape.SetCoordinates(click.X, click.Y, currentPoint.X, currentPoint.Y, Color.Black);

                // Сохраняем в список готовых фигур
                pcshape.Add(newShape);
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
            // Создаем новый экземпляр фигуры на основе текущего шаблона
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

        private void DrawShape(Graphics g, Shape shape, Point startPoint, Point endPoint)
        {
            // Встановлюємо координати фігури
            shape.SetCoordinates(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y, Color.Black);
            // Малюємо фігуру
            shape.Draw(g);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Встановлюємо початковий шаблон фігури (наприклад, крапка)
            currentShapeTemplate = "DotShape";
        }

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
                // Перевіряємо, яка кнопка була натиснута, і створюємо відповідний шаблон фігури
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