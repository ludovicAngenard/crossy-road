using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public void SaveScore(string pseudo, int score)
    {
        string currentLevel = SceneManager.GetActiveScene().name.ToLower();
        Scores scores = LoadFromJson();

        if(scores.levels.ContainsKey(currentLevel))
        {
                scores.levels[currentLevel].pseudo = pseudo;
                scores.levels[currentLevel].score = score;
            try
            {
                string json = JsonConvert.SerializeObject(scores);
                System.IO.File.WriteAllText(Application.persistentDataPath + "/ScoresData.json", json);
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Error while saving json file: " + ex.Message);
            }
        }
        else
        {
            Debug.LogError("the level " + currentLevel + " is not available !");
        }
    }

    private Scores LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/ScoresData.json";
        Debug.Log(filePath);
        string scoresData = System.IO.File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<Scores>(scoresData);
    }

    public string GetHighScore(int level)
    {
        string lvl = "level" + level.ToString();
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

    public ScoreList(string _pseudo, int _score){
        _pseudo = pseudo;
        _score = score;
    }
}
