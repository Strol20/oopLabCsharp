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
            int radius = 10;    
            int diameter = radius * 2;
            SolidBrush redBrush = new SolidBrush(Color.Red);
            // Fill ellipse on screen.
            g.FillEllipse(new SolidBrush(colorPaint), x2 - radius, y2 - radius, diameter, diameter);
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

    internal class RectangleShape : Shape // Прямокутник // TODO: Окремий метод для розрахунків координатів
    {
        public override void Draw(Graphics g)
        {
            // Используем сохраненные в Set() координаты для рисования
            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);

            g.DrawRectangle(new Pen(colorPaint), x1-dx,y1-dy, 2*dx, 2*dy);
        }
    }

    internal class EllipseShape : Shape // TODO: Окремий метод для розрахунків координатів
    {
        public override void Draw(Graphics g) // Еліпс
        {
            // Используем сохраненные в Set() координаты для рисования
            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);
            g.DrawEllipse(new Pen(colorPaint), x1 - dx, y1 - dy, 2 * dx, 2 * dy);
        }
    }
}


