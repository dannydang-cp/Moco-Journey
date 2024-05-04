using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterCollision : MonoBehaviour
{
    [SerializeField] private AudioSource carSound;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player has collided with the car
        if (collision.gameObject.CompareTag("Car"))
        {
            // Play the car sound
            carSound.Play();
            
            // Wait for the sound to finish playing and restart the scene
            StartCoroutine(WaitAndRest(0.25f));
        }
    }

    IEnumerator WaitAndRest(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);}


}
