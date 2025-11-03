namespace CrossingCat
{
    using UnityEngine;
    [System.Serializable]
    public class GameData
    {
        public int level;
        public GameData()
        {
        }
    }

    public class DataManager : MonoBehaviour
    {

        public GameData data;
        public string saveName;
        public void SaveData()
        {
            string jsonData = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(saveName, jsonData);
            PlayerPrefs.Save();
        }

        public void LoadData()
        {
            data = new GameData();
            if (PlayerPrefs.HasKey(saveName))
            {
                string jsonData = PlayerPrefs.GetString(saveName);
                JsonUtility.FromJsonOverwrite(jsonData, data);
                Debug.Log("Data loaded successfully!");
            }
            else
            {
                Debug.Log("No save data found. Using default data.");
            }
        }

        public void ResetData()
        {
            data = new GameData();
            SaveData();
            Debug.Log("Data has been reset.");
        }
    }
}
