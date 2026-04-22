using UnityEngine;
using System.Collections.Generic;

public class LightSwitch : MonoBehaviour
{
    public Animator animator;
    public List<Light> lights = new List<Light>();
    public bool isOn = false;
    public Material mat;

    void Start()
    {
        foreach (Light l in lights)
        {
            l.enabled = false;
        }
        mat.DisableKeyword("_EMISSION");
    }

    public void ToggleLight()
    {
        //turn off
        if (isOn)
        {
            foreach (Light l in lights)
            {
                l.enabled = false;
            }
            mat.DisableKeyword("_EMISSION");
            isOn = false;
            animator.SetBool("isOpen", isOn);
        }
        //turn on
        else
        {
            foreach (Light l in lights)
            {
                l.enabled = true;
            }
            mat.EnableKeyword("_EMISSION");
            isOn = true;
            animator.SetBool("isOpen", isOn);
        }
    }

}
