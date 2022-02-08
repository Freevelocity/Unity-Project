using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FillStatusBarScript : MonoBehaviour
{

    [SerializeField] PlayerScript ps;
    public Image fillImage;
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = ps._maxDragDistance;
    }

    // Update is called once per frame
    void Update()
    {

        if (ps.isPressed)
        {
            fillImage.enabled = true;
            slider.value = Vector3.Distance(ps.mousePosition, ps._hookRb2D.position);
        }




        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }
        

        if (slider.value <= 2 * ps._maxDragDistance / 3 && slider.value >= ps._maxDragDistance / 3)
        {
            fillImage.color = Color.yellow;
        }
        else if (slider.value <= ps._maxDragDistance / 3)
        {
            fillImage.color = Color.green;
        }
        else
        {
            fillImage.color = Color.red;
        }
    }
}
