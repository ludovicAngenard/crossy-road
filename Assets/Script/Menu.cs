using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class Menu : MonoBehaviour
{
    public Button btnPlay;
    public Button btnSetting;
    public Button btnQuit;

    public Button btnBeginner;
    public Button btnIntermediate;
    public Button btnExpert;
    public Button btnReturnMenuLevel;

    public Slider volumeSlider;
    public TextMeshProUGUI volumeLabel;
    public Button btnResetScore;
    public Button btnReturnSettings;

    private bool viewActive;

    public GameObject menu;
    public GameObject option;
    public GameObject levelView;

    public TextMeshProUGUI[] highScoreLvl;
    
    private float _volume;

    public float volume
    {
        get => _volume;
        set
        {
            _volume = value;
            AudioListener.volume = value;
            volumeLabel.text = value.ToString();
        }
    }

    void Start()
    {
        volumeSlider.minValue = 0f;
        volumeSlider.maxValue = 1f;

        // add listener
        btnPlay.onClick.AddListener(ToggleActiveViewLevel);
        btnSetting.onClick.AddListener(ToggleActiveViewOption);
        btnQuit.onClick.AddListener(Quit);

        btnBeginner.onClick.AddListener(() => LoadLevel("1"));
        btnIntermediate.onClick.AddListener(() => LoadLevel("2"));
        btnExpert.onClick.AddListener(() => LoadLevel("3"));
        btnReturnMenuLevel.onClick.AddListener(ToggleActiveViewLevel);

        btnResetScore.onClick.AddListener(ResetScore);
        btnReturnSettings.onClick.AddListener(ToggleActiveViewOption);

        // get high score by level
        highScoreLvl[0].text = HighScores.instance.GetHighScore(1);
        highScoreLvl[1].text = HighScores.instance.GetHighScore(2);
        highScoreLvl[2].text = HighScores.instance.GetHighScore(3);
    }

    void Update()
    {
        volume = volumeSlider.value;
    }

    void Quit()
    {
        Application.Quit();
    }

    void LoadLevel(string level)
    {
        Manager.level = int.Parse(level);
        SceneManager.LoadScene("level1");
    }

    void ToggleActiveViewLevel()
    {
        viewActive = levelView.activeInHierarchy;
        levelView.SetActive(!viewActive);
        menu.SetActive(viewActive);
    }

    void ToggleActiveViewOption()
    {
        viewActive = option.activeInHierarchy;
        option.SetActive(!viewActive);
        menu.SetActive(viewActive);
    }

    public void ResetScore()
    {
        string filePath = Application.persistentDataPath + "/score.json";
        if (IsFileLocked(filePath))
        {
            throw new IOException("File is locked, cannot clear it.");
        }

        File.WriteAllText(filePath, "{}");
    }

    private bool IsFileLocked(string filePath)
    {
        try
        {
            using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {
                stream.Close();
            }
        }
        catch (IOException)
        {
            return true;
        }

        return false;
    }
    
}


