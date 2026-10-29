using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab2
{
    public abstract class Shape //Клас для форм 
    {
        protected int x1, y1, x2, y2;
        protected Color colorPaint;
        protected bool isDrawing;

        public void SetCoordinates(int x1, int y1, int x2, int y2, bool isDrawing) // для кординат
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.isDrawing = isDrawing;
        }

        protected (Pen, Brush) GetPenAndBrush(bool isTemporary, Color defaultFillColor)
        {
            if (isTemporary)
            {
                // "Резиновый" след: сплошная красная линия (Ж mod 4 = 1 для варианта 21)
                // Для превью используем полупрозрачный красный цвет заливки
                Pen tempPen = new Pen(Color.Red, 1) { DashStyle = DashStyle.Solid };
                Brush tempBrush = new SolidBrush(defaultFillColor);
                return (tempPen, tempBrush);
            }
            else
            {
                // Финальная отрисовка: черный контур + цветная заливка
                Pen mainPen = new Pen(Color.Black, 1);
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
            Color fillColor = isDrawing ? Color.Black : Color.Red;
            var (pen, brush) = GetPenAndBrush(isTemporary, fillColor);
            int diameter = 20;
            int radius = diameter / 2;    
            g.FillEllipse(brush, x2 - radius, y2 - radius, diameter, diameter);
            // Для країв точно такеж, але DrawEllipse і т.д.
        }
    }

    internal class LineShape : Shape // Лінія 
    {
        public override void Draw(Graphics g, bool isTemporary = false)
        {
            // Используем сохраненные в Set() координаты для рисования
            var (pen, brush) = GetPenAndBrush(isTemporary, colorPaint);
            g.DrawLine(pen, x1, y1, x2, y2);
        }
    }

    internal class RectangleShape : Shape // Прямокутник // TODO: Окремий метод для розрахунків координатів
    {
        public override void Draw(Graphics g, bool isTemporary = false)
        {

            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);
            Color fillColor = isDrawing ? Color.Pink : Color.Transparent;

            var (pen, brush) = GetPenAndBrush(isTemporary, fillColor);//ХУЙНЯ
            g.FillRectangle(brush, x1 - dx, y1 - dy, 2 * dx, 2 * dy);
            g.DrawRectangle(pen, x1-dx,y1-dy, 2*dx, 2*dy);
        }
    }

    internal class EllipseShape : Shape // TODO: Окремий метод для розрахунків координатів
    {
        public override void Draw(Graphics g, bool isTemporary = false) // Еліпс
        {
            Color fillColor = isDrawing ? Color.White : Color.Transparent;
            var (pen, brush) = GetPenAndBrush(isTemporary, fillColor);
            g.FillEllipse(brush, x1, y1, x2 - x1, y2 - y1);
            g.DrawEllipse(pen, x1, y1, x2-x1, y2-y1);
        }
    }
}


