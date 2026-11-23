using oop_lab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace oop_lab
{
    public class myEditor
    {
        // 1. Глобальний статичний об'єкт для непарного варіанта (№21)
        //Singeltone
        private static myEditor _instance;

        private myEditor() 
        { }

        public static myEditor getInstance()
        {
            if (_instance == null)
                _instance = new myEditor();
            return _instance;
        }

        // 2. Стан редактора (перенесено з Form1)
        Point click;
        Point currentPoint;
        bool isDrawing = false; // Чи малюємо зараз лінію чи ні

        private string currentShapePrototype = "DotShape";
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
        public void MouseDown(MouseEventArgs e, Control canvas)
        {

                isDrawing = true;
                click = e.Location;
                currentPoint = e.Location;
                currentDrawingShape = CreateShapeInstance(currentShapePrototype);
                canvas.Invalidate();
        }

        public void MouseUp(MouseEventArgs e, Control canvas)
        {
                currentPoint = e.Location;

                currentDrawingShape.SetCoordinates(click.X, click.Y, currentPoint.X, currentPoint.Y);

                // TODO: Новий методля для обмеження динамічного масиву
                AddShapeToDynamicArray(currentDrawingShape);
                currentDrawingShape = null;
                isDrawing = false;

                canvas.Invalidate();

        }
        public void MouseMove(MouseEventArgs e, Control canvas)
        {
            if (isDrawing)
            {
                currentPoint = e.Location;
                canvas.Invalidate(); // Запрашиваем перерисовку кадра (для показа превью)


            }
        }

        public Shape CreateShapeInstance(string shapeTemplate)
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

        public void Form1_Paint(object sender, PaintEventArgs e)
        {
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
    }
}
