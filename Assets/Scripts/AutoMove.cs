using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public float speed = 2.0f; // Speed of the movement
    public float maxDistance = 5.0f; // Maximum distance car can move left or right

    private float startingPosition;
    private Vector3 theScale; // To flip the car

    void Start()
    {
        // Save the starting position of the car
        startingPosition = transform.position.x;

        // Get the local scale of the car
        theScale = transform.localScale;
    }

    void Update()
    {
        // Calculate new position
        float newPosition = startingPosition + Mathf.PingPong(Time.time * speed, maxDistance * 2) - maxDistance;

        // Flip the car when it moves left
        if (newPosition < transform.position.x)
        {
            theScale.x = -Mathf.Abs(theScale.x);
        }
        else
        {
            theScale.x = Mathf.Abs(theScale.x);
        }
        transform.localScale = theScale;

        // Update car position
        transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
    }
}


