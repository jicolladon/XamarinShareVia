using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Xamarin.Forms;
using System.ComponentModel.Design;
using System.Drawing;
using MonoTouch.MobileCoreServices;
using MonoTouch.MessageUI;
using MonoTouch.Twitter;
using MonoTouch.CoreFoundation;
using MonoTouch.Social;
using MonoTouch.Foundation;

[assembly: Dependency(typeof(XamarinViaShare.iOS.ShareService))]
namespace XamarinViaShare.iOS
{
    public class ShareService : IShareService
    {

        public void Share(string title, string details, string url)
        {

            //NSLog(@"shareButton pressed");
            NSArray textToShare2 = new NSArray();
            var activityItems = new NSObject[] { new NSString(title), new NSString(details), new NSUrl(url) };
            
            var excludedActivityTypes = new NSString[] 
            {
                UIActivityType.Print,
                UIActivityType.AssignToContact
            };
                
            var homeViewController = UIApplication.SharedApplication.Windows[0].RootViewController;
            var activityViewController = new UIActivityViewController(activityItems, null);

            homeViewController.PresentViewController(activityViewController, true, null);
          
        }

        public void OpenMail(string email, string subject, string body)
        {
            MFMailComposeViewController _mailController = new MFMailComposeViewController();
            _mailController.SetToRecipients(new string[] {email});
            _mailController.SetSubject(subject);
            _mailController.SetMessageBody(body, false);
            
            _mailController.Finished += (object s, MFComposeResultEventArgs args) =>
            {
                Console.WriteLine(args.Result.ToString());
                args.Controller.DismissViewController(true, null);
            };
            var homeViewController = UIApplication.SharedApplication.Windows[0].RootViewController;
            homeViewController.PresentViewController(_mailController, true, null);
        }

        public void Tweet()
        {
            //works
            var homeViewController = UIApplication.SharedApplication.Windows[0].RootViewController;

            var tweet = new TWTweetComposeViewController();

            tweet.SetInitialText("Tweeting from my iOS app");
                
            tweet.AddUrl (new NSUrl("http://xamarin.com"));
            tweet.SetCompletionHandler((TWTweetComposeViewControllerResult r) =>
            {
                homeViewController.DismissViewController(true,null); // hides the tweet
                if (r == TWTweetComposeViewControllerResult.Cancelled)
                {
                    // user cancelled the tweet
                }
                else
                {
                    return;
                }
            });
            homeViewController.PresentViewController(tweet, true,null);

        }
    }
}