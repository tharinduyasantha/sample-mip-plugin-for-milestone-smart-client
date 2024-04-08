using VideoOS.Platform.Client;

namespace MIPPlugin1.Client
{
    public class MIPPlugin1WorkSpaceViewItemManager : ViewItemManager
    {
        public MIPPlugin1WorkSpaceViewItemManager() : base("MIPPlugin1WorkSpaceViewItemManager")
        {
        }

        public override ViewItemWpfUserControl GenerateViewItemWpfUserControl()
        {
            return new MIPPlugin1WorkSpaceViewItemWpfUserControl();
        }
    }
}
