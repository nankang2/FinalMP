using UnityEngine;
using UnityEngine.InputSystem;

public class FlashlightDim : MonoBehaviour
{
    public Light flashlightLight;

    public InputActionReference toggleFlashlightAction;

    public float maxIntensity = 2f;
    public float minIntensity = 0.15f;
    public float drainDuration = 60f;

    public float flickerStartsAt = 0.25f;
    public float flickerSpeed = 0.08f;
    public float flickerAmount = 0.45f;

    private float timer;
    private float nextFlickerTime;
    private float currentFlickerOffset;

    private bool flashlightOn = true;

    void OnEnable()
    {
        if (toggleFlashlightAction != null)
        {
            toggleFlashlightAction.action.Enable();
            toggleFlashlightAction.action.performed += ToggleFlashlight;
        }
    }

    void OnDisable()
    {
        if (toggleFlashlightAction != null)
        {
            toggleFlashlightAction.action.performed -= ToggleFlashlight;
        }
    }

    void Start()
    {
        if (flashlightLight == null)
            flashlightLight = GetComponentInChildren<Light>(true);

        if (flashlightLight != null)
            flashlightLight.enabled = flashlightOn;
    }

    void Update()
    {
        if (flashlightLight == null) return;

        if (!flashlightOn)
        {
            flashlightLight.enabled = false;
            return;
        }

        flashlightLight.enabled = true;

        timer += Time.deltaTime;

        float batteryPercent = Mathf.Clamp01(1f - timer / drainDuration);
        float baseIntensity = Mathf.Lerp(minIntensity, maxIntensity, batteryPercent);

        if (batteryPercent <= flickerStartsAt)
        {
            if (Time.time >= nextFlickerTime)
            {
                currentFlickerOffset = Random.Range(-flickerAmount, 0f);
                nextFlickerTime = Time.time + flickerSpeed;
            }

            flashlightLight.intensity = Mathf.Max(0f, baseIntensity + currentFlickerOffset);
        }
        else
        {
            flashlightLight.intensity = baseIntensity;
        }

        if (batteryPercent <= 0f)
        {
            flashlightLight.enabled = false;
            flashlightOn = false;
        }
    }

    void ToggleFlashlight(InputAction.CallbackContext context)
    {
        if (timer >= drainDuration) return;

        flashlightOn = !flashlightOn;
    }
}