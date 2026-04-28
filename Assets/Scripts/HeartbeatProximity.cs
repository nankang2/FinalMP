using UnityEngine;

public class HeartbeatProximity : MonoBehaviour
{
    public Transform player;
    public Transform enemy;

    public AudioSource heartbeatAudio;

    public float maxDistance = 12f;
    public float minDistance = 2f;

    public float minVolume = 0.05f;
    public float maxVolume = 1f;

    public float minPitch = 0.85f;
    public float maxPitch = 1.35f;

    void Start()
    {
        heartbeatAudio.loop = true;
        heartbeatAudio.volume = 0f;
        heartbeatAudio.Play();
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, enemy.position);

        if (distance > maxDistance)
        {
            heartbeatAudio.volume = 0f;
            return;
        }

        float closeness = 1f - Mathf.InverseLerp(minDistance, maxDistance, distance);

        heartbeatAudio.volume = Mathf.Lerp(minVolume, maxVolume, closeness);
        heartbeatAudio.pitch = Mathf.Lerp(minPitch, maxPitch, closeness);
    }
}