using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SceatchPad
{
    public partial class Form1 : Form
    {
        public Point Current = new Point();
        public Point Old = new Point();
        public Graphics g;
        public Pen p = new Pen(Color.Black, 10);
        public Pen er = new Pen(Color.White, 10);
        public int width;
        public Bitmap surface;
        public Graphics graph;
        public string path = "Picture";
        public int i = 1; 
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            this.Text = "SceatchPad";
            p.SetLineCap(System.Drawing.Drawing2D.LineCap.Round,
                System.Drawing.Drawing2D.LineCap.Round,
                System.Drawing.Drawing2D.DashCap.Round);

            er.SetLineCap(System.Drawing.Drawing2D.LineCap.Round,
                System.Drawing.Drawing2D.LineCap.Round,
                System.Drawing.Drawing2D.DashCap.Round);

            surface = new Bitmap(panel1.Width, panel1.Height);
            graph = Graphics.FromImage(surface);
            panel1.BackgroundImage = surface;
            panel1.BackgroundImageLayout = ImageLayout.None;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Old = e.Location;
            if (radioButton1.Checked) width = 2;
            else if (radioButton2.Checked) width = 5;
            else if (radioButton3.Checked) width = 10;
            else if (radioButton4.Checked) width = 15;
            else if (radioButton5.Checked) width = 30;
            p.Width = width;
            er.Width = width;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Current = e.Location;
                graph.DrawLine(p, Old, Current);
                Old = Current;
                panel1.Invalidate();
            }
            else if (e.Button == MouseButtons.Right)
            {
                Current = e.Location;
                graph.DrawLine(er, Old, Current);
                panel1.Invalidate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog color_dialog = new ColorDialog();
            if(color_dialog.ShowDialog() == DialogResult.OK)
            {
                p.Color = color_dialog.Color;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            surface.Save(path + ".png", ImageFormat.Png);
            path += i;
            i++;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Invalidate();
            graph.Clear(Color.White);

        }
    }
    public class Tpanel : Panel
    {
        public Tpanel()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }
    }
}
