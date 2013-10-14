using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IncludingDemo;
using IncludingDemo.Properties;

namespace IncludingDemo
{

    public static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] str)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static Form1 _sigle = null;

        [STAThread]
        public static int ATNewInstance(IntPtr pwind)
        {
            ATDeleteInstance();
            
            int margin_top = 0;
            int margin_left = 0;
            //MessageBox.Show("Test");
            try
            {
               //MessageBox.Show("1");
                if (_sigle == null) _sigle = new Form1();
               //MessageBox.Show("2");
                _sigle.Parent_Handle = pwind;
                IncludingHelper.SetParent((int)_sigle.Handle, (int)pwind);
                System.Drawing.Rectangle rect = new System.Drawing.Rectangle();
                IncludingHelper.GetWindowRect((int)pwind, ref rect);

                if (rect != null && rect.Height * rect.Width > 0)
                {
                    _sigle.Width = rect.Width-margin_left;
                    _sigle.Height = rect.Height-margin_top;
                }
                _sigle.Location = DllConfig.Default.FrameMidLocation;
               //MessageBox.Show("3");
              //IncludingHelper.MoveWindow((int)_sigle.Handle, 0, 0, _sigle.Width - 20, _sigle.Height - 45, true);
               //MessageBox.Show("4");
                _sigle.Show();
               //MessageBox.Show("5");
                return (int)_sigle.Handle;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }

            return 0;
        }

        static void _parent_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sigle.Close();
        }

        [STAThread]
        public static  int ATDeleteInstance()
        {
           // MessageBox.Show("ATDeleteInstance");
            if (_sigle != null)
            {
                try
                {
                    _sigle.Close();
                    _sigle.Dispose();
                    _sigle = null;
                }
                catch (Exception ex)
                {
                    
                    
                }
               
            }
            return 0;
        }
    }
}

