using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;
using IncludingDemo.Properties;

namespace IncludingDemo
{
    public partial class Form1 : Form
    {
        const int WM_SIZE = 0x0005;
        const int WM_GETTEXTLENGTH = 0xe;
        const int WM_GETTEXT = 0xd;
        const int WM_PAINT = 0xf;
        const int WM_UNKOUN = 0xc289;

        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
            this.GotFocus += new EventHandler(Form1_GotFocus);


        }

        void Form1_GotFocus(object sender, EventArgs e)
        {
            IncludingHelper.SetActiveWindow(this.Frame3D_Handle);
        }

        Process process = new Process();


        delegate void SetChilden_delegate(int win);

        System.Threading.Thread thread;

        public int Frame3D_Handle { get; set; }
        public IntPtr Parent_Handle { get; set; }

        public FormWindowState PreFormWindowState = FormWindowState.Normal;

        public int Margin_Height = 10;
        public int Margin_Weight = 0;

        private bool IsInit = true;



        void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("load method");
            StartTarget();
            this.thread = new System.Threading.Thread(p =>
            {
                while (true)
                {
                    this.Frame3D_Handle = IncludingHelper.FindWindow(null, DllConfig.Default.TitleStringList);
                    //MessageBox.Show("7");

                    if (Frame3D_Handle > 0)
                    {
                        //MessageBox.Show("8");
                        SetChilden(Frame3D_Handle);
                        //MessageBox.Show("9");
                        break;
                    }
                    Thread.Sleep(100);
                }

            });

            thread.Start();
            // MessageBox.Show(Properties.Settings.Default.SubAppPath);
        }

        private void SetChilden(int win)
        {
            if (win <= 0) return;
            if (this.IsDisposed) return;
            //MessageBox.Show("10");
            if (this.InvokeRequired)
            {
                SetChilden_delegate d = new SetChilden_delegate(SetChilden);
                this.Invoke(d, win);
            }
            else
            {
                IncludingHelper.SetParent(win, (int)this.Handle);
                SetFrame3DPostion();

                this.IsInit = false;
            }


        }

        private void SetFrame3DPostion()
        {
            int win = this.Frame3D_Handle;
            //Childre_Rect = new Rectangle();
            //IncludingHelper.GetWindowRect(win, ref Childre_Rect);
            Size defautsize = DllConfig.Default.Frame3DSize;
            if (defautsize.Width <= 0 || defautsize.Height <= 0)
            {
                defautsize.Width = this.Width;
                defautsize.Height = this.Height;
            }

            IncludingHelper.MoveWindow(win,
               DllConfig.Default.Frame3DLocation.X,
               DllConfig.Default.Frame3DLocation.Y,
                  defautsize.Width, defautsize.Height, true);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.process != null)
            {

                this.process.Close();
                this.process.WaitForExit();
                this.process.Dispose();
                
                this.process = null;
            }
        }

        private void StartTarget()
        {
            process.StartInfo.FileName = DllConfig.Default.SubAppPath;
            process.Start();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState != this.PreFormWindowState)
            {
                PreFormWindowState = this.WindowState;
                SetFrame3DPostion();
            }

        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            if (IsInit) return;
            SetFrame3DPostion();
        }



        private void SetSizeThis()
        {
            if (this.IsDisposed) return;
            Rectangle rect = new Rectangle();
            IncludingHelper.GetWindowRect((int)this.Parent_Handle, ref rect);

            Debug.WriteLine(rect);
            this.Width = rect.Width;
            this.Height = rect.Height;

            SetFrame3DPostion();
        }



        public override bool PreProcessMessage(ref Message msg)
        {
            Debug.WriteLine(msg, "PreProcessMessage");
            // MessageBox.Show(msg.Msg + "," + msg.LParam.ToInt64() + "," + msg.HWnd);
            return base.PreProcessMessage(ref msg);

        }

        protected override void DefWndProc(ref Message msg)
        {
            // MessageBox.Show(msg.Msg + "--" + msg.LParam.ToInt64() + "--" + msg.HWnd);
            base.DefWndProc(ref msg);
            if (msg.Msg == WM_SIZE || msg.Msg == WM_GETTEXT || msg.Msg == WM_UNKOUN)
            {
                SetSizeThis();
            }

            Debug.WriteLine(msg, "DefWndProc");
        }

        protected override void OnNotifyMessage(Message msg)
        {
            // MessageBox.Show(msg.Msg + "--OnNotifyMessage" + msg.LParam.ToInt64() + "--" + msg.HWnd);
            base.OnNotifyMessage(msg);
            Debug.WriteLine(msg, "OnNotifyMessage");
        }

        protected override void OnParentChanged(EventArgs e)
        {

            base.OnParentChanged(e);
            if (this.Parent != null)
                MessageBox.Show(this.Parent.GetType().Name);
        }

        protected override void WndProc(ref Message msg)
        {
            // MessageBox.Show(msg.Msg + "--WndProc" + msg.LParam.ToInt64() + "--" + msg.HWnd);
            base.WndProc(ref msg);

            if (msg.Msg == WM_GETTEXTLENGTH || msg.Msg == WM_PAINT)
            {
                SetSizeThis();
            }
            Debug.WriteLine(msg, "WndProc");
        }

    }
}



