using UnityEngine;

public class MarkerImageActivator : MonoBehaviour
{
 public GameObject imageToShow;

    void Start()
    {
        if (imageToShow != null)
            imageToShow.SetActive(false); // hide at start
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // only player triggers
        {
            if (imageToShow != null)
                imageToShow.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (imageToShow != null)
                imageToShow.SetActive(false); // hide when leaving
        }
    }
}
