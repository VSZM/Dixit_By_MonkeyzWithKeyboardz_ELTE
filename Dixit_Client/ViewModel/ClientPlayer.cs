using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dixit_Logic.Classes;

namespace Dixit_Client.ViewModel
{
    public class ClientPlayer : ViewModelBase
    {
        public ClientPlayer(int id, String name)
        {
            Id = id;
            Name = name;
            Score = 0;
        }

        private int _score;
        public int Score {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
                OnPropertyChanged("Score");
            }
        }

        public int Id { get; private set; }
        public String Name { get; }
    }
}
