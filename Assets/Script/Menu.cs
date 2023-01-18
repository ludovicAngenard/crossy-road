using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button btnPlay;
    public Button btnSetting;
    public Button btnQuit;
    
    public Button btnBeginner;
    public Button btnIntermediate;
    public Button btnExpert;

    public Slider volumeSlider;
    public TextMeshProUGUI volumeLabel;
    public Button btnResetScore;
    public Button btnReturn;
    
    public bool viewActive;

    public GameObject menu;
    public GameObject option;
    public GameObject levelView;

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
    void Start() {
        volumeSlider.minValue = 0f;
        volumeSlider.maxValue = 1f;
        btnPlay.onClick.AddListener(ToggleActiveViewLevel);
        btnBeginner.onClick.AddListener(LoadPreviousScene);
        btnIntermediate.onClick.AddListener(LoadPreviousScene);
        btnExpert.onClick.AddListener(LoadPreviousScene);
        btnSetting.onClick.AddListener(ToggleActiveViewOption);
        btnReturn.onClick.AddListener(ToggleActiveViewOption);
        
        btnQuit.onClick.AddListener(Quit);

    }

    void Update() { volume = volumeSlider.value; }
    
    void Quit() { Application.Quit(); }
    void LoadPreviousScene() { SceneManager.LoadScene("SampleScene"); }
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


}