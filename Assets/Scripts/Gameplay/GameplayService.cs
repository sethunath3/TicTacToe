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

    public enum GameResult
    {
        WON,
        LOSE,
        TIED
    }
    public class GameplayService : GenericMonoSingleton<GameplayService>
    {
        [SerializeField]
        private GameOverPanel panelScript;
        private GameplayState gameplayState;
        private bool isAiTurn;
        private bool isAiMode;
        
        void Start()
        {
            gameplayState = GameplayState.OSTATE;
            isAiTurn = false;
            isAiMode = PlayerPrefs.GetInt("AI_MODE") == 1 ? true : false;
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
            switch(GridService.Instance.CheckForWin())
            {
                case 0:
                panelScript.GameOver(true,"");
                break;

                case 1:
                string wonChar = "X";
                if(gameplayState == GameplayState.OSTATE)
                {
                    wonChar = "0";
                }
                panelScript.GameOver(false, wonChar);
                break;

                case -1:
                ProceedToggleState();
                break;
            }
            
        }
        private void ProceedToggleState()
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

