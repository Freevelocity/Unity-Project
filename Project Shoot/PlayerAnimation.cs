using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] PlayerScript playerScript;
    [SerializeField] PauseMenuScript pauseMenu;
    Animator ballAnimator;
    private string currentState;


    const string Player_IDLE = "Ball_Idle";
    const string Player_Air = "Ball_Motion";

    const string Player_BounceStartUp = "BounceStartUp";
    const string Player_BounceIdle = "BounceIdle";
    const string Player_BounceMotion = "BounceMotion";

    const string Player_ShootStartUp = "ShootStartUp";
    const string Player_ShootIdle = "ShootIdle";
    const string Player_ShootMotion = "ShootMotion";

    const string Player_BothStartUp = "BothStartUp";
    const string Player_BothIdle = "BothIdle";
    const string Player_BothMotion = "BothMotion";

    public bool PlayOnce;
    public bool StartUpAnimations;
    public bool BothStartUp;

    void Start()
    {
        ballAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {

       if(StartUpAnimations && playerScript._isReleased && !pauseMenu.shootAgain && !pauseMenu.bounceClicked)
        {
            PlayOnce = true;
            BothStartUp = true;

        }
      
       if(!StartUpAnimations)
        {
            PlayOnce = false;
        }


        if(playerScript.inMotion && !pauseMenu.bounceClicked && !pauseMenu.shootAgain && playerScript.isMoving)
        {
            ChangeAnimationState(Player_Air);
        }

        if(pauseMenu.bounceClicked && playerScript.inMotion && !pauseMenu.shootAgain)
        {
            if (PlayOnce)
            {
                ChangeAnimationState(Player_BounceStartUp);
                Invoke("OnceOVer", ballAnimator.GetCurrentAnimatorStateInfo(0).length);
            }
            else
            {
                ChangeAnimationState(Player_BounceMotion);
            }
        }
        else if(pauseMenu.bounceClicked && !pauseMenu.shootAgain)
        {
           
            
                ChangeAnimationState(Player_BounceIdle);
            
        }
       

        if(pauseMenu.shootAgain && playerScript.inMotion && !pauseMenu.bounceClicked && !playerScript.touchedWall)
        {
            ChangeAnimationState(Player_ShootMotion);
        }
        else if (pauseMenu.shootAgain && !pauseMenu.bounceClicked && !playerScript.touchedWall)
        {
            if(PlayOnce)
            {
                ChangeAnimationState(Player_ShootStartUp);
                Invoke("OnceOVer",ballAnimator.GetCurrentAnimatorStateInfo(0).length);
            }
            else
            {
                ChangeAnimationState(Player_ShootIdle);

            }
            
            
        }

        if(pauseMenu.shootAgain && pauseMenu.bounceClicked && playerScript.inMotion)
        {
           
                ChangeAnimationState(Player_BothMotion);
        }
        else if(pauseMenu.shootAgain && pauseMenu.bounceClicked)
        {
            if (BothStartUp)
            {
                ChangeAnimationState(Player_BothStartUp);
                Invoke("BothOver", ballAnimator.GetCurrentAnimatorStateInfo(0).length);
            }
            else
                ChangeAnimationState(Player_BothIdle);
        }


        if(playerScript.isReset && !pauseMenu.bounceClicked && !pauseMenu.shootAgain || playerScript.isGrounded && !pauseMenu.shootAgain && !pauseMenu.bounceClicked && !playerScript.isMoving || playerScript.onMovingPlatform && !playerScript.isMoving )
        {
            ChangeAnimationState(Player_IDLE);
        }    
    }

    void OnceOVer()
    {
        PlayOnce = false;
        
    }

    void BothOver()
    {
        BothStartUp = false;
    }

    void ChangeAnimationState(string newState)
    {
        // Stops the same animation from playing
        if (newState == currentState) return;

        // Plays the new Animation
        ballAnimator.Play(newState);

        // Reassigns the current state
        currentState = newState;

    }
}
