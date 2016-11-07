using Dixit_Client.DixitService1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixit_Client.Model
{
    public class DixitServiceCallback : IDixitServiceCallback
    {
        public EventHandler GameEndEvent;
        public EventHandler GameStartEvent;
        public EventHandler GameStateChangedEvent;

        public void GameEnd(object state)
        {
            GameEndEvent.Raise(this);
        }
        public void GameStart(object state)
        {
            GameStartEvent.Raise(this);
        }
        public void GameStateChanged(object state)
        {
            GameStateChangedEvent.Raise(this);
        }
    }
}
