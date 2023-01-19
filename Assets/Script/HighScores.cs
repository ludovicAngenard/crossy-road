using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json;

public class HighScores : MonoBehaviour
{
    public Scores scores = new Scores();
    public static HighScores instance;

    private void Awake()
    {
        if (instance != null){
            Destroy(this.gameObject);
            Debug.LogWarning("HighScores instance alreay exists !");
            return;
        }
        else instance = this;
    }


    public void SaveScore()
    {
        string scoresData = JsonUtility.ToJson(scores);
        string filePath = Application.persistentDataPath + "/ScoresData.json";
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath, scoresData);
        Debug.Log("Scores enregistrés !");

    }

    private Scores LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/ScoresData.json";
        string scoresData = System.IO.File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<Scores>(scoresData);
    }

    public string GetHighScore(int level)
    {
        string lvl = "level" + level;
        Scores scores = LoadFromJson();

        return scores.levels.ContainsKey(lvl) != null ? scores.levels[lvl].pseudo + " " + scores.levels[lvl].score : null; 

    }
}

[System.Serializable]
public class Scores
{
    public Dictionary<string, ScoreList> levels = new Dictionary<string, ScoreList>(); 
}

[System.Serializable]
public class ScoreList
{
    public string pseudo;
    public int score;
}
