using UnityEngine;

public class FollowCharacter : MonoBehaviour
{
    public Transform character;
    public Vector3 offset;

    void Update()
    {
        transform.position = character.position + offset;
    }
}
