using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(XamarinViaShare.iOS.ShareService))]
namespace XamarinViaShare.iOS
{
    public class ShareService
    {
        public void Share(string title, string details, string url)
        {

        }
    }
}