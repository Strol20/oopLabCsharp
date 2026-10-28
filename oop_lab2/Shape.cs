using oop_lab2;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab2
{
    public abstract class Shape //Клас для форм 
    {
        protected int x1, y1, x2, y2;
        protected Color colorPaint;

        public void SetCoordinates(int x1, int y1, int x2, int y2, Color colorPaint) // для кординат
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.colorPaint = colorPaint;
        }
        public abstract void Draw(Graphics g);
    }

    internal class DotShape : Shape // Крапка
    {
        public override void Draw(Graphics g)
        {
            g.DrawEllipse(new Pen(colorPaint), x2 + 10, y2 + 10, x2 - 10, y2 - 10);
        }
    }

    internal class LineShape : Shape // Лінія 
    {
        public override void Draw(Graphics g)
        {
            // Используем сохраненные в Set() координаты для рисования
            g.DrawLine(new Pen(colorPaint), x1, y1, x2, y2);
        }
    }

    internal class RectangleShape : Shape // Прямокутник
    {
        public override void Draw(Graphics g)
        {
            // Используем сохраненные в Set() координаты для рисования
            int width = Math.Abs(x2 - x1);
            int height = Math.Abs(y2 - y1);
            int x = Math.Min(x1, x2);
            int y = Math.Min(y1, y2);

            g.DrawRectangle(new Pen(colorPaint), x, y, width, height);
        }
    }

    internal class EllipseShape : Shape
    {
        public override void Draw(Graphics g) // Еліпс
        {
            // Используем сохраненные в Set() координаты для рисования
            int width = Math.Abs(x2 - x1);
            int height = Math.Abs(y2 - y1);
            int x = Math.Min(x1, x2);
            int y = Math.Min(y1, y2);
            g.DrawEllipse(new Pen(colorPaint), x, y, width, height);
        }
    }
}


