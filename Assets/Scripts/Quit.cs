using UnityEngine;
using UnityEngine.InputSystem;

public class Quit : MonoBehaviour
{
    public InputActionReference action_primarybutton;
    public InputActionReference action_secondarybutton;
    public Transform playerTransform;

    [SerializeField] private Vector3 startPosition = new Vector3(0f, 0f, -5f);
    [SerializeField] private Vector3 secondPosition = new Vector3(16f, 0f, -20f);
    public bool atStartPos = true;

    void Start()
    {
        action_secondarybutton.action.Enable();
        action_secondarybutton.action.performed += (ctx) =>
        {
            #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
            #else
                        Application.Quit();
            #endif
        };

        action_primarybutton.action.Enable();
        action_primarybutton.action.performed += (ctx) =>
        {
            if (atStartPos)
            {
                atStartPos = false;
                playerTransform.position = secondPosition;
            }
            else
            {
                atStartPos = true;
                playerTransform.position = startPosition;
            }
        };

    }
}
