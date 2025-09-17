using System.Collections;
using UnityEngine;

public class MarkerImageActivator : MonoBehaviour
{
    [Header("UI References")]
    public GameObject initialImage;           // Initial image shown with buttons
    public GameObject hoverImage;             // Image shown when HoverButton clicked
    public GameObject estimateImage;          // Image shown when EstimateButton clicked
    public GameObject buttonsGroup;           // Parent GameObject containing the 3 buttons

    [Header("XActement Sequence")]
    public GameObject[] xActementImages;      // Array of images to display in sequence
    public float xActementDisplayTime = 2f;   // Duration each image is shown

    private Coroutine xActementCoroutine;     // To keep track of running coroutine

    void Start()
    {
        // Hide all images and buttons at start
        HideAllImages();
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
            // Stop any running XActement sequence
            if (xActementCoroutine != null)
                StopCoroutine(xActementCoroutine);

            HideAllImages();
            if (buttonsGroup != null) buttonsGroup.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // ---------- BUTTON METHODS ----------
    public void ShowHoverImage()
    {
        StopXActementSequence();
        HideAllImages();
        if (hoverImage != null) hoverImage.SetActive(true);
        if (buttonsGroup != null) buttonsGroup.SetActive(true); // keep buttons visible
    }

    public void ShowEstimateImage()
    {
        StopXActementSequence();
        HideAllImages();
        if (estimateImage != null) estimateImage.SetActive(true);
        if (buttonsGroup != null) buttonsGroup.SetActive(true); // keep buttons visible
    }

    public void ShowXActementImage()
    {
        StopXActementSequence();
        HideAllImages();
        if (buttonsGroup != null) buttonsGroup.SetActive(true);

        if (xActementImages != null && xActementImages.Length > 0)
        {
            xActementCoroutine = StartCoroutine(PlayXActementSequence());
        }
    }

    private IEnumerator PlayXActementSequence()
    {
        foreach (var img in xActementImages)
        {
            HideAllImages();       // hide previous
            if (img != null)
                img.SetActive(true);
            yield return new WaitForSeconds(xActementDisplayTime);
        }

        // Optionally keep the last image visible or hide all at the end
        HideAllImages();
        if (buttonsGroup != null)
            buttonsGroup.SetActive(true);
    }

    private void StopXActementSequence()
    {
        if (xActementCoroutine != null)
        {
            StopCoroutine(xActementCoroutine);
            xActementCoroutine = null;
        }
    }

    // Hide all images
    private void HideAllImages()
    {
        if (initialImage != null) initialImage.SetActive(false);
        if (hoverImage != null) hoverImage.SetActive(false);
        if (estimateImage != null) estimateImage.SetActive(false);
        if (xActementImages != null)
        {
            foreach (var img in xActementImages)
                if (img != null) img.SetActive(false);
        }
    }
}
