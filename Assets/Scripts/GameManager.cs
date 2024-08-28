using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [System.Serializable]
    class SaveData
    {
        public string maxScorePlayerName;
        public int maxScore;
        public string playerName;
    }
    public int maxScore=0;
    public string maxScorePlayerName;
    public string playerName;
    public static GameManager Instance;

     public void SaveData_toFile()
    {
        SaveData data = new SaveData();
        data.maxScorePlayerName = maxScorePlayerName;
        data.maxScore = maxScore;
        data.playerName = playerName;
        string json = JsonUtility.ToJson(data);
    
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadData_fromFile()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            maxScore=data.maxScore;
            maxScorePlayerName=data.maxScorePlayerName;
           
            playerName = data.playerName;

         }
    }
           private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData_fromFile();
    }
}
