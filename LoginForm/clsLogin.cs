using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm
{
    class clsLogin
    {
       private string mUserName;
       private string mPassword;

        public string UserName
        {
            get { return mUserName; }
            set { mUserName = value; }
        }
        public string Password
        {
            get { return mPassword; }
            set { mPassword = value; }
        }
    }
}
