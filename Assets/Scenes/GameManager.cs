using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int highScore;
    public string playerName;
    public string playerNameHighScore;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);


    }
    // Start is called before the first frame update
    void Start()
    {
        //playerNameHighScore = "";
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"Game Manager Name: " + playerName);
    }
    [System.Serializable]
    class SaveData
    {
        public int highScore;
        //public string playerName;
        public string playerNameHighScore;
    }
    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.playerNameHighScore = playerNameHighScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "HighScoreData.json",json);
    }
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "HighScoreData.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScore = data.highScore;
            playerNameHighScore = data.playerNameHighScore;
        }
    }
}
