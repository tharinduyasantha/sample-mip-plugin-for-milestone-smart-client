using System.Windows;
using System.Windows.Controls;

namespace MIPPlugin1.Client
{
    public partial class MIPPlugin1SettingsPanelControl : UserControl
    {
        public MIPPlugin1SettingsPanelControl()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Get and set the property value - controlled from the SettingsPanelPlugin class
        /// </summary>
        public string MyPropValue
        {
            get; set;
        }
        public string MyPropSharedGlobal
        {
            set { textBoxSharedGlobal.Text = value ?? ""; }
            get { return textBoxSharedGlobal.Text; }
        }

    }
}
