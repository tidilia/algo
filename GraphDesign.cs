using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using laba04algo;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace laba04selfmade
{
    class GraphDesign
    {
        List<MyCircle> circles;
        List<Connections> connections;
        public GraphDesign() { }
        public GraphDesign(List <MyCircle> _c, List<Connections> _co)
        {
            circles = _c;
            connections = _co;
        }
        public void Draw(PaintEventArgs e)
        {
            if (circles != null)
                for (int i = 0; i < circles.Count; ++i) circles[i].Draw(e);
            if (connections != null)
                for (int i = 0; i < connections.Count; ++i) connections[i].Draw(e);
        }
    }
}
