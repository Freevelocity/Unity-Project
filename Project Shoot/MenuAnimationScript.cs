using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAnimationScript : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject[] gameObjects;


    [SerializeField] GameObject txt;

    private bool StartAnimationOver = false;

    private void Awake()
    {
        foreach (GameObject item in gameObjects)
        {
            item.SetActive(false);
        }
        txt.GetComponent<TMPro.TextMeshProUGUI>().text = "";
    }
    void Start()
    {
        
    }

    
    void Update()
    {

        StartCoroutine(AfterStart());
    }

    IEnumerator AfterStart()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        foreach (GameObject item in gameObjects)
        {
            item.SetActive(true);
        }
        txt.GetComponent<TMPro.TextMeshProUGUI>().text = "Paper & Time";
    }
   
}
