using System.Windows;
using System.Windows.Controls;

namespace MIPPlugin1.Client
{
    public partial class MIPPlugin1SettingsPanelControl : UserControl
    {
        private readonly MIPPlugin1SettingsPanelPlugin _plugin;
        private const string _propertyId = "aSettingId";
        public MIPPlugin1SettingsPanelControl(MIPPlugin1SettingsPanelPlugin plugin)
        {
            _plugin = plugin;

            InitializeComponent();

            _aSettingTextBox.Text = _plugin.GetProperty(_propertyId);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _plugin.SetProperty(_propertyId, _aSettingTextBox.Text);
            string errorMessage;
            if (!_plugin.TrySaveChanges(out errorMessage))
            {
                MessageBox.Show(errorMessage);
            }
        }
    }
}
