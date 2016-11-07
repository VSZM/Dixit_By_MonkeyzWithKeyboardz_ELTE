using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dixit_Client.DixitService1;
using System.ServiceModel;

namespace Dixit_Client.Model
{
    public class Model
    {
        private DixitServiceClient serviceclient;
        private DixitServiceCallback servicecallback;
        private bool isloggedin;

        public event EventHandler LoginFailedEvent;
        public event EventHandler LoginSuccessEvent;

        private void InitService()
        {
            servicecallback = new DixitServiceCallback();
            serviceclient = new DixitServiceClient(new InstanceContext(servicecallback));
        }

        public void Login(string username)
        {
            if (isloggedin) { return; }
            if (serviceclient == null) { InitService(); }
            try
            {
                serviceclient.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None;
                serviceclient.ClientCredentials.UserName.UserName = username;
                serviceclient.ClientCredentials.UserName.Password = "";

                serviceclient.Login();

                isloggedin = true;
                LoginSuccessEvent.Raise(this);
            }
            catch
            {
                isloggedin = false;
                LoginFailedEvent.Raise(this);
            }
        }
        public void Logout()
        {
            if (!isloggedin) { return; }
            serviceclient.Logout();
            isloggedin = false;
        }
    }
}
