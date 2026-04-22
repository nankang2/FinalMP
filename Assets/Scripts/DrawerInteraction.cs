using UnityEngine;

public class DrawerInteraction : MonoBehaviour
{
    public Animator animator;
    private bool isOpened = false;

    [Header("Key")]
    public bool unlocked = true;
    public GameObject key;

    //void Start()
    //{
    //    animator = GetComponent<Animator>();
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (!unlocked)
        {
            if (other.gameObject == key)
            {
                unlocked = true;
                isOpened = true;
                animator.SetBool("isOpen", isOpened);
            }
        }
    }

    public void ToggleDrawer()
    {
        if (unlocked)
        {
            isOpened = !isOpened;
            animator.SetBool("isOpen", isOpened);
        }
    }

}
