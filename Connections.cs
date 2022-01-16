using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;
using laba04algo;

namespace laba04selfmade
{
    class Connections
    {
        int x1, y1, x2, y2;
        public Connections() { }
        public Connections(MyCircle c1, MyCircle c2)
        {
            x1 = c1.getX();
            x2 = c2.getX();
            y1 = c1.getY();
            y2 = c2.getY();
        }
        public void Draw(PaintEventArgs e)
        {
            Pen myPen = new Pen(Color.Black, 2);
            e.Graphics.DrawLine(myPen, x1, y1, x2, y2);
        }
    }
}
