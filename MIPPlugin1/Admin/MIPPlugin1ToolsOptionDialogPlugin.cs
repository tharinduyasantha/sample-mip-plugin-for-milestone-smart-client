using System;
using System.Xml;
using VideoOS.Platform.Admin;

namespace MIPPlugin1.Admin
{
    public class MIPPlugin1ToolsOptionDialogPlugin : ToolsOptionsDialogPlugin
    {
        private MIPPlugin1ToolsOptionDialogUserControl _myUserControl;
        private Guid _myPropertyId = new Guid("D8979A59-D40D-4CEC-98FF-3BD06EE17B05");

        public override void Init()
        {
            // TODO: remove below check once MIPPlugin1Definition.MIPPlugin1ToolsOptionDialogPluginId has been replaced with proper GUID
            if (Id == new Guid("44444444-4444-4444-4444-444444444444"))
            {
                System.Windows.MessageBox.Show("Default GUID has not been replaced for MIPPlugin1ToolsOptionDialogPluginId!");
            }

            //Note: Do not try to get option settings here!
        }

        public override void Close()
        {
            //Note: Do not try to save option settings here!
        }

        /// <summary>
        /// Saving the changes
        /// </summary>
        /// <returns></returns>
        public override bool SaveChanges()
        {
            if (_myUserControl == null) return true;
            VideoOS.Platform.Configuration.Instance.SaveOptionsConfiguration(_myPropertyId, true, ToXml("ToolsOption", _myUserControl.MyPropValue));
            return true;
        }

        public override string Name
        {
            get { return "MIPPlugin1"; }
        }

        public override Guid Id
        {
            get { return MIPPlugin1Definition.MIPPlugin1ToolsOptionDialogPluginId; }
        }


        public override ToolsOptionsDialogUserControl GenerateUserControl()
        {
            _myUserControl = new MIPPlugin1ToolsOptionDialogUserControl();
            System.Xml.XmlNode result = VideoOS.Platform.Configuration.Instance.GetOptionsConfiguration(_myPropertyId, true);
            _myUserControl.MyPropValue = GetInnerText(result, "Empty");
            return _myUserControl;
        }

        #region Helper methods

        internal static XmlElement ToXml(string key, string value)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("root");
            doc.AppendChild(root);
            XmlElement child = doc.CreateElement(key);
            child.InnerText = value;
            root.AppendChild(child);
            return root;
        }

        internal static String GetInnerText(XmlNode xmlNode, String defaultValue)
        {
            if (xmlNode != null)
            {
                return xmlNode.InnerText;
            }
            return defaultValue;
        }

        #endregion
    }


}
