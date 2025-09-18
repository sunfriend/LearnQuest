using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SceneIntroController : MonoBehaviour
{
    [Header("UI References")]
    public Image blackScreen;              // Fullscreen black overlay
    public TextMeshProUGUI introText;      // TMP Text for message
    public Image umbrellaIcon;             // Small umbrella icon in the corner

    [Header("Audio References")]
    public AudioSource doorAudioSource;
    public AudioClip doorClip;             // Single clip with open + close sounds

    [Header("Timing")]
    public float initialDelay = 2f;        // Delay before playing sound

    [Header("Dynamic Text")]
    [TextArea]
    public string message = "You enter the room to do the inspection.";  // Dynamic message

    void Start()
    {
        // Show black screen and text at start
        if (blackScreen != null)
            blackScreen.gameObject.SetActive(true);

        if (introText != null)
        {
            introText.text = message;
            introText.gameObject.SetActive(true);
        }

        if (umbrellaIcon != null)
            umbrellaIcon.gameObject.SetActive(true); // Show umbrella icon

        StartCoroutine(PlayIntroSequence());
    }

    private IEnumerator PlayIntroSequence()
    {
        // Wait while black screen, text, and icon are visible
        yield return new WaitForSeconds(initialDelay);

        // Play door sound
        if (doorAudioSource != null && doorClip != null)
            doorAudioSource.PlayOneShot(doorClip);

        // Wait until the sound finishes
        float clipDuration = doorClip != null ? doorClip.length : 1f;
        yield return new WaitForSeconds(clipDuration);

        // Hide black screen, text, and icon
        if (blackScreen != null)
            blackScreen.gameObject.SetActive(false);

        if (introText != null)
            introText.gameObject.SetActive(false);

        if (umbrellaIcon != null)
            umbrellaIcon.gameObject.SetActive(false);
    }
}
