using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixit_Logic.Interfaces
{
    /// <summary>
    /// This is a general game card inteface.
    /// </summary>
    interface ICard
    {
        /// <summary>
        /// It is a unique identifier for card.
        /// </summary>
        int Id
        {
            get;
            set;
        }
    }
}
