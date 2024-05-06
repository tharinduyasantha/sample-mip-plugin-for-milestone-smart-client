using Microsoft.IdentityModel.Tokens;

using System;
using System.Collections.Generic;
using System.Windows.Markup;
using System.Xml;
using VideoOS.Platform;
using VideoOS.Platform.Client;

namespace MIPPlugin1.Client
{
    /// <summary>
    /// The ViewItemManager contains the configuration for the ViewItem. <br/>
    /// When the class is initiated it will automatically recreate relevant ViewItem configuration saved in the properties collection from earlier.
    /// Also, when the viewlayout is saved the ViewItemManager will supply current configuration to the SmartClient to be saved on the server.<br/>
    /// This class is only relevant when executing in the Smart Client.
    /// </summary>
    public class MIPPlugin1ViewItemManager : ViewItemManager
    {
        private Guid _someid;
        private string _someName;
        private List<Item> _configItems;

        internal const string WorkspacePropertyKey = "MyProp";
        private string _gloProp;
        private string _priProp;

        public MIPPlugin1ViewItemManager() : base("MIPPlugin1ViewItemManager")
        {
        }

        public string MyPropValue
        {
            set { SetProperty(WorkspacePropertyKey, value ?? ""); SaveProperties(); }
            get { return GetProperty(WorkspacePropertyKey); }
        }

        public string MyPropShareGlobal
        {
            set
            {
                _gloProp = value ?? "";
                // SaveOptionsConfiguration - Global
                VideoOS.Platform.Configuration.Instance.SaveOptionsConfiguration(
                    MIPPlugin1.MIPPlugin1Definition.MyPropertyId, false, Utility.ToXml("SharedProperty", _gloProp));
                MIPPlugin1Definition.OnSharedPropertyChange(this, EventArgs.Empty);
            }
            get
            {
                System.Xml.XmlNode result = VideoOS.Platform.Configuration.Instance.GetOptionsConfiguration(MIPPlugin1Definition.MyPropertyId, false);
                _gloProp = Utility.GetInnerText(result, "Empty");
                return _gloProp;
            }
        }

        #region Methods overridden 
        /// <summary>
        /// The properties for this ViewItem is now loaded into the base class and can be accessed via 
        /// GetProperty(key) and SetProperty(key,value) methods
        /// </summary>
        //public override void PropertiesLoaded()
        //{
        //    String someid = GetProperty("SelectedGUID");
        //    _configItems = Configuration.Instance.GetItemConfigurations(MIPPlugin1Definition.MIPPlugin1PluginId, null, MIPPlugin1Definition.MIPPlugin1Kind);
        //    if (someid != null && _configItems != null)
        //    {
        //        SomeId = new Guid(someid);  // Set as last selected
        //    }
        //}

        ///// <summary>
        ///// Generate the UserControl containing the actual ViewItem Content.
        ///// 
        ///// For new plugins it is recommended to use GenerateViewItemWpfUserControl() instead. Only implement this one if support for Smart Clients older than 2017 R3 is needed.
        ///// </summary>
        ///// <returns></returns>
        //public override ViewItemUserControl GenerateViewItemUserControl()
        //{
        //	return new MIPPlugin1ViewItemUserControl(this);
        //}

        /// <summary>
        /// Generate the UserControl containing the actual ViewItem Content.
        /// </summary>
        /// <returns></returns>
        public override ViewItemWpfUserControl GenerateViewItemWpfUserControl()
        {
            return new MIPPlugin1ViewItemWpfUserControl(this);
        }

        ///// <summary>
        ///// Generate the UserControl containing the property configuration.
        ///// 
        ///// For new plugins it is recommended to use GeneratePropertiesWpfUserControl() instead. Only implement this one if support for Smart Clients older than 2017 R3 is needed.
        ///// </summary>
        ///// <returns></returns>
        //public override PropertiesUserControl GeneratePropertiesUserControl()
        //{
        //	return new MIPPlugin1PropertiesUserControl(this);
        //}

        /// <summary>
        /// Generate the UserControl containing the property configuration.
        /// </summary>
        /// <returns></returns>
        //public override PropertiesWpfUserControl GeneratePropertiesWpfUserControl()
        //{
        //    return new MIPPlugin1PropertiesWpfUserControl(this);
        //}

        #endregion

        //public List<Item> ConfigItems
        //{
        //    get { return _configItems; }
        //}

        //public Guid SomeId
        //{
        //    get { return _someid; }
        //    set
        //    {
        //        _someid = value;
        //        SetProperty("SelectedGUID", _someid.ToString());
        //        if (_configItems != null)
        //        {
        //            foreach (Item item in _configItems)
        //            {
        //                if (item.FQID.ObjectId == _someid)
        //                {
        //                    SomeName = item.Name;
        //                }
        //            }
        //        }
        //        SaveProperties();
        //    }
        //}

        public String SomeName
        {
            get { return _someName; }
            set { _someName = value; }
        }
    }
}
