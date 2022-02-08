using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarityActiveScript : MonoBehaviour
{
    [SerializeField] GameObject gameObject;
    [SerializeField] PolarityShifterScript polarityShifterScript;
    [SerializeField] PlayerScript ps;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ps.isReset)
        {
            gameObject.SetActive(true);
        }

    
    }
}
