using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public int levelsUnlocked;



    public int HighScoreValue;
    public Button[] buttons;

    public Animator transition;

    public AudioMixer audioMixer;

    public GameObject HighScoreText;

    public Slider soundEffectSlider;

    private static readonly string soundEffectPref = "SoundEffect";
   
    private float soundEffectFloat;

    [SerializeField] Toggle Normal;
    [SerializeField] Toggle Hard;

    [Header("Skins")]
    public int SkinUnlocked;
    public int SkinUnlockedHARD;
    public int Level5;
    public int Level10;
    public int Level15;
    public int Level20;
    public int Level25;
    public int Level30;

    public int Level35;
    public int Level40;
    public int Level45;
    public int Level50;
    public int Level55;
    public int Level60;




    [SerializeField] Image SkinImage;
    [SerializeField] Image[] SkinBalls;
    [SerializeField] Button[] SkinButtons;
    [SerializeField] GameObject BallName;
    [SerializeField] Button[] SkinButtonsHARD;


    [SerializeField] Image ThunderBallImage;
    [SerializeField] Image SpiritBallImage;
    [SerializeField] Image DarkMatterBallImage;
    [SerializeField] Image MagmaBall;
    [SerializeField] Image ClockBall;
    [SerializeField] Image FutueristicBallImage;

    [SerializeField] GameObject TitleImage;



    public bool DomainExpansion = false;
    void Start()
    {
        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1);
        SkinUnlocked = PlayerPrefs.GetInt("SkinsUnlocked", 0);
        SkinUnlockedHARD = PlayerPrefs.GetInt("SkinUnlockedHARD", 0);
        TitleImage.GetComponent<TMPro.TextMeshProUGUI>().text = "Paper & Time";

        SkinManager.SkinUnlockedValue = SkinUnlocked;
        SkinManager.SkinUnlockedValueHARD = SkinUnlockedHARD;


        Level5 = PlayerPrefs.GetInt("Level5", 0);
        Level10 = PlayerPrefs.GetInt("Level10", 0);
        Level15 = PlayerPrefs.GetInt("Level15", 0);
        Level20 = PlayerPrefs.GetInt("Level20", 0);
        Level25 = PlayerPrefs.GetInt("Level25", 0);
        Level30 = PlayerPrefs.GetInt("Level30", 0);

        Level35 = PlayerPrefs.GetInt("Level35", 0);
        Level40 = PlayerPrefs.GetInt("Level40", 0);
        Level45 = PlayerPrefs.GetInt("Level45", 0);
        Level50 = PlayerPrefs.GetInt("Level50", 0);
        Level55 = PlayerPrefs.GetInt("Level55", 0);
        Level60 = PlayerPrefs.GetInt("Level60", 0);







        Time.timeScale = 1f;

       

        soundEffectSlider.value = PlayerPrefs.GetFloat(soundEffectPref);

        Normal.isOn = true;

        HighScoreText.GetComponent<TMPro.TextMeshProUGUI>().text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    private void Update()
    {

        switch (GameValues.difficult)
        {
            case GameValues.Difficulties.NORMAL:
                 for (int i = 0; i < buttons.Length; i++)
                {
                    if (i + 1 > levelsUnlocked)
                    {
                        buttons[i].interactable = false;
                    }
                    else
                        buttons[i].interactable = true;
                }
              
                break;
            case GameValues.Difficulties.HARD:
                buttons[0].interactable = true;
                for (int i = 1; i < buttons.Length; i++)
                {
              
                    buttons[i].interactable = true; // Put Back to false for testing leave as it is
                }
           
                break;

        }

        for(int k = 0; k < SkinButtons.Length; k++)
        {
            if (k > SkinUnlocked)
            {
                SkinButtons[k].interactable = false;
            }
            else
                SkinButtons[k].interactable = true;
        }

        for (int k = 0; k < SkinButtonsHARD.Length; k++)
        {
            if (k >= SkinUnlockedHARD)
            {
                SkinButtonsHARD[k].interactable = false;
            }
            else
                SkinButtonsHARD[k].interactable = true;
        }


        switch (SkinManager.skin)
        {
            
            case SkinManager.SkinType.Default:
                ThunderBallImage.enabled = false;
            
                SkinImage.enabled = true;
                SpiritBallImage.enabled = false;
                ClockBall.enabled = false;
                MagmaBall.enabled = false;
                FutueristicBallImage.enabled = false;
                DarkMatterBallImage.enabled = false;
                SkinImage.sprite = SkinBalls[0].sprite;
                BallName.GetComponent<TMPro.TextMeshProUGUI>().text = "PaperBall";
                break;
            case SkinManager.SkinType.RandomBall:
                ThunderBallImage.enabled = false;
          
                SkinImage.enabled = true;
                ClockBall.enabled = false;
                FutueristicBallImage.enabled = false;
                MagmaBall.enabled = false;
                SpiritBallImage.enabled = false;
                DarkMatterBallImage.enabled = false;
                SkinImage.sprite = SkinBalls[1].sprite;
                BallName.GetComponent<TMPro.TextMeshProUGUI>().text = "VolleyBall";
                break;
            case SkinManager.SkinType.BasketBall:
                ThunderBallImage.enabled = false;
            
                SkinImage.enabled = true;
                FutueristicBallImage.enabled = false;
                ClockBall.enabled = false;
                MagmaBall.enabled = false;
                SpiritBallImage.enabled = false;
                DarkMatterBallImage.enabled = false;
                SkinImage.sprite = SkinBalls[2].sprite;
                BallName.GetComponent<TMPro.TextMeshProUGUI>().text = "BasketBall";
                break;
            case SkinManager.SkinType.Football:
                ThunderBallImage.enabled = false;
             
                SkinImage.enabled = true;
                ClockBall.enabled = false;
                FutueristicBallImage.enabled = false;
                MagmaBall.enabled = false;
                SpiritBallImage.enabled = false;
                DarkMatterBallImage.enabled = false;
                SkinImage.sprite = SkinBalls[3].sprite;
                BallName.GetComponent<TMPro.TextMeshProUGUI>().text = "FootBall";
                break;
            case SkinManager.SkinType.TennisBall:
                ThunderBallImage.enabled = false;
               
                SkinImage.enabled = true;
                FutueristicBallImage.enabled = false;
                ClockBall.enabled = false;
                MagmaBall.enabled = false;
                SpiritBallImage.enabled = false;
                DarkMatterBallImage.enabled = false;
                SkinImage.sprite = SkinBalls[4].sprite;
                BallName.GetComponent<TMPro.TextMeshProUGUI>().text = "TennisBall";
                break;
            case SkinManager.SkinType.PingPongBall:
                ThunderBallImage.enabled = false;
                
                SkinImage.enabled = true;
                ClockBall.enabled = false;
                FutueristicBallImage.enabled = false;
                MagmaBall.enabled = false;
                SpiritBallImage.enabled = false;
                DarkMatterBallImage.enabled = false;
                SkinImage.sprite = SkinBalls[5].sprite;
                BallName.GetComponent<TMPro.TextMeshProUGUI>().text = "PingPongBall";
                break;
            case SkinManager.SkinType.EyeBall:
                ThunderBallImage.enabled = false;
              
                SkinImage.enabled = true;
                ClockBall.enabled = false;
                FutueristicBallImage.enabled = false;
                SpiritBallImage.enabled = false;
                MagmaBall.enabled = false;
                DarkMatterBallImage.enabled = false;
                SkinImage.sprite = SkinBalls[6].sprite;
                BallName.GetComponent<TMPro.TextMeshProUGUI>().text = "EyeBall";
                break;
            case SkinManager.SkinType.ThunderBall:
                ThunderBallImage.enabled = true;
               
                SkinImage.enabled = false;
                FutueristicBallImage.enabled = false;
                ClockBall.enabled = false;
                MagmaBall.enabled = false;
                SpiritBallImage.enabled = false;
                DarkMatterBallImage.enabled = false;
                BallName.GetComponent<TMPro.TextMeshProUGUI>().text = "ThunderBall";
                break;
            case SkinManager.SkinType.SpiritBall:
                ThunderBallImage.enabled = false;
                ClockBall.enabled = false;
                FutueristicBallImage.enabled = false;
                SpiritBallImage.enabled = true;
                MagmaBall.enabled = false;
                DarkMatterBallImage.enabled = false;
                SkinImage.enabled = false;
                BallName.GetComponent<TMPro.TextMeshProUGUI>().text = "SpiritBall";
                break;
            case SkinManager.SkinType.DarkMatterBall:
                ThunderBallImage.enabled = false;
                ClockBall.enabled = false;
                FutueristicBallImage.enabled = false;
                SpiritBallImage.enabled = false;
                MagmaBall.enabled = false;
                DarkMatterBallImage.enabled = true;
                SkinImage.enabled = false;
                BallName.GetComponent<TMPro.TextMeshProUGUI>().text = "DarkMatterBall";
                break;
            case SkinManager.SkinType.MagmaBall:
                ThunderBallImage.enabled = false;
                MagmaBall.enabled = true;
                FutueristicBallImage.enabled = false;
                SpiritBallImage.enabled = false;
                DarkMatterBallImage.enabled = false;
                ClockBall.enabled = false;
                SkinImage.enabled = false;
                BallName.GetComponent<TMPro.TextMeshProUGUI>().text = "MagmaBall";
                break;
            case SkinManager.SkinType.FutueristicBall:
                ThunderBallImage.enabled = false;
                ClockBall.enabled = false;
                FutueristicBallImage.enabled = true;
                MagmaBall.enabled = false;
                SpiritBallImage.enabled = false;
                DarkMatterBallImage.enabled = false;
                SkinImage.enabled = false;
                BallName.GetComponent<TMPro.TextMeshProUGUI>().text = "FuturisticBall"; 
                break;
            case SkinManager.SkinType.ClockBall:
                ThunderBallImage.enabled = false;
                ClockBall.enabled = true;
                FutueristicBallImage.enabled = false;
                MagmaBall.enabled = false;
                SpiritBallImage.enabled = false;
                DarkMatterBallImage.enabled = false;
                SkinImage.enabled = false;
                BallName.GetComponent<TMPro.TextMeshProUGUI>().text = "ClockBall";
                break;




        }

    }



    public void LoadLevel(int levelIndex)
    {
        Time.timeScale = 1f;

        if (levelIndex <= 30 && levelIndex > 25)
        {
            StartCoroutine(LoadLevels(levelIndex, "LevelStart2630"));
            TitleImage.GetComponent<TMPro.TextMeshProUGUI>().text = "";


        }
        else if (levelIndex <= 25 && levelIndex > 20)
        {
            StartCoroutine(LoadLevels(levelIndex, "LevelStart2125"));
            TitleImage.GetComponent<TMPro.TextMeshProUGUI>().text = "";

        }
        else if(levelIndex <= 20 && levelIndex > 10)
        {
            StartCoroutine(LoadLevels(levelIndex, "LevelStart10"));
            TitleImage.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        }
        else if (levelIndex <= 10)
        {
            StartCoroutine(LoadLevels(levelIndex, "LevelsStart"));
            TitleImage.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        }

        //SceneManager.LoadScene(levelIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ResetLevels()
    {
        //PlayerPrefs.DeleteKey("levelsUnlocked");
        //PlayerPrefs.DeleteKey("HighScore");
        PlayerPrefs.DeleteKey("SkinsUnlocked");
        PlayerPrefs.DeleteKey("Level5");
        PlayerPrefs.DeleteKey("Level10");
        PlayerPrefs.DeleteKey("Level15");
        PlayerPrefs.DeleteKey("Level20");
        PlayerPrefs.DeleteKey("Level25");
        PlayerPrefs.DeleteKey("Level30");
        PlayerPrefs.DeleteKey("Level35");
        PlayerPrefs.DeleteKey("Level40");
        PlayerPrefs.DeleteKey("Level45");
        PlayerPrefs.DeleteKey("Level50");
        PlayerPrefs.DeleteKey("Level55");
        PlayerPrefs.DeleteKey("Level60");
        SceneManager.LoadScene(0);
    }

    public void UnlockLevels()
    {
        PlayerPrefs.SetInt("levelsUnlocked", SceneManager.sceneCountInBuildSettings);
    
        SceneManager.LoadScene(0);
    }

    IEnumerator LoadLevels(int level, string s)
    {


        transition.SetTrigger(s);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(level);
    }


    public void SetVolume(float volume)
    {
        
        audioMixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat(soundEffectPref, volume);
            
        
    }


    public void SaveSoundSettings()
    {

        PlayerPrefs.SetFloat(soundEffectPref, soundEffectSlider.value);
    }



    public void MuteToggle(bool muted)
    {
        if(muted)
        {
            AudioListener.volume = 0;
         
        }
        else
        {
            AudioListener.volume = 1;
           
        }
    }
    private void OnApplicationFocus(bool focus)
    {
        if(!focus)
        {
            SaveSoundSettings();
        }
    }

    public void MenuEffects()
    {
        FindObjectOfType<AudioManager>().Play("ToOptions");
    }
    public void ToLevelEffect()
    {
        FindObjectOfType<AudioManager>().Play("ToLevel");
    }


    public void BasketBallSkin()
    {
        SkinManager.skin = SkinManager.SkinType.BasketBall;
    }
    public void DefaultSkin()
    {
        SkinManager.skin = SkinManager.SkinType.Default;
    }
    public void RandomBallSkin()
    {
        SkinManager.skin = SkinManager.SkinType.RandomBall;
    }
    public void FootBallSkin()
    {
        SkinManager.skin = SkinManager.SkinType.Football;
    }
    public void TennisBallSkin()
    {
        SkinManager.skin = SkinManager.SkinType.TennisBall;
    }
    public void PingPongBall()
    {
        SkinManager.skin = SkinManager.SkinType.PingPongBall;
    }
    public void EyeBallSkin()
    {
        SkinManager.skin = SkinManager.SkinType.EyeBall;
    }

    public void ThunderBallSkin()
    {
        SkinManager.skin = SkinManager.SkinType.ThunderBall;
    }
    public void SpiritBallSkin()
    {
        SkinManager.skin = SkinManager.SkinType.SpiritBall;
    }
    public void DarkMatterBallSkin()
    {
        SkinManager.skin = SkinManager.SkinType.DarkMatterBall;
    }
    public void MagmaBallSkin()
    {
        SkinManager.skin = SkinManager.SkinType.MagmaBall;
    }
    public void FutueristicBallSkin()
    {
        SkinManager.skin = SkinManager.SkinType.FutueristicBall;
    }
    public void ClockBallSkin()
    {
        SkinManager.skin = SkinManager.SkinType.ClockBall;
    }
   



    public void HARD(bool isOn)
    {
        if (isOn)
        {
            GameValues.difficult = GameValues.Difficulties.HARD;
            Normal.isOn = false;
        }
        else
            GameValues.difficult = GameValues.Difficulties.NORMAL;
    }

    public void NORMAL(bool isOn)
    {
        if(isOn)
        {
            GameValues.difficult = GameValues.Difficulties.NORMAL;
            Hard.isOn = false;
        }
    }
   
}
