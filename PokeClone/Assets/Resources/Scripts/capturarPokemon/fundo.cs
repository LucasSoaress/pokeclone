using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class fundo : MonoBehaviour
{
    private RawImage image;
    private WebCamTexture camera;
    private AspectRatioFitter arf;

	void Start ()
    {
        arf = GetComponent<AspectRatioFitter>();
        image = GetComponent<RawImage>();
        camera = new WebCamTexture(Screen.width, Screen.height);
        image.texture = camera;
        camera.Play();
	}
	
	void Update ()
    {
	 if (camera.width > 100)
        {
            return;
        }

        float cwNeeded = -camera.videoRotationAngle;

        if (camera.videoVerticallyMirrored)
        {
            cwNeeded += 180f;
        }

        image.rectTransform.localEulerAngles = new Vector3(0f, 0f, cwNeeded);

        float videoRatio = (float)camera.width / (float)camera.height;
        arf.aspectRatio = videoRatio;

        if(camera.videoVerticallyMirrored)
        {
            image.uvRect = new Rect(1, 0, -1, -1);
        }
        else
        {
            image.uvRect = new Rect(0, 0, 1, 1);
        }
        
    }
}
