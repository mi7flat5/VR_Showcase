using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoHandler : MonoBehaviour {
    public GameObject video;
    private GameObject videoInstance;
    public GameObject Viewer;
    public float ViewTriggerDistance = 10.0f;
    private bool isPlaying;
    private bool isRequesting;

   
	// Use this for initialization
	void Start () {
        
       
    }
	
	// Update is called once per frame
	void Update () {
        //if (!isPlaying)
        //{
        //    if (Vector3.Distance(transform.position, Viewer.transform.position) < ViewTriggerDistance)
        //        RequestVideo();
        //}
        if (!isPlaying && !GetComponent<MeshRenderer>().enabled)
            GetComponent<MeshRenderer>().enabled = true;

    }

    ///Do Not Call Directly if using with Android, use RequestVideo
    public void StartVideo() { videoInstance = (GameObject)Instantiate(video);
        videoInstance.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        videoInstance.transform.rotation = transform.rotation;
        videoInstance.transform.localScale = transform.localScale;
        GetComponent<MeshRenderer>().enabled = false;
     
        isPlaying = true;
    }

    public void EndVideo() { Destroy(videoInstance);
        isPlaying = false; }
    public bool IsPlaying() { return isPlaying;
    }
    public void RequestVideo() {
        if (!isPlaying)
            SendMessageUpwards("VideoRequested",gameObject);
    }
}
