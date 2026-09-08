using UnityEngine;
using UnityEngine.UI;

public class WebcamBackground : MonoBehaviour
{
    private WebCamTexture camTexture;
    private RawImage rawImage;

    void Start()
    {
        rawImage = GetComponent<RawImage>();

        if (WebCamTexture.devices.Length > 0)
        {
            camTexture = new WebCamTexture(WebCamTexture.devices[0].name);
            rawImage.texture = camTexture;
            camTexture.Play();
        }
        else
        {
            Debug.LogError("No webcam detected.");
        }
    }
}