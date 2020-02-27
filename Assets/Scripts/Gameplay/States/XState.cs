using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe.Gameplay
{
    public class XState : GameState
    {
        public XState(bool _isAi)
        {
            isAI = _isAi;
        }
        public override GameplayState GetCurrentState()
        {
            return GameplayState.XSTATE;
        }
    }
}
