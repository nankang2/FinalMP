using UnityEngine;

public class Rotate : MonoBehaviour
{
    Transform transform;
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, Time.deltaTime * 2.0f, 0.0f, Space.Self);
    }
}
