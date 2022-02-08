using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallLives : MonoBehaviour
{
    public int Lives;
    public int numOfLives;

    public Image[] livesImages;


    private void Update()
    {

        switch(GameValues.difficult)
        {
            case GameValues.Difficulties.NORMAL:
                for (int i = 0; i < livesImages.Length; i++)
                {
                    if (i < Lives)
                    {
                        livesImages[i].enabled = true;
                    }
                    else
                    {
                        livesImages[i].enabled = false;
                    }

                }
                break;
            case GameValues.Difficulties.HARD:
                for (int i = 0; i < livesImages.Length; i++)
                {
                    if (i < GameValues.ballLivesHard)
                    {
                        livesImages[i].enabled = true;
                    }
                    else
                    {
                        livesImages[i].enabled = false;
                    }

                }
                break;


        }
       
    }
}
