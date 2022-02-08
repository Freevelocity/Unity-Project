using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinTypeManger : MonoBehaviour
{
    

    [SerializeField] Sprite[] SkinSprites;
    [SerializeField] SpriteRenderer Player;
    [SerializeField] Image[] Health;
    [SerializeField] Animator PlayerAnimator;
    [SerializeField] PlayerAnimation playerAnimation;
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        
        switch (SkinManager.skin)
        {

            case SkinManager.SkinType.Default:
                PlayerAnimator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("PlayerAnimation/NormalBall/Ball_Animation");
                playerAnimation.StartUpAnimations = false;
                Player.sprite = SkinSprites[0];
                Health[0].sprite = SkinSprites[0];
                Health[1].sprite = SkinSprites[0];
                Health[2].sprite = SkinSprites[0];
                break;
            case SkinManager.SkinType.RandomBall:
                PlayerAnimator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("PlayerAnimation/VolleyBall/VolleyBallController");
                playerAnimation.StartUpAnimations = true;
                Player.sprite = SkinSprites[1];
                Health[0].sprite = SkinSprites[1];
                Health[1].sprite = SkinSprites[1];
                Health[2].sprite = SkinSprites[1];
                break;
            case SkinManager.SkinType.BasketBall:
                PlayerAnimator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("PlayerAnimation/BasketBall/BasketBallAnimator");
                playerAnimation.StartUpAnimations = true;
                Player.sprite = SkinSprites[2];
                Health[0].sprite = SkinSprites[2];
                Health[1].sprite = SkinSprites[2];
                Health[2].sprite = SkinSprites[2];
                break;
            case SkinManager.SkinType.Football:
                PlayerAnimator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("PlayerAnimation/FootBall/FootBallController");
                playerAnimation.StartUpAnimations = true;
                Player.sprite = SkinSprites[3];
                Health[0].sprite = SkinSprites[3];
                Health[1].sprite = SkinSprites[3];
                Health[2].sprite = SkinSprites[3];
                break;
            case SkinManager.SkinType.TennisBall:
                PlayerAnimator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("PlayerAnimation/TennisBall/TennisBallController");
                playerAnimation.StartUpAnimations = true;
                Player.sprite = SkinSprites[4];
                Health[0].sprite = SkinSprites[4];
                Health[1].sprite = SkinSprites[4];
                Health[2].sprite = SkinSprites[4];
                break;
            case SkinManager.SkinType.PingPongBall:
                PlayerAnimator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("PlayerAnimation/PingPongBall/PingPongBallController");
                playerAnimation.StartUpAnimations = true;
                Player.sprite = SkinSprites[5];
                Health[0].sprite = SkinSprites[5];
                Health[1].sprite = SkinSprites[5];
                Health[2].sprite = SkinSprites[5];
                break;
            case SkinManager.SkinType.EyeBall:
                PlayerAnimator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("PlayerAnimation/EyeBall/EyeBallController");
                playerAnimation.StartUpAnimations = true;
                Player.sprite = SkinSprites[6];
                Health[0].sprite = SkinSprites[6];
                Health[1].sprite = SkinSprites[6];
                Health[2].sprite = SkinSprites[6];
                break;
            case SkinManager.SkinType.ThunderBall:
                PlayerAnimator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("PlayerAnimation/ThunderBall/ThunderBallController");
                playerAnimation.StartUpAnimations = true;
                Player.sprite = SkinSprites[7];
                Health[0].sprite = SkinSprites[7];
                Health[1].sprite = SkinSprites[7];
                Health[2].sprite = SkinSprites[7];
                break;
            case SkinManager.SkinType.SpiritBall:
                PlayerAnimator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("PlayerAnimation/SpiritBall/SpiritBallController");
                playerAnimation.StartUpAnimations = true;
                Player.sprite = SkinSprites[8];
                Health[0].sprite = SkinSprites[8];
                Health[1].sprite = SkinSprites[8];
                Health[2].sprite = SkinSprites[8];
                break;
            case SkinManager.SkinType.DarkMatterBall:
                PlayerAnimator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("PlayerAnimation/DarkMatterBall/DarkMatterBallController");
                playerAnimation.StartUpAnimations = true;
                Player.sprite = SkinSprites[9];
                Health[0].sprite = SkinSprites[9];
                Health[1].sprite = SkinSprites[9];
                Health[2].sprite = SkinSprites[9];
                break;
            case SkinManager.SkinType.MagmaBall:
                PlayerAnimator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("PlayerAnimation/MagmaBall/MagmaBallController");
                playerAnimation.StartUpAnimations = true;
                Player.sprite = SkinSprites[10];
                Health[0].sprite = SkinSprites[10];
                Health[1].sprite = SkinSprites[10];
                Health[2].sprite = SkinSprites[10];
                break;
            case SkinManager.SkinType.ClockBall:
                PlayerAnimator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("PlayerAnimation/ClockBall/ClockBallController");
                playerAnimation.StartUpAnimations = true;
                Player.sprite = SkinSprites[11];
                Health[0].sprite = SkinSprites[11];
                Health[1].sprite = SkinSprites[11];
                Health[2].sprite = SkinSprites[11];
                break;
            case SkinManager.SkinType.FutueristicBall:
                PlayerAnimator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("PlayerAnimation/FutueristicBall/FutueristicBallController");
                playerAnimation.StartUpAnimations = true;
                Player.sprite = SkinSprites[12];
                Health[0].sprite = SkinSprites[12];
                Health[1].sprite = SkinSprites[12];
                Health[2].sprite = SkinSprites[12];
                break;


        }



    }
}
