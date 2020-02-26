using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TicTacToe.Menu
{
    public class MenuScene : MonoBehaviour
    {
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
