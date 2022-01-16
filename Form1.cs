﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using laba06algorithms;

namespace laba06algorithms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int id = 0;
        int nSelect = 0;
        int[][] matrica = new int[0][];
        int[][] tmp_matrica = new int[0][];
        MyCircle c1 = new MyCircle();
        MyCircle c2 = new MyCircle();
        Connections connect = new Connections();
        List<MyCircle> circles = new List<MyCircle>();
        List<Connections> connections = new List<Connections>();
        List<int> stack = new List<int>();
        List<int> list = new List<int>();
        GraphDesign pictireB = new GraphDesign();


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) circleCreator(e);
            else if (e.Button == MouseButtons.Right) connectCreator(e);

        }

        private bool parity()
        {
            int count = 0;
            for (int i = 0; i < id; ++i)
            {
                int loc_count = 0;
                for (int j = 0; j < id; ++j)
                    if (matrica[i][j] == 1) ++loc_count;
                if (loc_count % 2 == 0) ++count;
            }
            return (count == id);
        }

        private bool connectivity()
        {
            search();
            return (list.Count == id);
        }

        private void proverka(int vertex)
        {
            if (!list.Contains(vertex))
            {
                for (int j = 0; j < id; ++j)
                {
                    if (matrica[vertex][j] == 1 && !list.Contains(j))
                    {
                        stack.Add(j);
                        stackL.Text += (j + 1).ToString() + "->";
                    }
                }
                list.Add(vertex);
                ListL.Text = ListL.Text + (vertex + 1).ToString() + "->";
            }
            stack.Remove(vertex);
        }

        private void search()
        {
            int x0 = Int32.Parse(textBox1.Text) - 1;
            pictireB = new GraphDesign(circles, connections);
            stack.Add(x0);
            stackL.Text += (x0 + 1).ToString() + "->";
            proverka(x0);
            while (stack.Count != 0)
            {
                proverka(stack[stack.Count - 1]);
            }
        }

        private string euler_cycle()
        {
            string result = "";
            if (!parity())
                result += "Граф нe содержит эйлерова цикла, так как не все вершины имеют четную степень";
            else if (!connectivity())
                result += "Граф не содержит эйлерова цикла, так как граф несвязный";
            else
            {
                int x0 = Int32.Parse(textBox1.Text) - 1;
                Array.Resize(ref tmp_matrica, id);
                for (int i = 0; i < id; i++)
                    Array.Resize(ref tmp_matrica[i], id);
                for(int i = 0; i < id; ++i)
                    for(int j = 0; j < id; ++j) {
                        tmp_matrica[i][j] = matrica[i][j];
                    }

            }
            return result;

        }



        private void circleCreator(MouseEventArgs e)
        {
            ++id;
            Array.Resize(ref matrica, id);
            for (int i = 0; i < id; i++)
                Array.Resize(ref matrica[i], id);
            MyCircle newCircle = new MyCircle();
            newCircle.setMyCircle(e.X, e.Y, id);
            circles.Add(newCircle);
            pictireB = new GraphDesign(circles, connections);
            Refresh();
        }


        private void connectCreator(MouseEventArgs e)
        {
            for (int i = 0; i < circles.Count; ++i)
            {
                if (circles[i].toSelected(e.X, e.Y))
                {
                    for (int j = 0; j < id; ++j)
                    {
                        if (matrica[i][j] == 1) label2.Text += (j + 1).ToString() + " ";
                    }
                    if (nSelect <= 1)
                    {
                        Refresh();
                        nSelect++;
                    }
                    else if (nSelect == 2)
                    {
                        for (int j = 0; j < circles.Count; j++)
                            if (circles[j].getIsSelected())
                            {
                                if (nSelect == 1) c2 = circles[j];
                                else
                                {
                                    c1 = circles[j];
                                    nSelect--;
                                }
                            }
                        connect = new Connections(c1, c2);
                        connections.Add(connect);
                        for (int m = 0; m < circles.Count; m++) circles[m].notSelected(label2);
                        nSelect = 0;
                        pictireB = new GraphDesign(circles, connections);
                        Refresh();
                        matrica[c1.getId() - 1][c2.getId() - 1] = 1;
                        matrica[c2.getId() - 1][c1.getId() - 1] = 1;
                    }
                }
            }
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            pictireB.Draw(e);
        }

        private void enter_Click(object sender, EventArgs e)
        {
            search();
        }
    }
}
