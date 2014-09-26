using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinViaShare
{
    public interface IShareService
    {
        void Share(string title, string details, string url);
    }
}
