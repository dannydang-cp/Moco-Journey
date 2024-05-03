using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10.0f;
    private float horizontal;
    private float vertical;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
 

    // Start is called before the first frame update
    void Start()
    {
        // rb.bodyType = RigidbodyType2D.Kinematic;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        
        // Set the "IsRunning" parameter based on whether the character is moving
        animator.SetBool("IsRunning", horizontal != 0 || vertical != 0);

        if (horizontal != 0)
        {
            transform.localScale = new Vector3(-Mathf.Sign(horizontal), 1, 1);
        }


    }

    private void FixedUpdate()
    {

        rb.velocity = new Vector2(horizontal * speed, vertical * speed);

    }
}
