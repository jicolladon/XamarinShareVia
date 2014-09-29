using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinViaShare
{
    public class MyPage : ContentPage
    {

        Button _share;
        
        Entry _title;

        Editor _description;

        Entry _url;

        public MyPage()
        {
            _share = new Button
            {
                Text = "Share!!!"
            };
            
           _title = new Entry
           {
               Placeholder = "Put here the title"
           };

           _description = new Editor
           {
               Text = "Message......",
               HeightRequest = 400,
           };

           _share.Clicked += ShareContent;

            Content = new StackLayout {
                Children = {_title, _description, _share},
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(10,10,10,10),
            };
        }

        private void ShareContent(object sender, EventArgs e)
        {
            var service = DependencyService.Get<IShareService>();
            service.Share(_title.Text, _description.Text, "http://thelostworldofsharker.esy.es");
        }
    }
}
