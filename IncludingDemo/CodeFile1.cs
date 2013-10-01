using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IncludingDemo;

public static Form1 _sigle = null;
        [STAThread]
        public static int ATNewInstance(IntPtr pwind)
        {            
            if (_sigle == null) _sigle = new Form1();
            Form _parent = (Form)Form.FromHandle(pwind);
            if (_parent != null)
            {
                IncludingHelper.SetParent((int)_sigle.Handle,(int) _parent.Handle);
                IncludingHelper.MoveWindow ((int )_sigle.Handle,0,0, _sigle.Width-20 ,_sigle.Height-45 ,true);
                _parent.FormClosing += new FormClosingEventHandler(_parent_FormClosing);
                _sigle.Show();
                return (int)_sigle.Handle;
            }
            return 0;
        }

        static void _parent_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sigle.Close();
        }