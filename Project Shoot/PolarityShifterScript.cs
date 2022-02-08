using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarityShifterScript : MonoBehaviour
{
    [SerializeField] GameObject StartPortal;
    [SerializeField] GameObject EndPortal;


    public bool Shift;
    Vector3 StartPortalPosition;
    Vector3 EndPortalPosition;
    // Start is called before the first frame update
    void Start()
    {
        StartPortalPosition = StartPortal.transform.position;
        EndPortalPosition = EndPortal.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Shift)
        {
            StartPortal.transform.position = EndPortalPosition;
            EndPortal.transform.position = StartPortalPosition;
        }
        else
        {
            EndPortal.transform.position = EndPortalPosition;
            StartPortal.transform.position = StartPortalPosition;
        }
    }
}
