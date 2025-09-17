using UnityEngine;

public class MarkerImageActivator : MonoBehaviour
{
    [Header("UI References")]
    public GameObject initialImage;      // Initial image shown with buttons
    public GameObject hoverImage;        // Image shown when HoverButton clicked
    public GameObject xActementImage;    // Image shown when XActementButton clicked
    public GameObject estimateImage;     // Image shown when EstimateButton clicked
    public GameObject buttonsGroup;      // Parent GameObject containing the 3 buttons

    void Start()
    {
            // Hide all images and buttons at start
        if (initialImage != null) initialImage.SetActive(false);
        if (hoverImage != null) hoverImage.SetActive(false);
        if (xActementImage != null) xActementImage.SetActive(false);
        if (estimateImage != null) estimateImage.SetActive(false);
        if (buttonsGroup != null) buttonsGroup.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Show initial image and buttons
            if (initialImage != null) initialImage.SetActive(true);
            if (buttonsGroup != null) buttonsGroup.SetActive(true);

            // Unlock and show cursor for UI interaction
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HideAllImages();
            if (buttonsGroup != null) buttonsGroup.SetActive(false);

            // Lock cursor back for gameplay
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // ---------- BUTTON METHODS ----------
    public void ShowHoverImage()
    {
        HideAllImages();
        if (hoverImage != null) hoverImage.SetActive(true);
        if (buttonsGroup != null) buttonsGroup.SetActive(true); // keep buttons visible
    }

    public void ShowXActementImage()
    {
        HideAllImages();
        if (xActementImage != null) xActementImage.SetActive(true);
        if (buttonsGroup != null) buttonsGroup.SetActive(true); // keep buttons visible
    }

    public void ShowEstimateImage()
    {
        HideAllImages();
        if (estimateImage != null) estimateImage.SetActive(true);
        if (buttonsGroup != null) buttonsGroup.SetActive(true); // keep buttons visible
    }

    // Hide all images
    private void HideAllImages()
    {
        if (initialImage != null) initialImage.SetActive(false);
        if (hoverImage != null) hoverImage.SetActive(false);
        if (xActementImage != null) xActementImage.SetActive(false);
        if (estimateImage != null) estimateImage.SetActive(false);
    }
}
