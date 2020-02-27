using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe.Utilities
{
    public class PlayerData
    {
        public int noOfWins;        
    }

    public static class DataSaver
    {
        public static void SaveData(PlayerData _data)
        {
            string jsonData = JsonUtility.ToJson(_data);
            PlayerPrefs.SetString("PlayerData", jsonData);
            PlayerPrefs.Save();
        }

        public static PlayerData LoadData()
        {
            string jsonData = PlayerPrefs.GetString("PlayerData", JsonUtility.ToJson(new PlayerData()));
            PlayerData loadedData = JsonUtility.FromJson<PlayerData>(jsonData);

            return loadedData;

            
        }
        
    }
}
