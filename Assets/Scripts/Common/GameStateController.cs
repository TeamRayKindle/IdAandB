using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RayKindle
{
    public enum GameState
    {
        WaitingForPlayButtonClick,
        IntroNarration, 
        PlayerSearchingCharacter, 
        PlayerFoundCharacter, 
        PlayerInteractingWithCharacter,
        CharacterPlayingTrick,
        LettersFalling,
        MainGameFinished,
        PlayerClickedOnMiniGameIcon
    }

    public class GameStateController
    {
        // Start is called before the first frame update
       public GameStateController()
        {
            CurrentGameState = GameState.IntroNarration;
        }

        public GameState CurrentGameState { get; private set; }

        public void ChangeGameState(GameState gameState)
        {
            CurrentGameState = gameState;
        }
    }
}
