using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Configuration;
using System.Xml;
using System.Drawing;

namespace IncludingDemo.Properties
{

    public class DllConfig
    {
        static DllConfig _instan = New();
        XmlDocument _default = new XmlDocument();
        private DllConfig()
        {

            // System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location + "");
            _default.Load(Assembly.GetExecutingAssembly().Location + ".xml");

        }

        public static DllConfig Default
        {
            get { return _instan; }
        }

        private static DllConfig New()
        {
            DllConfig d = new DllConfig();

            return d;
        }

        public string this[string key]
        {
            get
            {
                return _default.SelectSingleNode("//" + key).InnerText;
            }
            set
            {
                // _default[key] = value;
            }

        }

        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("D:\\ATG\\demo20130923\\demo.exe")]
        public string SubAppPath
        {
            get
            {
                return ((string)(this["SubAppPath"]));
            }
        }

        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("bul")]
        public string TitleStringList
        {
            get
            {
                return ((string)(this["TitleStringList"]));
            }
        }

        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("-5, -25")]
        public global::System.Drawing.Point Frame3DLocation
        {
            get
            {
                string[] sp = this["Frame3DLocation"].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                Point p = new Point();

                p.X = int.Parse(sp[0]);
                p.Y = int.Parse(sp[1]);
                return p;
               // return ((global::System.Drawing.Point)(this["Frame3DLocation"]));
            }
        }

        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0, 0")]
        public global::System.Drawing.Point FrameMidLocation
        {
            get
            {
                string[] sp = this["FrameMidLocation"].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                Point p = new Point();

                p.X = int.Parse(sp[0]);
                p.Y = int.Parse(sp[1]);
                return p;
            }
        }

        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0, 0")]
        public global::System.Drawing.Size Frame3DSize
        {
            get
            {
                string[] sp = this["Frame3DSize"].Split(new char[] {',' }, StringSplitOptions.RemoveEmptyEntries);
                Size p = new Size();

                p.Width= int.Parse (sp[0]);
                p.Height = int.Parse(sp[1]);
                return p;
                //return ((global::System.Drawing.Size)(this["Frame3DSize"]));
            }
        }
    }
}
