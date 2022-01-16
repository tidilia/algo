using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using laba06algorithms;

namespace laba06algorithms
{
    class MyCircle
    {
        int x, y, id;
        const int r = 35;
        bool isSelected;
        public MyCircle() { }

        public MyCircle(MyCircle copy)
        {
            x = copy.getX();
            y = copy.getY();
            isSelected = copy.getIsSelected();
            id = copy.getId();
        }
        public void setMyCircle(int _x, int _y, int _id)
        {
            x = _x;
            y = _y;
            id = _id;
            isSelected = false;
        }

        public int getId()
        {
            return id;
        }

        public int getR()
        {
            return r;
        }

        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }

        public bool getIsSelected()
        {
            return isSelected;
        }

        public bool toSelected(int _x, int _y)
        {
            if (Math.Abs(Math.Pow((_x - x), 2) + Math.Pow((_y - y), 2)) < r)
            {
                if (isSelected) isSelected = false;
                else isSelected = true;
            }
            return isSelected;
        }
        public void notSelected(Label l)
        {
            l.Text = "";
            isSelected = false;
        }
        public void Draw(PaintEventArgs e)
        {
            Pen MyPen;
            SolidBrush MyBrush;
            if (isSelected)
            {
                MyPen = new Pen(Color.FromArgb(167, 145, 255));
                MyBrush = new SolidBrush(Color.FromArgb(167, 145, 255));
            }
            else
            {
                MyPen = new Pen(Color.FromArgb(255, 145, 207));
                MyBrush = new SolidBrush(Color.FromArgb(255, 145, 207));
            }
            e.Graphics.DrawEllipse(MyPen, x - r, y - r, r * 2, r * 2);
            e.Graphics.FillEllipse(MyBrush, x - r, y - r, r * 2, r * 2);
            e.Graphics.DrawString(id.ToString(), new Font("TimesNewRoman", 8), Brushes.Black, x - r / 3, y - r / 3);

            e.Dispose();
            MyBrush.Dispose();
            MyPen.Dispose();
        }
    }
}