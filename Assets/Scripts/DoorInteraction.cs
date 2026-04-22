using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public Animator animator;
    private bool isOpened = false;
    public GameObject TeleportToEnd;

    [Header("Key")]
    public bool unlocked = true;
    public GameObject key;

    private void OnTriggerEnter(Collider other)
    {
        if (!unlocked)
        {
            if (other.gameObject == key)
            {
                unlocked = true;
                isOpened = !isOpened;
                animator.SetBool("isOpen", isOpened);
                TeleportToEnd.SetActive(true);
            }
        }
    }

    public void OpenDoor()
    {
        if (unlocked)
        {
            isOpened = !isOpened;
            animator.SetBool("isOpen", isOpened);
            TeleportToEnd.SetActive(true); //remove after set key
        }
    }

}
