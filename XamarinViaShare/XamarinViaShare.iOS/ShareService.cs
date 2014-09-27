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
            //NSLog(@"shareButton pressed");

            //NSString *texttoshare = _txt; //this is your text string to share
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

            //UIActivityViewController *activityController = [[UIActivityViewController alloc] initWithActivityItems:sharingItems applicationActivities:nil];
            //[self presentViewController:activityController animated:YES completion:nil];
}
}
        }
    }
}