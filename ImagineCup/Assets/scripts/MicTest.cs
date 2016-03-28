using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MicTest : MonoBehaviour {

    public float sensitivity = 100;
    public float loudness = 0;
    private string input;
    public bool exit = false;
    public bool voiceplay = false;
	// Use this for initialization
	void Start () {
        input = Microphone.devices[0].ToString();
        GetComponent<AudioSource>().clip = Microphone.Start(null, true, 30, 44100);
        while(!(Microphone.GetPosition(input)>0))
        {}
	}

	// Update is called once per frame
	void Update () {
        
        if(exit)
        {
            Microphone.End(null);
        }
        if((!GetComponent<AudioSource>().isPlaying) && voiceplay)
        {
            GetComponent<AudioSource>().Play();
        }
	}

    float GetAveragedVolume()
    {
        float[] data = new float[256];
        float a = 0;
        GetComponent<AudioSource>().GetOutputData(data, 0);
        foreach(float s in data)
        {
            a += Mathf.Abs(s);
        }

        return a / 256;
    }
}
