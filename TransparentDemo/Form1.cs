using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TransparentDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (t != null)
            {
                if (t.IsAlive) t.Abort();
            }
            
        }
        System.Threading.Thread t = null;
        void Form1_Load(object sender, EventArgs e)
        {
           t= new System.Threading.Thread(() =>
            {

                while (true)
                {

                    button1_Click(null, null);

                    System.Threading.Thread.Sleep(100);
                }

            });
            t.Start();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (this.InvokeRequired)
            {
                System.EventHandler h = new EventHandler(button1_Click);
                this.Invoke(h);
            }
            else
            {
                Graphics g = this.CreateGraphics();
                double hei = Math.Sin(ac * 0.01) * 200;
                g.FillEllipse(new SolidBrush(System.Drawing.SystemColors.Control), 50, 50, 200, (float)Math.Abs(hei)); //;

                ac++;
                 hei = Math.Sin(ac * 0.01) * 200;
                g.FillEllipse(Brushes.Red, 50, 50, 200, (float)Math.Abs(hei));
            }
        }
        int ac = 0;

        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);
        }
    }
}
