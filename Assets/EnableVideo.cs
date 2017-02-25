using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableVideo : MonoBehaviour {
    public GameObject videoScreen;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void enableVideo()
    {
        if (videoScreen.activeSelf)
        {
            videoScreen.GetComponent<MoviePlayerSample>().Rewind();
            videoScreen.SetActive(false);
            return;
        }
        videoScreen.SetActive(true);
    }
}
