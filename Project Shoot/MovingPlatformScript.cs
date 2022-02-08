using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public List<Transform> points;
    public Transform platform;
    [SerializeField] GameObject game;
    int goalpoint;
    public float movespeed = 2;

    public bool Rotate;
    public bool RotateMove;

    public float RotateAmount;

    private void Update()
    {
        
        if (Rotate)
        {
            Vector3 axis = new Vector3(0, 0, 1);
            transform.RotateAround(game.transform.position, axis, -100 * Time.deltaTime*movespeed);
        }
        else
        {
            MoveToNextPoint();
        }

        if(RotateMove)
        {
            platform.Rotate(0, 0, RotateAmount * Time.deltaTime);
            MoveToNextPointRoate();
        }
    }

    void MoveToNextPoint()
    {
        // Change the postion of the platform (move towards the goal point)
        platform.position = Vector2.MoveTowards(platform.position, points[goalpoint].position,Time.deltaTime*movespeed);
        
        // Check if we are in very close proximity of the next point
        if (Vector2.Distance(platform.position,points[goalpoint].position) < 0.1f)
        {
            FindObjectOfType<AudioManager>().Play("InGameMiddlePlatform");
            // if so change goal point to the next point
            if (goalpoint == points.Count - 1)
            {
                goalpoint = 0;
                
                FindObjectOfType<AudioManager>().Play("InGamePlatformMoving");
            }
            else
            {
                goalpoint++;
                
                FindObjectOfType<AudioManager>().Play("InGamePlatformMoving");
            }
        }
    }
    void MoveToNextPointRoate()
    {
        // Change the postion of the platform (move towards the goal point)
        platform.position = Vector2.MoveTowards(platform.position, points[goalpoint].position, Time.deltaTime * movespeed);
        

        // Check if we are in very close proximity of the next point
        if (Vector2.Distance(platform.position, points[goalpoint].position) < 0.1f)
        {
            FindObjectOfType<AudioManager>().Play("InGameMiddlePlatform");
            // if so change goal point to the next point
            if (goalpoint == points.Count - 1)
            {
                goalpoint = 0;
                FindObjectOfType<AudioManager>().Play("InGamePlatformMoving");
            }
            else
            {
                goalpoint++;

                FindObjectOfType<AudioManager>().Play("InGamePlatformMoving");
            }
        }
    }

}

