using System;
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
        List<Shape> pcshape = new List<Shape>(); // Список фігур, які ми малюємо на формі
        Shape currentShapeTemplate = new DotShape();


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g;
            g = CreateGraphics();
            g.DrawLine(Pens.Gray, 100, 100, 500, 100);
            foreach (var shape in pcshape)
            {
                //shape.Draw(g); // TODO: Замінити на DrawShape
            }
            if (isDrawing)
            {

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
                isDrawing = false;
                currentPoint = e.Location;
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
            currentShapeTemplate = new DotShape();
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
                        currentShapeTemplate = new DotShape();
                        break;

                    case "Лінія":
                        currentShapeTemplate = new LineShape();
                        break;

                    case "Прямокутник":
                        currentShapeTemplate = new RectangleShape();
                        break;

                    case "Еліпс":
                        currentShapeTemplate = new EllipseShape();
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