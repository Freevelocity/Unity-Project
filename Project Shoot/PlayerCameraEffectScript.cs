using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraEffectScript : MonoBehaviour
{
    private string currentState;
    Animator MainCamera;

    [SerializeField] PlayerScript ps;

    const string SHAKE = "Shake";
    const string IDEL = "IDLE";


   
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(ps.CanShake)
        {
            ChangeAnimationState(SHAKE);
            Invoke("CanShakeToFalse", MainCamera.GetCurrentAnimatorStateInfo(0).length);
        }
        
        
    }




    void CanShakeToFalse()
    {
        ps.CanShake = false;
        ChangeAnimationState(IDEL);
        
    }

    void ChangeAnimationState(string newState)
    {
        // Stops the same animation from playing
        if (newState == currentState) return;

        // Plays the new Animation
        MainCamera.Play(newState);

        // Reassigns the current state
        currentState = newState;

    }
}
