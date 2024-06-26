using System;
using System.Windows.Controls;
using System.Windows.Markup;
using VideoOS.Platform.Client;

namespace MIPPlugin1.Client
{
    public class MIPPlugin1SettingsPanelPlugin : SettingsPanelPlugin
    {
        private MIPPlugin1SettingsPanelControl _myUserControl;

        /// <summary>
        /// Should return unique id identifying this plug-in.
        /// </summary>
        public override Guid Id
        {
            get { return MIPPlugin1Definition.MIPPlugin1SettingsPanel; }
        }

        /// <summary>
        /// Should return the title of this plug-in. It will be displayed in the Settings panel navigation list.
        /// </summary>
        public override string Title { get { return "Properties"; } }

        /// <summary>
        /// This method is called just before the Settings panel is closed.
        /// </summary>
        public override void Close()
        {
            if (_myUserControl != null)
                _myUserControl = null;
        }

        /// <summary>
        /// Should close the user control and clean up any resources or event registrations. <br>
        /// It's called when a user navigates away from this plug-in - either when selecting different component in the navigation list or when closing the Settings panel.
        /// </summary>
        public override void CloseUserControl()
        {
            _myUserControl = null;
        }

        /// <summary>
        /// Should create a Windows Presentation Foundation (WPF) user control which represents the user interface (UI) of this plug-in.
        /// </summary>
        public override UserControl GenerateUserControl()
        {
            // Get hold of the default set of properties for this plugin (Saved under Id='PropertyDefinition.PropertyOptionsDialog')
            LoadProperties(true);
            _myUserControl = new MIPPlugin1SettingsPanelControl() { MyPropValue = GetProperty("MyProp") };

            // The following lines show how to access other set of properties, saved under id='PropertyDefinition.MyPropertyId'

            // GetOptionsConfiguration - Global
            System.Xml.XmlNode result = VideoOS.Platform.Configuration.Instance.GetOptionsConfiguration(MIPPlugin1Definition.MyPropertyId, false);
            _myUserControl.MyPropSharedGlobal = Utility.GetInnerText(result, "Empty");

            // GetOptionsConfiguration - Private
            //result = VideoOS.Platform.Configuration.Instance.GetOptionsConfiguration(MIPPlugin1Definition.MyPropertyId, true);
            //_myUserControl.MyPropSharedPrivate = Utility.GetInnerText(result, "Empty");
            return _myUserControl; ;
        }

        /// <summary>
        /// This method is called when the Settings panel is loaded. <br>
        /// It should be used for accessing configuration items if needed.
        /// </summary>
        public override void Init()
        {
            
        }

        /// <summary>
		/// Should save any changes made in the user control. If the save operation fails, use errorMessage to provide a string describing the error. <br>
		/// This method should be overridden by the plug-in to validate the entries and possibly call <see cref="SaveProperties(bool)"/> to have the properties stored on the server. 
		/// (If the values have been set using <see cref="PropertyClass.SetProperty(string, string)"/>)
        /// </summary>
        /// <param name="errorMessage">The error description if saving failed. An empty string if successfully saved.</param>
        /// <returns>True if settings were successfully saved, otherwise false.</returns>
        public override bool TrySaveChanges(out string errorMessage)
        {
            SaveProperties(false);
            errorMessage = string.Empty;
            return true;
        }
    }
}
