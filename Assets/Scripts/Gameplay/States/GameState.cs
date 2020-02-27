using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TicTacToe.Grid;

namespace TicTacToe.Gameplay
{
    public enum GameplayState
    { 
        XSTATE = 1,
        OSTATE = 2
    }

    // All states in the game should inherit from this. Here 'O' and 'X' 
    public abstract class GameState
    {
        protected bool isAI;
        public virtual void OnEnterState()
        {
            if(isAI)
            {
                GridService.Instance.MakeBestMove();
            }
            
            /*
            codes for online player

            else if(onlinePlayer)
            {
                GridService.Instance.SetCellToState(MultiplayerManager.GetIndexFromServer(), currentState);
            }
            */
        }
        public virtual void OnExitState()
        {
            switch(GridService.Instance.CheckForWin())
            {
                case 0:
                GameplayService.Instance.GameOver(true, GameplayState.OSTATE);
                break;

                case 1:
                GameplayService.Instance.GameOver(false, GetCurrentState());
                break;
            }
        }

        public abstract GameplayState GetCurrentState();
    }
}
