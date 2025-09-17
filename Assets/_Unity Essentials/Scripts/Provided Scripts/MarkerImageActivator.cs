using UnityEngine;

public class MarkerImageActivator : MonoBehaviour
{
    [Header("Assign only the image (not the button)")]
    public GameObject imageToShow;

    void Start()
    {
        if (imageToShow != null)
            imageToShow.SetActive(false); // hide at start

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (imageToShow != null)
                imageToShow.SetActive(true);

            // Unlock + show cursor so player can interact
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HideImage();
        }
    }

    // 🔹 Call this from your CheckEstimateButton OnClick()
    public void HideImage()
    {
        if (imageToShow != null)
            imageToShow.SetActive(false);

        // Lock + hide cursor back for gameplay
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
