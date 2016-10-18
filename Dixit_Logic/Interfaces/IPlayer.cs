﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixit_Logic.Interfaces
{
    /// <summary>
    /// It is a game player interface. It contains the most necessary properties 
    /// and methods declaration what a player needs during a dixt game.
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// It is a unique identifier for player.
        /// </summary>
        int Id
        {
            get;
            set;
        }

        /// <summary>
        /// It put a card(by the param) from the player own cards. This card will erase from the player's cards.
        /// </summary>
        /// <param name="chosenCard">The card what the player will put.</param>
        /// <returns>It return with his chosenCard param.</returns>
        ICard PutCard(ICard chosenCard);

        /// <summary>
        /// Add a new card to the player hand (to his owen cards).
        /// </summary>
        /// <param name="newCard">The new card what will add to the player own cards</param>
        void GetCard(ICard newCard);
    }
}
