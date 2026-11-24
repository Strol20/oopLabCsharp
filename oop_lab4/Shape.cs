using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace oop_lab
{
    public abstract class Shape //Клас для форм 
    {
        protected int x1, y1, x2, y2;
        protected Color colorPaint;
        protected Color tempColorPen = Color.Blue;
        protected Color tempColorBrush = Color.Blue;
        protected Color mainColorPen = Color.Black;
        protected Color mainColorBrush = Color.Black;


        public void SetCoordinates(int x1, int y1, int x2, int y2) // для кординат
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;

        }

        public void SetColor(Color tempPen, Color tempBrush, Color mainPen , Color mainBrush) // для кольору
        {
            this.tempColorPen = tempPen;
            this.tempColorBrush = tempBrush;
            this.mainColorPen = mainPen;
            this.mainColorBrush = mainBrush;
        }

        protected (Pen, Brush) GetPenAndBrush(bool isTemporary)// Метод для отримання Pen та Brush
        {
            if (isTemporary)
            {
                // Карандашик тимчасовиий поки малюєш
                // Створив кастомний стиль, стандартний DashStyle не підходить, замалий розмір
                Pen tempPen = new Pen(tempColorPen, 2f);
                tempPen.DashStyle = DashStyle.Dash;
                Brush tempBrush = new SolidBrush(tempColorBrush);
                return (tempPen, tempBrush);
            }
            else
            {
                // Для збереженя
                Pen mainPen = new Pen(mainColorPen, 2f);
                Brush mainBrush = new SolidBrush(mainColorBrush);
                return (mainPen, mainBrush);
            }
        }

        public abstract void Draw(Graphics g, bool isTemporary = false);
    }

    internal class DotShape : Shape // Крапка
    {
        public DotShape()
        {
            SetColor(Color.Blue, Color.Blue, Color.Black, Color.Black);
        }
        public override void Draw(Graphics g, bool isTemporary = false)
        {
            var (pen, brush) = GetPenAndBrush(isTemporary);
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
        public LineShape()
        {
            SetColor(Color.Blue, Color.Transparent, Color.Black, Color.Orange);
        }
        public override void Draw(Graphics g, bool isTemporary = false)
        {
            var (pen, brush) = GetPenAndBrush(isTemporary);
            g.DrawLine(pen, x1, y1, x2, y2);
            pen.Dispose();
            brush.Dispose();
        }
    }

    internal class RectangleShape : Shape // Прямокутник // TODO: Окремий метод для розрахунків координатів
    {
        public RectangleShape()
        {
            SetColor(Color.Blue, Color.Transparent, Color.Black, Color.Orange);
        }
        public override void Draw(Graphics g, bool isTemporary = false)
        {
            int x = Math.Min(x1, x2);
            int y = Math.Min(y1, y2);
            int width = Math.Abs(x2 - x1);
            int height = Math.Abs(y2 - y1);
            var (pen, brush) = GetPenAndBrush(isTemporary);
            g.FillRectangle(brush, x, y, width, height);
            g.DrawRectangle(pen, x, y, width, height);
            pen.Dispose();
            brush.Dispose();
        }
    }

    internal class EllipseShape : Shape // TODO: Окремий метод для розрахунків координатів
    {
        public EllipseShape()
        {
            SetColor(Color.Blue, Color.Transparent, Color.Black, Color.Orange);
        }
        public override void Draw(Graphics g, bool isTemporary = false) // Еліпс
        {
            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);
            var (pen, brush) = GetPenAndBrush(isTemporary);
            g.DrawEllipse(pen, x1 - dx, y1 - dy, 2 * dx, 2 * dy);
            pen.Dispose();
            brush.Dispose();
        }
    }
    internal class LineOOShape : Shape //Лінія з кружечками // TODO: Окремий метод для розрахунків координатів
    {
        private readonly EllipseShape startCircle = new EllipseShape();
        private readonly EllipseShape endCircle = new EllipseShape();
        private readonly LineShape line = new LineShape();
        private const int Radius = 10; // радіус кружечків

        public LineOOShape()
        {
            startCircle.SetColor(Color.Blue, Color.Transparent, Color.Black, Color.Transparent);
            endCircle.SetColor(Color.Blue, Color.Transparent, Color.Black, Color.Transparent);
            line.SetColor(Color.Blue, Color.Empty, Color.Black, Color.Empty);
        }


        public override void Draw(Graphics g, bool isTemporary = false) // Еліпс
        {
            //Повний вектор
            float dx = x2 - x1;
            float dy = y2 - y1;

            float length = MathF.Sqrt(dx * dx + dy * dy);


            if (length < 1)
            {
                length = 1; // Встановлюємо довжину в 1, щоб уникнути ділення на нуль
            }
            //Масштабуємо вектор так, щоб його довжина дорівнювала радіусу $R$
            //                               Напрямок
            int ix1 = Convert.ToInt32(x1 + (dx / length) * Radius);
            int iy1 = Convert.ToInt32(y1 + (dy / length) * Radius);
            int ix2 = Convert.ToInt32(x2 - (dx / length) * Radius);
            int iy2 = Convert.ToInt32(y2 - (dy / length) * Radius);
            line.SetCoordinates(ix1, iy1, ix2, iy2);
            line.Draw(g, isTemporary);
            startCircle.SetCoordinates(x1, y1 , x1 + Radius, y1 + Radius);
            startCircle.Draw(g, isTemporary);

            // 3. Задаємо координати і малюємо другий кружечок через EllipseShape
            endCircle.SetCoordinates(x2, y2, x2 + Radius, y2 + Radius);
            endCircle.Draw(g, isTemporary);
        }
    }
    internal class CubeShape : Shape //Куб // TODO: Окремий метод для розрахунків координатів
    {
        // 2 прямокутники
        // 4 лінії
        private readonly RectangleShape frontRectangle = new RectangleShape();
        private readonly RectangleShape backRectangle = new RectangleShape();


        private readonly LineShape line1 = new LineShape();
        private readonly LineShape line2 = new LineShape();
        private readonly LineShape line3 = new LineShape();
        private readonly LineShape line4 = new LineShape();

        public CubeShape()
        {
            frontRectangle.SetColor(Color.Blue, Color.Transparent, Color.Black, Color.Transparent);
            backRectangle.SetColor(Color.Blue, Color.Transparent, Color.Black, Color.Transparent);

        }

        public override void Draw(Graphics g, bool isTemporary = false) // TODO : Окремий метод для кольору?
        {
            //У нас є 4 кординати, початок і передвинуті
            // Розділення по пікселям не дуже. Мабуть краще по 10% 


            //Раніше були start та end. Але я заплутвася через це

            int left = Math.Min(x1, x2);
            int right = Math.Max(x1, x2);
            int top = Math.Min(y1, y2);
            int bottom = Math.Max(y1, y2);

            int width = right - left;
            int height = bottom - top;

            int offsetX = (int)(width * 0.10f);
            int offsetY = (int)(height * 0.10f);

            // Задній прямокутник
            int bstartX = left + offsetX;
            int bstartY = top;

            int bendX = right;
            int bendY = bottom - offsetY;

            // Передній прямокутник
            int fstartX = left;
            int fstartY = top + offsetY;

            int fendX = right - offsetX;
            int fendY = bottom;

            frontRectangle.SetCoordinates(fstartX, fstartY, fendX, fendY);
            backRectangle.SetCoordinates(bstartX, bstartY, bendX, bendY);

            line1.SetCoordinates(fstartX, fstartY, bstartX, bstartY);
            line2.SetCoordinates(fendX, fstartY, bendX, bstartY);
            line3.SetCoordinates(fstartX, fendY, bstartX, bendY);
            line4.SetCoordinates(fendX, fendY, bendX, bendY);

            backRectangle.Draw(g, isTemporary);

            line1.Draw(g, isTemporary);
            line2.Draw(g, isTemporary);
            line3.Draw(g, isTemporary);
            line4.Draw(g, isTemporary);

            frontRectangle.Draw(g, isTemporary);

        }
    }
}


