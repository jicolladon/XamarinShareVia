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
            Tweet();
            return;
            //NSLog(@"shareButton pressed");
            NSArray textToShare = NSArray.FromObjects(details);
            NSArray textToShare2 = new NSArray();
            var activityItems = new NSObject[] { new NSString(details )};
            
            var excludedActivityTypes = new NSString[] 
            {
                UIActivityType.Print,
                UIActivityType.AssignToContact
            };
                
            var homeViewController = UIApplication.SharedApplication.Windows[0].RootViewController;
            var activityViewController = new UIActivityViewController(activityItems, null);

            
            
            activityViewController.ExcludedActivityTypes = excludedActivityTypes;
            //var navigationController = new UINavigationController(homeViewController);
            
            homeViewController.PresentViewController(activityViewController, true, null);
            //this is your text string to share
            //UIImage *imagetoshare = _img; //this is your image to share
            //NSArray *activityItems = @[texttoshare, imagetoshare];    
            //UIActivityViewController *activityVC = [[UIActivityViewController alloc] initWithActivityItems:activityItems applicationActivities:nil];
            //activityVC.excludedActivityTypes = @[UIActivityTypeAssignToContact, UIActivityTypePrint];
            //[self presentViewController:activityVC animated:TRUE completion:nil];

            //func shareTextImageAndURL(#sharingText: String?, sharingImage: UIImage?, sharingURL: NSURL?) {
            //var sharingItems = [AnyObject]()

            //if let text = sharingText {
            //sharingItems.append(text)
            //}
            //if let image = sharingImage {
            //sharingItems.append(image)
            //}
            //if let url = sharingURL {
            //sharingItems.append(url)
            //}

            //let activityViewController = UIActivityViewController(activityItems: sharingItems, applicationActivities: nil)
            //self.presentViewController(activityViewController, animated: true, completion: nil)

            //- (void)shareText:(NSString *)text andImage:(UIImage *)image andUrl:(NSURL *)url
            //{
            //NSMutableArray *sharingItems = [NSMutableArray new];

            //if (text) {
            //[sharingItems addObject:text];
            //}
            //if (image) {
            //[sharingItems addObject:image];
            //}
            //if (url) {
            //[sharingItems addObject:url];
            //}

            //UIActivityViewController activityController = [[UIActivityViewController alloc] initWithActivityItems:sharingItems applicationActivities:nil];
            //[self presentViewController:activityController animated:YES completion:nil];
        }


        //void Share2(string title, string details, string url)
        //{
        //    UIActivityViewController activityViewController = new UIActivityViewController(new NSObject[] {
        //        new NSString(details),
        //    }, null);

        //    // Set a completion handler to handle what the UIActivityViewController returns
        //    activityViewController.SetCompletionHandler((activityType, completed, returnedItems, error) =>
        //    {
        //        if (returnedItems == null
        //           || returnedItems.Length == 0)
        //            return;

        //        NSExtensionItem extensionItem = returnedItems[0];
        //        NSItemProvider imageItemProvider = extensionItem.Attachments[0];

        //        if (!imageItemProvider.HasItemConformingTo(UTType.Text))
        //            return;
        //    });
        //    var homeViewController = UIApplication.SharedApplication.Windows[0].RootViewController;

        //    homeViewController.PresentViewController(activityViewController, true, null);
        //}

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
            var homeViewController = UIApplication.SharedApplication.Windows[0].RootViewController;

            if (!TWTweetComposeViewController.CanSendTweet)
            {
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
            else
            {
                // Show a message: Twitter may not be configured in Settings
            }
        }
    }
}