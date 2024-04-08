using System;
using System.Drawing;
using VideoOS.Platform.Client;

namespace MIPPlugin1.Client
{
    public class MIPPlugin1ViewLayout : ViewLayout
    {
        public override Image Icon
        {
            get { return MIPPlugin1Definition.TreeNodeImage; }
            set { }
        }

        public override Rectangle[] Rectangles
        {
            get { return new Rectangle[] { new Rectangle(000, 000, 999, 499), new Rectangle(000, 499, 499, 499), new Rectangle(499, 499, 499, 499) }; }
            set { }
        }

        public override Guid Id
        {
            get { return MIPPlugin1Definition.MIPPlugin1ViewLayoutId; }
            set { }
        }

        public override string DisplayName
        {
            get { return "MIPPlugin1"; }
            set { }
        }
    }
}
