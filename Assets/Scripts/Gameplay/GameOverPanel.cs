using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace TicTacToe.Gameplay
{
    public class GameOverPanel : MonoBehaviour
    {
        [SerializeField]
        private GameObject gameOverPanel;
        [SerializeField]
        private Text resultText;
        void Start()
        {
            gameOverPanel.SetActive(false);
        }

        public void GameOver(bool isTied, string wonChar)
        {
            if(isTied)
            {
                resultText.text = "Its A Tie :)";
            }
            else{
                resultText.text = wonChar + "  won :)";
            }
            gameOverPanel.SetActive(true);
        }

        public void OnContinueBtn()
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}


