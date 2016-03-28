using UnityEngine;
using System.Collections;

public class EndingSight : MonoBehaviour {

    public float fadeSpeed = 1.5f;
    public GUITexture guiTexture;

	void Awake()
    {
        guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
    }
	
	// Update is called once per frame
	void Update () {
        CloseEyes();
	}

    public void FadeOut()
    {
        guiTexture.color = Color.Lerp(guiTexture.color, Color.white, fadeSpeed * Time.deltaTime);
    }

    public void CloseEyes()
    {
        guiTexture.enabled = true;
        FadeOut();
        if(guiTexture.color.a>0.5f)
        {
            guiTexture.color = Color.white;
        }
    }
}
