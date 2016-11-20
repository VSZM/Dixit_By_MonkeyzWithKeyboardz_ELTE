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

        public event EventHandler<Exception> LoginFailedEvent;
        public event EventHandler LoginSuccessEvent;

        public event EventHandler<GameStateEventArgs> GameEndEvent;
        public event EventHandler<GameStateEventArgs> GameStartEvent;
        public event EventHandler<GameStateEventArgs> GameStateChangedEvent;
        public event EventHandler GuessPhaseEndEvent;
        public event EventHandler PuttingPhaseEndEvent;

        private void InitService()
        {
            servicecallback = new DixitServiceCallback(this);
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
                //serviceclient.ClientCredentials.Cli

                serviceclient.Login(username);

                isloggedin = true;
                LoginSuccessEvent?.Invoke(this, EventArgs.Empty);
            }
            catch(Exception e)
            {
                isloggedin = false;
                LoginFailedEvent?.Invoke(this, e);
            }
        }
        public void Logout()
        {
            if (!isloggedin) { return; }
            serviceclient.Logout();
            isloggedin = false;
        }

        internal void OnGameEnd(GameState state)
        {
            GameEndEvent.Invoke(this, new GameStateEventArgs(state));
        }
        internal void OnGameStart(GameState state)
        {
            GameStartEvent.Invoke(this, new GameStateEventArgs(state));
        }
        internal void OnGameStateChanged(GameState state)
        {
            GameStateChangedEvent.Invoke(this, new GameStateEventArgs(state));
        }
        internal void OnGuessPhaseEnd()
        {
            GuessPhaseEndEvent?.Invoke(this, EventArgs.Empty);
        }
        internal void OnPuttingPhaseEnd()
        {
            PuttingPhaseEndEvent?.Invoke(this, EventArgs.Empty);
        }
    }

    public class GameStateEventArgs
    {
        public GameState State;
        public GameStateEventArgs(GameState state)
        {
            State = state;
        }
    }
}
