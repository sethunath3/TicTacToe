using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe.Gameplay
{
    public class OState : GameState
    {
        public OState(bool _isAi)
        {
            isAI = _isAi;
        }
        public override GameplayState GetCurrentState()
        {
            return GameplayState.OSTATE;
        }
    }
}

