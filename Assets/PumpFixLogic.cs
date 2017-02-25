using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PumpFixLogic : MonoBehaviour {
    public GameObject WrenchImage;
    public GameObject OilImage;
    public GameObject WarningImage;
    public Texture RepairedImage;
    public GameObject PowerInfoPanel;
    public GameObject Pointer;
    public GameObject NextPointOfInterest;
    public GameObject Camera;
    public GameObject[] soundSources;
    public GameObject Barrier;
    public AudioClip bad, success,good;
    private bool WrenchUsed = false;
    private GvrAudioSource gameaudio;
    private RawImage img;
    private Text PowerMessage;
	// Use this for initialization
	void Start () {
        foreach (GameObject sound in soundSources)
            sound.GetComponent<GvrAudioSource>().mute = true;
        gameaudio = GetComponent<GvrAudioSource>();
	}       
	
	// Update is called once per frame
	void Update () {
		
	}
    public void UseOilCan() { if (WrenchUsed)
        {

            Destroy(OilImage);
            img = (RawImage)WarningImage.GetComponent<RawImage>();
            img.texture = RepairedImage;
            img.GetComponent<Animator>().Stop();
            img.color = new Color(0, 1, 0);
            PowerMessage = PowerInfoPanel.GetComponent<Text>();
            PowerMessage.text = "Power Restored!";
            Pointer.GetComponent<PointAt>().SetTarget(NextPointOfInterest);
            foreach (GameObject sound in soundSources)
                sound.GetComponent<GvrAudioSource>().mute = false;
            //  Destroy(Barrier);
            gameaudio.clip = success;
            gameaudio.Play();

        }
        else { gameaudio.clip = bad; gameaudio.Play(); }
    }
    public void UseWrench() {
        WrenchUsed = true;
        Destroy(WrenchImage);
        gameaudio.clip = good;
        gameaudio.Play();
    }
}
