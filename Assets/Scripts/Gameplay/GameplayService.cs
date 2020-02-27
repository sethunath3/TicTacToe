using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TicTacToe.Generics;
using TicTacToe.Grid;

namespace TicTacToe.Gameplay
{

    public class GameplayService : GenericMonoSingleton<GameplayService>
    {
        [SerializeField]
        private GameOverPanel panelScript;


        private GameState currentState;
        private XState xState;
        private OState oState;
        
        void Start()
        {
            bool isAiMode = PlayerPrefs.GetInt("AI_MODE") == 1 ? true : false;
            if(isAiMode)
            {
                bool aiChooser = Random.value > 0.5f;
                xState = new XState(aiChooser);
                oState = new OState(!aiChooser);
            }
            else{
                xState = new XState(false);
                oState = new OState(false);
            }

            currentState = xState;
            ToggleState();
        }

        public void ToggleState()
        {
            if(currentState != null)
            {
                currentState.OnExitState();
            }
            
            if(currentState.GetCurrentState()==GameplayState.OSTATE)
            {
                currentState = xState;
            }
            else{
                currentState = oState;
            }

            currentState.OnEnterState();
        }

        public GameplayState GetCurrentState()
        {
            return currentState.GetCurrentState();
        }

        public GameplayState GetNonActiveState()
        {
            if(currentState.GetCurrentState() == GameplayState.OSTATE)
            {
                return GameplayState.XSTATE;
            }
            else
            {
                return GameplayState.OSTATE;
            }
        }

        public void GameOver(bool isATie, GameplayState winner)
        {
            if(isATie)
            {
                panelScript.GameOver(true,"");
            }
            else{
                string wonChar = "X";
                if(GetCurrentState() == GameplayState.OSTATE)
                {
                    wonChar = "0";
                }
                panelScript.GameOver(false, wonChar);
            }
        }
    }
}

