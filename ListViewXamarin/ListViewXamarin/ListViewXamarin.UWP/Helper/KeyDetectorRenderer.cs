using ListViewXamarin;
using ListViewXamarin.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.ViewManagement;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(KeyDetector), typeof(KeyDetectorRenderer))]
namespace ListViewXamarin.UWP
{
    public class KeyDetectorRenderer : VisualElementRenderer<KeyDetector, CustomControl>
    {
        #region Fields

        private CustomControl control;

        #endregion

        #region Override Methods

        protected override void OnElementChanged(ElementChangedEventArgs<KeyDetector> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                this.control = new CustomControl();
                this.SetNativeControl(this.control);

                this.Control.IsTabStop = true;
                this.KeyDown += KeyDetectorRenderer_KeyDown;
                try
                {
                    if (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
                    {
                        ApplicationView.GetForCurrentView().SetDesiredBoundsMode(ApplicationViewBoundsMode.UseVisible);
                    }
                }
                catch
                {
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            this.KeyDown -= KeyDetectorRenderer_KeyDown;
            this.control = null;
            base.Dispose(disposing);
        }

        #endregion

        #region Events

        private void KeyDetectorRenderer_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                this.Element.RaiseSelectionForListView();
            }
        }

        #endregion
    }

    public class CustomControl : Control
    {

    }
}