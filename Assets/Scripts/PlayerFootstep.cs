using UnityEngine;

public class FootstepMovement : MonoBehaviour
{
    public Transform player;
    public AudioSource footstepAudio;

    public float moveThreshold = 0.01f;

    private Vector3 lastPosition;

    void Start()
    {
        footstepAudio.loop = true;
        footstepAudio.volume = 0f;
        footstepAudio.Play();

        lastPosition = player.position;
    }

    void Update()
    {
        float movement = Vector3.Distance(player.position, lastPosition);

        if (movement > moveThreshold)
        {
            footstepAudio.volume = 0.5f;
        }
        else
        {
            footstepAudio.volume = 0f;
        }

        lastPosition = player.position;
    }
}