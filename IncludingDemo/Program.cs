﻿using System;
using System.Collections.Generic;

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
                    _sigle.Width = rect.Width - margin_left;
                    _sigle.Height = rect.Height - margin_top;
                }
                _sigle.Location = DllConfig.Default.FrameMidLocation;              
                _sigle.Show();               
                return (int)_sigle.Handle;

            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
#endif
            }

            return 0;
        }

        static void _parent_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _sigle.Close();
            }
            catch (Exception)
            {
            }

        }

        [STAThread]
        public static int ATDeleteInstance()
        {
            try
            {
                if (_sigle != null)
                {

                    _sigle.Close();
                    _sigle.Dispose();
                    _sigle = null;
                }

            }
            catch (Exception ex)
            {
            }
            return 0;
        }
    }
}

