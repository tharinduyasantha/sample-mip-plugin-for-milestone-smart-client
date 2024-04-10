using System;
using VideoOS.Platform.Client;

namespace MIPPlugin1.Client
{
    /// <summary>
    /// Interaction logic for MIPPlugin1WorkSpaceViewItemWpfUserControl.xaml
    /// </summary>
    public partial class MIPPlugin1WorkSpaceViewItemWpfUserControl : ViewItemWpfUserControl
    {
        public MIPPlugin1WorkSpaceViewItemWpfUserControl()
        {
            InitializeComponent();
        }

        public override void Init()
        {
            
        }

        public override void Close()
        {
        }

        /// <summary>
        /// Do not show the sliding toolbar!
        /// </summary>
        public override bool ShowToolbar
        {
            get { return false; }
        }

        private void ViewItemWpfUserControl_ClickEvent(object sender, EventArgs e)
        {
            FireClickEvent();
        }

        private void ViewItemWpfUserControl_DoubleClickEvent(object sender, EventArgs e)
        {
            FireDoubleClickEvent();
        }
    }
}
