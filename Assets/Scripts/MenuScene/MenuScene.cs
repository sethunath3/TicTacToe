using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TicTacToe.Utilities;

namespace TicTacToe.Menu
{
    public class MenuScene : MonoBehaviour
    {
        [SerializeField]
        private Text winHistory;
        private void Start() {
            winHistory.text =  "You have won " + DataSaver.LoadData().noOfWins + " times";
        }
        public void OnPlayWithAI()
        {
            PlayerPrefs.SetInt("AI_MODE", 1);
            SceneManager.LoadScene("Gameplay");
        }
        public void OnPlayWithFriend()
        {
            PlayerPrefs.SetInt("AI_MODE", 0);
            SceneManager.LoadScene("Gameplay");
        }
    }
}
