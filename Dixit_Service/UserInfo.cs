using Dixit_Logic.Interfaces;
using Dixit_ServiceLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dixit_Service
{
    public class UserInfo
    {
        public string Username;
        public IDixitServiceCallback Callback;
    }
}