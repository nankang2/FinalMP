using UnityEngine;
using UnityEngine.InputSystem;

public class DesktopDebugMove : MonoBehaviour
{
    public Transform cameraTransform;
    public float moveSpeed = 3f;
    public float mouseSensitivity = 0.15f;

    private float pitch;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (cameraTransform == null && Camera.main != null)
            cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        if (cameraTransform == null) return;

        Move();
        LookAround();
    }

    void LookAround()
    {
        // Only look when holding RIGHT CLICK
        if (!Mouse.current.rightButton.isPressed)
            return;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        float mouseX = mouseDelta.x * mouseSensitivity;
        float mouseY = mouseDelta.y * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -80f, 80f);

        cameraTransform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }

    void Move()
    {
        // Always allow WASD movement
        Vector2 moveInput = Vector2.zero;

        if (Keyboard.current.wKey.isPressed) moveInput.y += 1;
        if (Keyboard.current.sKey.isPressed) moveInput.y -= 1;
        if (Keyboard.current.dKey.isPressed) moveInput.x += 1;
        if (Keyboard.current.aKey.isPressed) moveInput.x -= 1;

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 move = forward * moveInput.y + right * moveInput.x;

        if (move.sqrMagnitude > 1f)
            move.Normalize();

        transform.position += move * moveSpeed * Time.deltaTime;
    }

    void LateUpdate()
    {
        // If NOT holding right click → unlock cursor for UI
        if (!Mouse.current.rightButton.isPressed)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}