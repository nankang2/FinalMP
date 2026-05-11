using UnityEngine;
using UnityEngine.InputSystem;

public class SprintToggle : MonoBehaviour
{
    public MonoBehaviour moveProvider;
    public InputActionReference sprintAction;

    public float walkSpeed = 2.5f;
    public float sprintSpeed = 5f;

    void Update()
    {
        if (moveProvider == null || sprintAction == null || sprintAction.action == null)
            return;

        float speed = sprintAction.action.IsPressed() ? sprintSpeed : walkSpeed;

        SetValue("moveSpeed", speed);
        SetValue("m_MoveSpeed", speed);
    }

    void SetValue(string name, float value)
    {
        var type = moveProvider.GetType();

        var field = type.GetField(name, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);
        if (field != null)
        {
            field.SetValue(moveProvider, value);
            return;
        }

        var property = type.GetProperty(name, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);
        if (property != null)
            property.SetValue(moveProvider, value);
    }
}