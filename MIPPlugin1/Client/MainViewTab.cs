using System;
using System.Collections.Generic;
using VideoOS.Platform;
using VideoOS.Platform.Client;

namespace MIPPlugin1.Client
{
    internal class MIPPlugin1WorkSpaceToolbarPluginInstance : WorkSpaceToolbarPluginInstance
    {
        private Item _window;

        public MIPPlugin1WorkSpaceToolbarPluginInstance()
        {
        }

        public override void Init(Item window)
        {
            _window = window;

            Title = "Sprinx";
        }

        public override void Activate()
        {
            // Here you should put whatever action that should be executed when the toolbar button is pressed
        }

        public override void Close()
        {
        }

    }

    internal class MainViewTab : WorkSpaceToolbarPlugin
    {
        public MainViewTab()
        {
        }

        public override Guid Id
        {
            get { return MIPPlugin1Definition.MIPPlugin1WorkSpaceToolbarPluginId; }
        }

        public override string Name
        {
            get { return "SprinxTabName"; }
        }

        public override void Init()
        {
            // TODO: remove below check when MIPPlugin1Definition.MIPPlugin1WorkSpaceToolbarPluginId has been replaced with proper GUID
            //if (Id == new Guid("22222222-2222-2222-2222-222222222222"))
            //{
            //    System.Windows.MessageBox.Show("Default GUID has not been replaced for MIPPlugin1WorkSpaceToolbarPluginId!");
            //}

            //WorkSpaceToolbarPlaceDefinition.WorkSpaceIds = new List<Guid>() { ClientControl.LiveBuildInWorkSpaceId, ClientControl.PlaybackBuildInWorkSpaceId, MIPPlugin1Definition.MIPPlugin1WorkSpacePluginId };
            //WorkSpaceToolbarPlaceDefinition.WorkSpaceStates = new List<WorkSpaceState>() { WorkSpaceState.Normal };
        }

        public override void Close()
        {
        }

        public override WorkSpaceToolbarPluginInstance GenerateWorkSpaceToolbarPluginInstance()
        {
            return new MIPPlugin1WorkSpaceToolbarPluginInstance();
        }
    }
}
