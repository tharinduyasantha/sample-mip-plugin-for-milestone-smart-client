using VideoOS.Platform.Admin;

namespace MIPPlugin1.Admin
{
    public partial class MIPPlugin1ToolsOptionDialogUserControl : ToolsOptionsDialogUserControl
    {
        public MIPPlugin1ToolsOptionDialogUserControl()
        {
            InitializeComponent();
        }

        public override void Init()
        {
        }

        public override void Close()
        {
        }

        public string MyPropValue
        {
            set { textBoxPropValue.Text = value ?? ""; }
            get { return textBoxPropValue.Text; }
        }
    }
}
