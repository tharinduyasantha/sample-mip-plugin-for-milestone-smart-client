using Microsoft.Web.WebView2.Core;
using MIPPlugin1.Client.Services;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using VideoOS.Platform;
using VideoOS.Platform.Client;
using VideoOS.Platform.Messaging;

namespace MIPPlugin1.Client
{
    /// <summary>
    /// The ViewItemWpfUserControl is the WPF version of the ViewItemUserControl. It is instantiated for every position it is created on the current visible view. When a user select another View or ViewLayout, this class will be disposed.  No permanent settings can be saved in this class.
    /// The Init() method is called when the class is initiated and handle has been created for the UserControl. Please perform resource initialization in this method.
    /// <br>
    /// If Message communication is performed, register the MessageReceivers during the Init() method and UnRegister the receivers during the Close() method.
    /// <br>
    /// The Close() method can be used to Dispose resources in a controlled manor.
    /// <br>
    /// Mouse events not used by this control, should be passed on to the Smart Client by issuing the following methods:<br>
    /// FireClickEvent() for single click<br>
    ///	FireDoubleClickEvent() for double click<br>
    /// The single click will be interpreted by the Smart Client as a selection of the item, and the double click will be interpreted to expand the current viewitem to fill the entire View.
    /// </summary>
    public partial class MIPPlugin1ViewItemWpfUserControl : ViewItemWpfUserControl
    {
        #region Component private class variables

        private MIPPlugin1ViewItemManager _viewItemManager;
        private object _themeChangedReceiver;
        private string _webViewUrl = "http://localhost:3000/";

        public string WebViewUrl
        {
            get { return _webViewUrl; }
            set
            {
                if (_webViewUrl != value)
                {
                    _webViewUrl = value;
                    if (webView?.CoreWebView2 != null)
                    {
                        webView.CoreWebView2.Navigate(_webViewUrl);
                    }
                }
            }
        }

        #endregion

        #region Component constructors + dispose

        /// <summary>
		/// Constructs a MIPPlugin1ViewItemUserControl instance
        /// </summary>
		public MIPPlugin1ViewItemWpfUserControl(MIPPlugin1ViewItemManager viewItemManager)
        {
            _viewItemManager = viewItemManager;


            InitializeComponent();
            this.DataContext = this;

            //SetHeaderColors();
            InitializeWebView();
        }

        private void InitializeWebView()
        {
            webView.Loaded += InitializeWebView2;
        }

        private async void InitializeWebView2(object sender, RoutedEventArgs e)
        {
            if (webView.CoreWebView2 == null)
            {
                await webView.EnsureCoreWebView2Async();
                webView.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
                webView.CoreWebView2.Navigate(_webViewUrl);
            }
        }


        private async void CoreWebView2_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                var loginSettings = VideoOS.Platform.Login.LoginSettings.GetLoginSettings(EnvironmentManager.Instance.MasterSite.ServerId);
                var idpToken = loginSettings.IdentityTokenCache.Token;
                var tokenService = new TokenService("my-32-character-ultra-secure-and-ultra-long-secret");
                var newToken = tokenService.RegenerateToken(idpToken);

                string script = 
                    $@"setTimeout(() => {{window.postMessage({{ 'type': 'AUTH_TOKEN', 'token': '{newToken}' }}, 'http://localhost:3000');}}, 500);";

                await webView.CoreWebView2.ExecuteScriptAsync(script);

            }
            else
            {
                Console.Error.WriteLine("Navigation to the WebView app failed.");
            }
        }

        private static Color GetWindowsMediaColor(System.Drawing.Color inColor)
        {
            return Color.FromArgb(inColor.A, inColor.R, inColor.G, inColor.B);
        }

        private void UpdateTextFromReactApp(object sender, CoreWebView2WebMessageReceivedEventArgs args)
        {
            string message = args.TryGetWebMessageAsString();
            if (!String.IsNullOrEmpty(message))
            {

                //ReactMessage.Text = message;
            }
        }
        private void OnWpfButtonClickAsync(object sender, RoutedEventArgs e)
        {
            string newText = "Changed using WPF button";
            webView.ExecuteScriptAsync($"window.postMessage('{newText}', '*');");
        }

        private void SetHeaderColors()
        {
            //_headerGrid.Background = new SolidColorBrush(GetWindowsMediaColor(ClientControl.Instance.Theme.BackgroundColor));
        }

        private void SetUpApplicationEventListeners()
        {
            //set up ViewItem event listeners
            _viewItemManager.PropertyChangedEvent += new EventHandler(ViewItemManagerPropertyChangedEvent);

            _themeChangedReceiver = EnvironmentManager.Instance.RegisterReceiver(new MessageReceiver(ThemeChangedIndicationHandler),
                                             new MessageIdFilter(MessageId.SmartClient.ThemeChangedIndication));

        }

        private void RemoveApplicationEventListeners()
        {
            //remove ViewItem event listeners
            _viewItemManager.PropertyChangedEvent -= new EventHandler(ViewItemManagerPropertyChangedEvent);

            EnvironmentManager.Instance.UnRegisterReceiver(_themeChangedReceiver);
            _themeChangedReceiver = null;
        }

        /// <summary>
        /// Method that is called immediately after the view item is displayed.
        /// </summary>
        public override void Init()
        {
            SetUpApplicationEventListeners();
            //_nameTextBlock.Text = _viewItemManager.SomeName;
        }

        /// <summary>
        /// Method that is called when the view item is closed. The view item should free all resources when the method is called.
        /// Is called when userControl is not displayed anymore. Either because of 
        /// user clicking on another View or Item has been removed from View.
        /// </summary>
        public override void Close()
        {
            RemoveApplicationEventListeners();
        }

        #endregion

        #region Print method

        /// <summary>
        /// Method that is called when print is activated while the content holder is selected.
        /// </summary>
        public override void Print()
        {
            Print("Name of this item", "Some extra information");
        }

        #endregion

        #region Component events

        private void ViewItemWpfUserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                FireClickEvent();
            }
            else if (e.ChangedButton == MouseButton.Right)
            {
                FireRightClickEvent(e);
            }
        }

        private void ViewItemWpfUserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                FireDoubleClickEvent();
            }
        }

        /// <summary>
        /// Signals that the form is right clicked
        /// </summary>
        public event EventHandler RightClickEvent;

        /// <summary>
        /// Activates the RightClickEvent
        /// </summary>
        /// <param name="e">Event args</param>
        protected virtual void FireRightClickEvent(EventArgs e)
        {
            if (RightClickEvent != null)
            {
                RightClickEvent(this, e);
            }
        }

        void ViewItemManagerPropertyChangedEvent(object sender, EventArgs e)
        {
            //_nameTextBlock.Text = _viewItemManager.SomeName;
        }

        private object ThemeChangedIndicationHandler(VideoOS.Platform.Messaging.Message message, FQID destination, FQID source)
        {
            SetHeaderColors();
            return null;
        }

        #endregion

        #region Component properties

        /// <summary>
        /// Gets boolean indicating whether the view item can be maximized or not. <br/>
        /// The content holder should implement the click and double click events even if it is not maximizable. 
        /// </summary>
        public override bool Maximizable
        {
            get { return true; }
        }

        /// <summary>
        /// Tell if ViewItem is selectable
        /// </summary>
        public override bool Selectable
        {
            get { return true; }
        }

        /// <summary>
        /// Make support for Theme colors to show if this ViewItem is selected or not.
        /// </summary>
        public override bool Selected
        {
            get
            {
                return base.Selected;
            }
            set
            {
                base.Selected = value;
                SetHeaderColors();
            }
        }



        #endregion
    }
}
