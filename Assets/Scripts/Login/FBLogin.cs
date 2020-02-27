using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.SceneManagement;

namespace TicTacToe.Login
{
    public class FBLogin : MonoBehaviour
    {
        private void Awake()
        {
            if(!FB.IsInitialized)
            {
                FB.Init(() => {
                    if(FB.IsInitialized)
                    {
                        FB.ActivateApp();
                        // SceneManager.LoadScene("MenuScene");
                    }
                    else{
                        Debug.LogError("FB Initialization failed");
                    }
                },
                isGameShown => {
                    if(!isGameShown)
                    {
                        Time.timeScale = 0;
                    }
                    else{
                        Time.timeScale = 1;
                        SceneManager.LoadScene("MenuScene");
                    }
                });
            }
            else
            {
                FB.ActivateApp();
                SceneManager.LoadScene("MenuScene");
            }
        }

        public void ContinueAsGuest()
        {
            SceneManager.LoadScene("MenuScene");
        }


        #region Login/Logout
        public void FacebookLogin()
        {
            var permissions = new List<string>() {"public_profile", "email"};
            FB.LogInWithReadPermissions(permissions, (ILoginResult result) => {
                if (FB.IsLoggedIn)
                {
                    // AccessToken class will have session details
                    var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
                    // Print current access token's User ID
                    Debug.Log(aToken.UserId);
                    // Print current access token's granted permissions
                    foreach (string perm in aToken.Permissions)            
                        Debug.Log(perm);  
                    SceneManager.LoadScene("MenuScene");
                              
                }
                else
                {
                    Debug.Log("User cancelled login");
                }
            }
            );
        }

        #endregion
    }

    
}
