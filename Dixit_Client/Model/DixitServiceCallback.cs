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

        public void GameEnd(GameState state)
        {
            throw new NotImplementedException();
        }

        public void GameEnd(object state)
        {
            GameEndEvent?.Invoke(this, EventArgs.Empty);
        }

        public void GameStart(GameState state)
        {
            throw new NotImplementedException();
        }

        public void GameStart(object state)
        {
            GameStartEvent?.Invoke(this, EventArgs.Empty);
        }

        public void GameStateChanged(GameState state)
        {
            throw new NotImplementedException();
        }

        public void GameStateChanged(object state)
        {
            GameStateChangedEvent?.Invoke(this, EventArgs.Empty);
        }

        public void GuessPhaseEnd()
        {
            throw new NotImplementedException();
        }

        public void PuttingPhaseEnd()
        {
            throw new NotImplementedException();
        }
    }
}
