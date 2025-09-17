using UnityEngine;

public class MarkerImageActivator : MonoBehaviour
{
    public GameObject imageToShow;

    void Start()
    {
        if (imageToShow != null)
            imageToShow.SetActive(false); // hide at start

        // Hide cursor for gameplay
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // only player triggers
        {
            if (imageToShow != null)
                imageToShow.SetActive(true);

            // Unlock + show cursor for UI interaction
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (imageToShow != null)
                imageToShow.SetActive(false);

            // Lock + hide cursor again for gameplay
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
