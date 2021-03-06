﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixit_Logic.Interfaces
{
    /// <summary>
    /// This is a game's round interface. It cointain what need to a round of dixit game.
    /// </summary>
    public interface IDixitGame
    {
        /// <summary>
        /// This holds the actual game state what is changed by actions during the game.
        /// </summary>
        IGameState ActualGameState
        {
            get;
        }

        /// <summary>
        /// This add a new player (by name) to the ActualGameState.
        /// </summary>
        /// <param name="name">The name of the player.</param>
        /// <returns>The new player</returns>
        IPlayer AddPlayer(string name);

        /// <summary>
        /// This method remove a player from the gameState player list
        /// </summary>
        /// <param name="player">The player what we want to remove</param>
        /// <returns> rerturn true if player is successfully removed; otherwise, false.</returns>
        bool RemovePlayer(IPlayer player);

        /// <summary>
        /// Start a new game.
        /// </summary>
        /// <returns>true if the method could start the game, otherwise false</returns>
        bool StartGame();

        /// <summary>
        /// This method add a new association text.
        /// </summary>
        /// <param name="storyText">An association text string</param>
        /// <param name="player">The player who guess the text</param>
        /// <returns>true if the method could add storyText to the game state, otherwise false</returns>
        bool AddAssociationText(string storyText, IPlayer player);

        /// <summary>
        /// This method put a card from the player's hands to the board deck(in ActualGameState).
        /// </summary>
        /// <param name="player">The player who put the card</param>
        /// <param name="card">The card what will be put by "player".</param>
        void PutCard(IPlayer player, ICard card);

        /// <summary>
        /// This will add a new guess to what was the original card in the actual turn.
        /// The guess will be assigned to the given player (in ActualGameState). 
        /// </summary>
        /// <param name="player">The player who add the guess</param>
        /// <param name="card">The card is guessed by "player"</param>
        void NewGuess(IPlayer player, ICard card);

        /// <summary>
        /// This evaluates the points of actual turn and adds these to the appropriate players's point (in ActualGameState).         
        /// </summary>
        void EvaluatePoints();

        /// <summary>
        /// This event is triggered when all players put a card in a turn.
        /// </summary>
        event EventHandler PuttingPhaseEnd;

        /// <summary>        
        /// This event is triggered when all players make a guess in a turn.
        /// </summary>
        event EventHandler GuessPhaseEnd;

        /// <summary>     
        /// This event is triggered at the start of a trun when all cards are consumed from the MainDeck and players have no more cards too .
        /// </summary>
        event EventHandler GameEnd;
    }
}
