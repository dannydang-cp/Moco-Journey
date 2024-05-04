using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject dialogueCanvasMoco;
    public GameObject dialogueCanvasApple;
    public float moveDistance = 2.0f;

    void Start()
    {
        dialogueCanvasMoco.SetActive(false);
        dialogueCanvasApple.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Moco") && !dialogueCanvasApple.activeSelf)
        {
            dialogueCanvasMoco.SetActive(true);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Moco"))
        {
            dialogueCanvasMoco.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            transform.position += new Vector3(moveDistance, 0, 0);
            dialogueCanvasApple.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
}
