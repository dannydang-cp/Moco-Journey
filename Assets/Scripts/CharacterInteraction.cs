using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    [SerializeField] private AudioSource barkSound; 
    [SerializeField] private Transform holdPoint; // The point where the apple will be held
    private GameObject heldObject = null; // The object currently being held

    void Update()
    {
        // Check if the space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Play the bark sound
            barkSound.Play();
        }

        // Check if the shift key is released and an object is being held
        if (Input.GetKeyUp(KeyCode.LeftShift) && heldObject != null)
        {
            // Drop the held object
            heldObject.GetComponent<Collider2D>().enabled = true;
            heldObject.transform.SetParent(null);
            heldObject = null;
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        // Check if the shift key is pressed, no object is currently being held, and the other object is an apple
        if (Input.GetKeyDown(KeyCode.LeftShift) && heldObject == null && other.gameObject.CompareTag("Apple"))
        {
            // Pick up the apple
            heldObject = other.gameObject;
            heldObject.GetComponent<Collider2D>().enabled = false;
            heldObject.transform.SetParent(holdPoint);
            heldObject.transform.position = holdPoint.position;
        }
    }
}
