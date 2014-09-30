using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinViaShare;
using Microsoft.Phone.Tasks;
using Windows.ApplicationModel.DataTransfer;

[assembly: Dependency(typeof(XamarinViaShare.WinPhone.ShareService))]
namespace XamarinViaShare.WinPhone
{
    public class ShareService : IShareService
    {
        public void Share(string title, string details, string url)
        {
            ShareLinkTask shareLinkTask = new ShareLinkTask();
            shareLinkTask.Title = title;
            shareLinkTask.LinkUri = new Uri(url, UriKind.Absolute);
            shareLinkTask.Message = details;
            shareLinkTask.Show();

            ShareStatusTask share = new ShareStatusTask();
            share.Status = title + " " + details + " " + url;
            share.Show();
        }

        void ShareEighPoint1(string title, string details, string url)
        {
            var dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += (sender, args) =>
            {
                var request = args.Request;
                request.Data.Properties.Title = "Share Demonstration";
                request.Data.SetText("Hello World!");
            };
            ShareWindowsPhoneFacebook();
        }

        private async void ShareWindPhoneTwitter()
        {
            string url = "http://jmservera.com/2013/10/07/optimizar-el-canvas-de-apps-windows-en-html5javascript/";
            string texto = "Cómo optimizar código JS en Canvas";

            string shareUrl = string.Format("http://www.twitter.com/intent/tweet?url={0}&text={1}",
            System.Net.WebUtility.UrlEncode(url),
            System.Net.WebUtility.UrlEncode(texto));

            await Windows.System.Launcher.LaunchUriAsync(
            new Uri(shareUrl));
        }

        private async void ShareWindowsPhoneFacebook()
        {
            string url = "http://jmservera.com/2013/10/07/optimizar-el-canvas-de-apps-windows-en-html5javascript/";

            string shareUrl = string.Format("https://www.facebook.com/sharer/sharer.php?u={0}",
            System.Net.WebUtility.UrlEncode(url));

            await Windows.System.Launcher.LaunchUriAsync(
            new Uri(shareUrl));
        }

    }
}
