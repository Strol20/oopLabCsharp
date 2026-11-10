using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab3
{
    public abstract class Shape //Клас для форм 
    {
        protected int x1, y1, x2, y2;
        protected Color colorPaint;


        public void SetCoordinates(int x1, int y1, int x2, int y2) // для кординат
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;

        }

        protected (Pen, Brush) GetPenAndBrush(bool isTemporary, Color defaultFillColor)// TODO: Перенести або прямо в Draw або в нормалізація
        {
            if (isTemporary)
            {
                // Карандашик тимчасовиий поки малюєш
                Pen tempPen = new Pen(Color.Blue, 1) { DashStyle = DashStyle.Solid };
                Brush tempBrush = new SolidBrush(defaultFillColor);
                return (tempPen, tempBrush);
            }
            else
            {
                // Для збереженя
                Pen mainPen = new Pen(Color.Black);
                Brush mainBrush = new SolidBrush(defaultFillColor);
                return (mainPen, mainBrush);
            }
        }

        public abstract void Draw(Graphics g, bool isTemporary = false);
    }

    internal class DotShape : Shape // Крапка
    {
        public override void Draw(Graphics g, bool isTemporary = false)
        {
            Color fillColor = isTemporary ? Color.Blue : Color.Black;
            var (pen, brush) = GetPenAndBrush(isTemporary, fillColor);
            int diameter = 20;
            int radius = diameter / 2;    
            g.FillEllipse(brush, x2 - radius, y2 - radius, diameter, diameter);
            // Для країв точно такеж, але DrawEllipse і т.д.
            pen.Dispose();
            brush.Dispose();
        }
    }

    internal class LineShape : Shape // Лінія 
    {
        public override void Draw(Graphics g, bool isTemporary = false)
        {
            var (pen, brush) = GetPenAndBrush(isTemporary, colorPaint);
            g.DrawLine(pen, x1, y1, x2, y2);
            pen.Dispose();
            brush.Dispose();
        }
    }

    internal class RectangleShape : Shape // Прямокутник // TODO: Окремий метод для розрахунків координатів
    {
        public override void Draw(Graphics g, bool isTemporary = false)
        {
            int x = Math.Min(x1, x2);
            int y = Math.Min(y1, y2);
            int width = Math.Abs(x2 - x1);
            int height = Math.Abs(y2 - y1);
            Color fillColor = isTemporary ? Color.Transparent : Color.Orange;
            var (pen, brush) = GetPenAndBrush(isTemporary, fillColor);
            g.FillRectangle(brush, x, y, width, height);
            g.DrawRectangle(pen, x, y, width, height);
            pen.Dispose();
            brush.Dispose();
        }
    }

    internal class EllipseShape : Shape // TODO: Окремий метод для розрахунків координатів
    {
        public override void Draw(Graphics g, bool isTemporary = false) // Еліпс
        {
            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);
            var (pen, brush) = GetPenAndBrush(isTemporary, colorPaint);
            g.DrawEllipse(pen, x1 - dx, y1 - dy, 2 * dx, 2 * dy);
            pen.Dispose();
            brush.Dispose();
        }
    }
}


