using System.Collections;
using UnityEngine;

public class MarkerImageActivator : MonoBehaviour
{
    [Header("UI References")]
    public GameObject initialImage;           // Initial image shown with buttons
    public GameObject hoverImage;             // Image shown when HoverButton clicked
    public GameObject estimateImage;          // Image shown when EstimateButton clicked
    public GameObject buttonsGroup;           // Parent GameObject containing the buttons

    [Header("XActement Sequence")]
    public GameObject[] xActementImages;      // Array of images to display in XActement sequence
    public float xActementDisplayTime = 2f;   // Duration each image is shown

    [Header("OrderNow Sequence")]
    public GameObject[] orderNowImages;       // Array of images to display in OrderNow sequence
    public float orderNowDisplayTime = 2f;    // Duration each image is shown

    private Coroutine activeCoroutine;        // Keep track of the running coroutine

    void Start()
    {
        HideAllImages();
        if (buttonsGroup != null) buttonsGroup.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (initialImage != null) initialImage.SetActive(true);
            if (buttonsGroup != null) buttonsGroup.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopActiveSequence();
            HideAllImages();
            if (buttonsGroup != null) buttonsGroup.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // ---------- BUTTON METHODS ----------
    public void ShowHoverImage()
    {
        StopActiveSequence();
        HideAllImages();
        if (hoverImage != null) hoverImage.SetActive(true);
        if (buttonsGroup != null) buttonsGroup.SetActive(true);
    }

    public void ShowEstimateImage()
    {
        StopActiveSequence();
        HideAllImages();
        if (estimateImage != null) estimateImage.SetActive(true);
        if (buttonsGroup != null) buttonsGroup.SetActive(true);
    }

    public void ShowXActementImage()
    {
        StopActiveSequence();
        HideAllImages();
        if (buttonsGroup != null) buttonsGroup.SetActive(true);

        if (xActementImages != null && xActementImages.Length > 0)
        {
            activeCoroutine = StartCoroutine(PlayImageSequence(xActementImages, xActementDisplayTime));
        }
    }

    public void ShowOrderNowImage()
    {
        StopActiveSequence();
        HideAllImages();
        if (buttonsGroup != null) buttonsGroup.SetActive(true);

        if (orderNowImages != null && orderNowImages.Length > 0)
        {
            activeCoroutine = StartCoroutine(PlayImageSequence(orderNowImages, orderNowDisplayTime));
        }
    }

    // ---------- COMMON SEQUENCE COROUTINE ----------
    private IEnumerator PlayImageSequence(GameObject[] images, float displayTime)
    {
        foreach (var img in images)
        {
            HideAllImages(); // hide previous
            if (img != null) img.SetActive(true);
            yield return new WaitForSeconds(displayTime);
        }

        // After sequence, hide all except buttons
        HideAllImages();
        if (buttonsGroup != null) buttonsGroup.SetActive(true);
    }

    private void StopActiveSequence()
    {
        if (activeCoroutine != null)
        {
            StopCoroutine(activeCoroutine);
            activeCoroutine = null;
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

        if (orderNowImages != null)
        {
            foreach (var img in orderNowImages)
                if (img != null) img.SetActive(false);
        }
    }
}
