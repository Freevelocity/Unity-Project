using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] PlayerScript _playerScript;
    [SerializeField] BallLives _ballLives;
    [SerializeField] MainMenu _mainMenu;
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject LevelCompleteMenuUI;

    
    public GameObject LevelEndMenuUI;
    public GameObject RetryObject;
    private string mainMenu = "MainMenu";

    public Animator animator;

    public bool bounceClicked = false;
    public bool shootAgain = false;
    public bool dashing = false;

    public bool ShootGroundReset = true;

  
    
    public int ShootTime = 1;
    public int BounceTime = 1;
    public int DashTime = 1;

    
    public GameObject shootTimeChange;
    public GameObject bounceTimeChange;
    public GameObject dashTimeChange;

    public Button[] setfalsebuttons;
    public GameObject[] txt;


    bool SkinDone = true;
    private void Start()
    {
        shootTimeChange.GetComponent<TMPro.TextMeshProUGUI>().text = ShootTime.ToString();
        bounceTimeChange.GetComponent<TMPro.TextMeshProUGUI>().text = BounceTime.ToString();
        dashTimeChange.GetComponent<TMPro.TextMeshProUGUI>().text = DashTime.ToString();
        SkinDone = true;
    }
    // Update is called once per frame
    void Update()
    {

        if (_playerScript._levelComplete)
        {
            levelCompleteMenu();
            Time.timeScale = 0f;


        }

        switch (GameValues.difficult)
        {
            case GameValues.Difficulties.NORMAL:

                if (SceneManager.GetActiveScene().buildIndex == 5 && _playerScript._levelComplete && SkinDone && PlayerPrefs.GetInt("Level5") == 0)
                {

                    SkinManager.SkinUnlockedValue++;
                    PlayerPrefs.SetInt("SkinsUnlocked", SkinManager.SkinUnlockedValue);
                    SkinDone = false;
                    PlayerPrefs.SetInt("Level5", 1);

                }
                if (SceneManager.GetActiveScene().buildIndex == 10 && _playerScript._levelComplete && SkinDone && PlayerPrefs.GetInt("Level10") == 0)
                {

                    SkinManager.SkinUnlockedValue++;
                    PlayerPrefs.SetInt("SkinsUnlocked", SkinManager.SkinUnlockedValue);
                    SkinDone = false;
                    PlayerPrefs.SetInt("Level10", 1);

                }
                if (SceneManager.GetActiveScene().buildIndex == 15 && _playerScript._levelComplete && SkinDone && PlayerPrefs.GetInt("Level15") == 0)
                {

                    SkinManager.SkinUnlockedValue++;
                    PlayerPrefs.SetInt("SkinsUnlocked", SkinManager.SkinUnlockedValue);
                    SkinDone = false;
                    PlayerPrefs.SetInt("Level15", 1);

                }
                if (SceneManager.GetActiveScene().buildIndex == 20 && _playerScript._levelComplete && SkinDone && PlayerPrefs.GetInt("Level20") == 0)
                {

                    SkinManager.SkinUnlockedValue++;
                    PlayerPrefs.SetInt("SkinsUnlocked", SkinManager.SkinUnlockedValue);
                    SkinDone = false;
                    PlayerPrefs.SetInt("Level20", 1);

                }
                if (SceneManager.GetActiveScene().buildIndex == 25 && _playerScript._levelComplete && SkinDone && PlayerPrefs.GetInt("Level25") == 0)
                {

                    SkinManager.SkinUnlockedValue++;
                    PlayerPrefs.SetInt("SkinsUnlocked", SkinManager.SkinUnlockedValue);
                    SkinDone = false;
                    PlayerPrefs.SetInt("Level25", 1);

                }
                if (SceneManager.GetActiveScene().buildIndex == 30 && _playerScript._levelComplete && SkinDone && PlayerPrefs.GetInt("Level30") == 0)
                {

                    SkinManager.SkinUnlockedValue++;
                    PlayerPrefs.SetInt("SkinsUnlocked", SkinManager.SkinUnlockedValue);
                    SkinDone = false;
                    PlayerPrefs.SetInt("Level30", 1);

                }

                break;

            case GameValues.Difficulties.HARD:
                if (SceneManager.GetActiveScene().buildIndex == 5 && _playerScript._levelComplete && SkinDone && PlayerPrefs.GetInt("Level35") == 0)
                {

                    SkinManager.SkinUnlockedValueHARD++;
                    PlayerPrefs.SetInt("SkinUnlockedHARD", SkinManager.SkinUnlockedValueHARD);
                    SkinDone = false;
                    PlayerPrefs.SetInt("Level35", 1);

                }
                if (SceneManager.GetActiveScene().buildIndex == 10 && _playerScript._levelComplete && SkinDone && PlayerPrefs.GetInt("Level40") == 0)
                {

                    SkinManager.SkinUnlockedValueHARD++;
                    PlayerPrefs.SetInt("SkinUnlockedHARD", SkinManager.SkinUnlockedValueHARD);
                    SkinDone = false;
                    PlayerPrefs.SetInt("Level40", 1);

                }
                if (SceneManager.GetActiveScene().buildIndex == 15 && _playerScript._levelComplete && SkinDone && PlayerPrefs.GetInt("Level45") == 0)
                {

                    SkinManager.SkinUnlockedValueHARD++;
                    PlayerPrefs.SetInt("SkinUnlockedHARD", SkinManager.SkinUnlockedValueHARD);
                    SkinDone = false;
                    PlayerPrefs.SetInt("Level45", 1);

                }
                if (SceneManager.GetActiveScene().buildIndex == 20 && _playerScript._levelComplete && SkinDone && PlayerPrefs.GetInt("Level50") == 0)
                {

                    SkinManager.SkinUnlockedValueHARD++;
                    PlayerPrefs.SetInt("SkinUnlockedHARD", SkinManager.SkinUnlockedValueHARD);
                    SkinDone = false;
                    PlayerPrefs.SetInt("Level50", 1);

                }
                if (SceneManager.GetActiveScene().buildIndex == 25 && _playerScript._levelComplete && SkinDone && PlayerPrefs.GetInt("Level55") == 0)
                {

                    SkinManager.SkinUnlockedValueHARD++;
                    PlayerPrefs.SetInt("SkinUnlockedHARD", SkinManager.SkinUnlockedValueHARD);
                    SkinDone = false;
                    PlayerPrefs.SetInt("Level55", 1);

                }
                if (SceneManager.GetActiveScene().buildIndex == 30 && _playerScript._levelComplete && SkinDone && PlayerPrefs.GetInt("Level60") == 0)
                {

                    SkinManager.SkinUnlockedValueHARD++;
                    PlayerPrefs.SetInt("SkinUnlockedHARD", SkinManager.SkinUnlockedValueHARD);
                    SkinDone = false;
                    PlayerPrefs.SetInt("Level60", 1);

                }
                break;

         }

        switch (GameValues.difficult)
        {
            case GameValues.Difficulties.NORMAL:
                setfalsebuttons[setfalsebuttons.Length - 1].gameObject.SetActive(true);
                if (_ballLives.Lives <= 0)
                {
                    LevelEndMenuUI.SetActive(true);
                    Time.timeScale = 0f;
                    for (int i = 0; i < setfalsebuttons.Length; i++)
                    {
                        setfalsebuttons[i].gameObject.SetActive(false);
                    }

                    for (int j = 0; j < txt.Length; j++)
                    {
                        txt[j].gameObject.SetActive(false);
                    }
                }

                break;
            case GameValues.Difficulties.HARD:
                setfalsebuttons[setfalsebuttons.Length - 1].gameObject.SetActive(false);
                if (GameValues.ballLivesHard <= 0)
                {
                    LevelEndMenuUI.SetActive(true);
                    RetryObject.SetActive(false);
                    Time.timeScale = 0f;
                    for (int i = 0; i < setfalsebuttons.Length; i++)
                    {
                        setfalsebuttons[i].gameObject.SetActive(false);
                    }

                    for (int j = 0; j < txt.Length; j++)
                    {
                        txt[j].gameObject.SetActive(false);
                    }
                   
                }

                if(_playerScript._levelComplete && SceneManager.GetActiveScene().buildIndex  > PlayerPrefs.GetInt("HighScore"))
                {
                    PlayerPrefs.SetInt("HighScore", SceneManager.GetActiveScene().buildIndex);
                }
                break;


        }
    }



    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
      
    }
    public void Pause() 
    {
        if (!_playerScript.isPressed)
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            gameIsPaused = true;
        }
    }
    public void LoadMenu()
    {
        //Time.timeScale = 1f; Doesn't set it back to 1f for some reason
        SceneManager.LoadScene(mainMenu);
        GameValues.ballLivesHard = 3;
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

     public void levelCompleteMenu()
     {
        LevelCompleteMenuUI.SetActive(true);
        
        Time.timeScale = 1f;
        for(int i = 0; i < setfalsebuttons.Length; i++)
        {
            setfalsebuttons[i].gameObject.SetActive(false);
        }

        for(int j = 0; j < txt.Length; j++)
        {
            txt[j].gameObject.SetActive(false);
        }
     }
 

   

    public void Retry()
    {
        if (!_playerScript.isPressed && !_playerScript.FirstPress)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            _playerScript.isResetInGame = true;
            Time.timeScale = 1f;
            
        }
        
    }


    public void FullRetry()
    {
        
        
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            FindObjectOfType<AudioManager>().Play("InGameFullReset");


    }

    public void NextLevelSound()
    {
        FindObjectOfType<AudioManager>().Play("InGameFullReset");
    }
    public void AllInGameMenuSound()
    {
        FindObjectOfType<AudioManager>().Play("InGamePauseandResume");
    }
   



    public void NextLevel()
     {
        LevelCompleteMenuUI.SetActive(false);
        Time.timeScale = 1f;
        _playerScript._levelComplete = false;
        int currentlevel = SceneManager.GetActiveScene().buildIndex;

        if (GameValues.difficult == GameValues.Difficulties.NORMAL)
        {
            var sceneNumber = SceneManager.sceneCountInBuildSettings;
            int levelunlocked = PlayerPrefs.GetInt("levelsUnlocked");
            if (currentlevel + 1 == sceneNumber)
            {
                SceneManager.LoadScene(mainMenu);
            }
            else if (levelunlocked > currentlevel)
            {

                SceneManager.LoadScene(currentlevel + 1);
            }
            else
            {
                PlayerPrefs.SetInt("levelsUnlocked", currentlevel + 1);
                SceneManager.LoadScene(currentlevel + 1);
            }
        }
        else
        {
            SceneManager.LoadScene(currentlevel + 1);
        }
    
      
     }


    public void Bounce()
    {
        if(BounceTime > 0 && !bounceClicked)
        {
            
            bounceClicked = true;
            
            BounceTime--;
            bounceTimeChange.GetComponent<TMPro.TextMeshProUGUI>().text = BounceTime.ToString();
            FindObjectOfType<AudioManager>().Play("InGamePowerUpShoot");
        }
            
    }

    public void ShotAgain()
    {
        if (ShootTime > 0 && !shootAgain && _playerScript._isReleased || ShootTime > 0 && _playerScript.inMotion && shootAgain && bounceClicked)
        {
            _playerScript._rigidbody2D.isKinematic = true;
            _playerScript._rigidbody2D.velocity = Vector2.zero;
            _playerScript._hookRb2D.position = _playerScript._rigidbody2D.position;
             bounceClicked = false;
            _playerScript.inMotion = false;
            _playerScript.touchedWall = false;
            ShootGroundReset = true;
            shootAgain = true;
            ShootTime--;
            shootTimeChange.GetComponent<TMPro.TextMeshProUGUI>().text = ShootTime.ToString();
            FindObjectOfType<AudioManager>().Play("InGamePowerUpShoot");
        }
      
        
    }



    public void Dash()
    {
        if(DashTime > 0 && _playerScript._isReleased)
        {
            dashing = true;
            DashTime--;
            dashTimeChange.GetComponent<TMPro.TextMeshProUGUI>().text = DashTime.ToString();
            FindObjectOfType<AudioManager>().Play("InGameDash");
            
        }
    }

    
}
