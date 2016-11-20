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
        public Model Model;

        public DixitServiceCallback(Model model)
        {
            Model = model;
        } 
        public void GameEnd(GameState state)
        {
            Model.OnGameEnd(state);
        }
        public void GameStart(GameState state)
        {
            Model.OnGameStart(state);
        }
        public void GameStateChanged(GameState state)
        {
            Model.OnGameStateChanged(state);
        }
        public void GuessPhaseEnd()
        {
            Model.OnGuessPhaseEnd();
        }
        public void PuttingPhaseEnd()
        {
            Model.OnPuttingPhaseEnd();
        }
    }
}
