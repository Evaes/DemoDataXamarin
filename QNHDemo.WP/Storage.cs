using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.IsolatedStorage;

namespace QNHDemo.WP
{
    public class Storage
    {
        IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication();

        public void StoreLogin(string username, string token)
        {
         
            
        }

    }
}
