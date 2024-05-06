using System;
using System.Xml;
using VideoOS.Platform.Admin;

namespace MIPPlugin1.Admin
{
    public class MIPPlugin1ToolsOptionDialogPlugin : VideoOS.Platform.Admin.ToolsOptionsDialogPlugin
    {
        private MIPPlugin1ToolsOptionDialogUserControl _myUserControl;

        public override void Init()
        {
            // TODO: remove below check once MIPPlugin1Definition.MIPPlugin1ToolsOptionDialogPluginId has been replaced with proper GUID
            
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
            VideoOS.Platform.Configuration.Instance.SaveOptionsConfiguration(
                MIPPlugin1.MIPPlugin1Definition.MyPropertyId,
                true,
                Utility.ToXml("ToolOptions", _myUserControl.MyPropValue));
            return true;
        }

        public override string Name
        {
            get { return "Sprinx Properties"; }
        }

        public override Guid Id
        {
            get { return MIPPlugin1Definition.MIPPlugin1ToolsOptionDialogPluginId; }
        }


        public override ToolsOptionsDialogUserControl GenerateUserControl()
        {
            _myUserControl = new MIPPlugin1ToolsOptionDialogUserControl();
            System.Xml.XmlNode result = VideoOS.Platform.Configuration.Instance.GetOptionsConfiguration(MIPPlugin1Definition.MyPropertyId, true);
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
