using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TicTacToe.Generics;
using TicTacToe.Gameplay;

namespace TicTacToe.Grid
{
    public class GridService : GenericMonoSingleton<GridService>
    {
        [SerializeField]
        private GridCell[] grid;

        public int CheckForWin()
        {
            if(EvaluateGrid()==10 || EvaluateGrid() == -10)
            {
                return 1;
            }
            if(!IsMovesLeft())
            {
                return 0;
            }
            else{
                return -1;
            }
        }

        private int EvaluateGrid()
        {
            for(int row =0; row<3; row++)
            {
                if(((GridCell)(grid[(row*3)+0])).GetCellState()==((GridCell)grid[(row*3)+1]).GetCellState() && ((GridCell)grid[(row*3)+1]).GetCellState()==(grid[(row*3)+2]).GetCellState() && grid[(row*3)+1].GetCellState()!= CellState.EMPTY)
                {
                    if(grid[(row*3)].GetCellState() == (CellState)GameplayService.Instance.GetCurrentState())
                    {
                        return 10;
                    }
                    else
                    {
                        return -10;
                    }
                }
                
            }
            for(int column = 0; column<3; column++)
            {
                if(grid[(0*3)+column].GetCellState()==grid[(1*3)+column].GetCellState() && grid[(1*3)+column].GetCellState()==grid[(2*3)+column].GetCellState() && grid[(2*3)+column].GetCellState()!= CellState.EMPTY)
                {
                    if(grid[column].GetCellState() == (CellState)GameplayService.Instance.GetCurrentState())
                    {
                        return 10;
                    }
                    else
                    {
                        return -10;
                    }
                } 
            }
            if((grid[0].GetCellState()==grid[4].GetCellState() && grid[4].GetCellState()==grid[8].GetCellState()) || (grid[2].GetCellState()==grid[4].GetCellState() && grid[4].GetCellState()==grid[6].GetCellState()))
            {
                if(grid[4].GetCellState()!= CellState.EMPTY)
                {
                    if(grid[4].GetCellState() == (CellState)GameplayService.Instance.GetCurrentState())
                    {
                        return 10;
                    }
                    else
                    {
                        return -10;
                    }
                }
            }
            return 0;
        }

        private bool IsMovesLeft()
        {
            for(int i=0; i<9; i++)
            {
                if(grid[i].GetCellState()==CellState.EMPTY)
                {
                    return true;
                }
            }
            return false;
        }

        private int MinMax(int depth, bool isMax)
        {
            int score = EvaluateGrid();
            if(score == 10)
            {
                return score-depth;
            }
            else if(score == -10)
            {
                return score+depth;
            }

            if(!IsMovesLeft())
            {
                return 0;
            }
            if(isMax)
            {
                int best = -1000;
                for(int i =0; i<9; i++)
                {
                    if(grid[i].GetCellState()==CellState.EMPTY)
                    {
                        grid[i].SetCellStateTemporery(GameplayService.Instance.GetCurrentState());
                        best = Mathf.Max(best, MinMax(depth+1, !isMax));
                        grid[i].SetCellStateTemporery(CellState.EMPTY);
                    }
                }
                return best;
            }
            else
            {
                int best = 1000;
                for(int i =0; i<9; i++)
                {
                    if(grid[i].GetCellState()==CellState.EMPTY)
                    {
                        grid[i].SetCellStateTemporery(GameplayService.Instance.GetNonActiveState());
                        best = Mathf.Min(best, MinMax(depth+1, !isMax));
                        grid[i].SetCellStateTemporery(CellState.EMPTY);
                    }
                }
                return best;
            }
        }

        public void MakeBestMove()
        {
            //Finding the best possible move using minmax approach

            int bestMove = -1;
            int bestValue = -1000;
            for(int  i =0; i<9; i++)
            {
                if(grid[i].GetCellState()==CellState.EMPTY)
                {
                    grid[i].SetCellStateTemporery(GameplayService.Instance.GetCurrentState());
                    int moveVal = MinMax(0, false);
                    grid[i].SetCellStateTemporery(CellState.EMPTY);

                    if(moveVal > bestValue)
                    {
                        bestValue = moveVal;
                        bestMove = i;
                    }
                }
            }
            if(bestMove == -1)
            {
                bestMove = 4;
            }
            SetCellToState(bestMove, GameplayService.Instance.GetCurrentState());
        }

        public void SetCellToState(int _cellindex, GameplayState _state)
        {
            grid[_cellindex].SetCellState(_state);
            GameplayService.Instance.ToggleState();
        }
    }
}
