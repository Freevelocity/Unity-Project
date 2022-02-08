using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOppositeDirectionScript : MonoBehaviour
{


    [SerializeField] GameObject ExitPortal;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject ball = collision.gameObject;
            Rigidbody2D rigidbody = ball.GetComponent<Rigidbody2D>();

            Vector3 inPosition = this.transform.InverseTransformPoint(ball.transform.position);
            inPosition.x = -inPosition.x;
            Vector3 outPosition = ExitPortal.transform.TransformPoint(inPosition);

            Vector3 inDirection = this.transform.InverseTransformDirection(rigidbody.velocity);
            Vector3 outDirection = ExitPortal.transform.TransformDirection(inDirection);

            ball.transform.position = outPosition;
            rigidbody.velocity = -outDirection;

            FindObjectOfType<AudioManager>().Play("InGameTeleportation");

          
        }

    }
}

