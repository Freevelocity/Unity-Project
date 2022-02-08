using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarityScript : MonoBehaviour
{

    

    [SerializeField] List<PolarityShifterScript> polarityShifterScripts;
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
            foreach(var item in polarityShifterScripts)
            {
                if (item.Shift)
                {
                    item.Shift = false;
                }
                
            }
            
            
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (var item in polarityShifterScripts)
            {
                if (item.Shift)
                {
                    item.Shift = false;
                }
                else
                    item.Shift = true;
            }
            this.gameObject.SetActive(false);
        }
    }
}
