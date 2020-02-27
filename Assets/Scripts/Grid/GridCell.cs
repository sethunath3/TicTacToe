using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TicTacToe.Gameplay;

namespace TicTacToe.Grid{

    public enum CellState
    {
        EMPTY = 0,
        CROSS = 1,
        CIRCLE = 2
    }

    public class GridCell : MonoBehaviour
    {
        [SerializeField]
        private Button btn;

        [SerializeField]
        private Sprite XGrapic;
        [SerializeField]
        private Sprite OGrapic;

        public CellState cellState;

        private void Start()
        {
            cellState = CellState.EMPTY;
        }

        public void SetCellState(GameplayState _state)
        {
            cellState = (CellState)_state;
            if(cellState == CellState.CIRCLE)
            {
                btn.image.sprite = OGrapic;
            }
            else{
                btn.image.sprite = XGrapic;
            }
            btn.interactable = false;

        }

        public void SetCellStateTemporery(GameplayState _state)
        {
            cellState = (CellState)_state;
        }
        public void SetCellStateTemporery(CellState _state)
        {
            cellState = _state;
        }

        public void OnCellClick()
        {
            SetCellState(GameplayService.Instance.GetCurrentState());
            GameplayService.Instance.ToggleState();
        }

        public CellState GetCellState()
        {
            return cellState;
        }
    }
}
