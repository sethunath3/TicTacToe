using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TicTacToe.Generics;
using TicTacToe.Grid;

namespace TicTacToe.Gameplay{

    public enum GameplayState
    {
        OSTATE = 0,
        XSTATE
    }
    public class GameplayService : GenericMonoSingleton<GameplayService>
    {
        private GameplayState gameplayState;
        private bool isAiTurn;
        private bool isAiMode;
        
        void Start()
        {
            gameplayState = GameplayState.OSTATE;
            isAiTurn = false;
            isAiMode = true;
        }

        public GameplayState GetCurrentState()
        {
            return gameplayState;
        }

        public GameplayState GetNonActiveState()
        {
            if(gameplayState == GameplayState.OSTATE)
            {
                return GameplayState.XSTATE;
            }
            else
            {
                return GameplayState.OSTATE;
            }
        }

        public void ToggleState()
        {
            if(GridService.Instance.CheckForWin())
            {
                Debug.Log("win");
            }
            else
            {
                if(gameplayState == GameplayState.OSTATE)
                {
                    gameplayState = GameplayState.XSTATE;
                }
                else{
                    gameplayState = GameplayState.OSTATE;
                }
                if(isAiMode)
                {
                    isAiTurn = !isAiTurn;
                    if(isAiTurn)
                    {
                        GridService.Instance.MakeBestMove();
                        ToggleState();
                    }
                }
            }
        }
    }
}

