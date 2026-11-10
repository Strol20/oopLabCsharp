using System;
using System.Net;
using System.Windows.Forms;
namespace oop_lab3
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
        string currentShapeTemplate = "DotShape";
        private Shape currentDrawingShape = null;
        private const int N = 122;
        private Shape[] pcshape = new Shape[N];
        private int shapeCount = 0;
        private bool AddShapeToDynamicArray(Shape shape)
        {
            if (shape == null) return false;

            if (shapeCount < N)
            {
                pcshape[shapeCount] = shape;
                shapeCount++;
                return true;
            }
            else
            {
                MessageBox.Show($"Досягнуто максимальний ліміт елементів масиву (N = {N})!",
                                "Помилка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return false;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            // Не робе. Із за пари строчик коду, заважало виправити мерцання навіть з DoubleBuffered = true;
            //Graphics g;
            //g = CreateGraphics();

            Graphics g = e.Graphics;
            for (int i = 0; i < shapeCount; i++)
            {
                if (pcshape[i] != null)
                {
                    pcshape[i].Draw(g);
                }
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
                AddShapeToDynamicArray(currentDrawingShape);
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
        //Метод для вибору форми малювання і для оновлення стану кнопок та пунктів меню
        private void SelectShape(string shapeName)
        {
            // Встановлюємо шаблон малювання
            switch (shapeName)
            {
                case "Крапка": currentShapeTemplate = "DotShape"; break;
                case "Лінія": currentShapeTemplate = "LineShape"; break;
                case "Прямокутник": currentShapeTemplate = "RectangleShape"; break;
                case "Еліпс": currentShapeTemplate = "EllipseShape"; break;
                default: currentShapeTemplate = "DotShape"; break;
            }

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