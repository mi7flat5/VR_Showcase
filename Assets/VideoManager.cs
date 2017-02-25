using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VideoManager : MonoBehaviour {
    public GameObject[] videos;
    private GameObject requestingObject;
    public float waitTime = 3.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
                
    public void VideoRequested(GameObject requester) {
        foreach (GameObject player in videos)

        {
            if (player != requester)
            {
                VideoHandler current = (VideoHandler)player.GetComponent(typeof(VideoHandler));
                if (current.IsPlaying())
                    current.EndVideo();
            }

        }
#if UNITY_ANDROID && !UNITY_EDITOR
        StartCoroutine(WaitforVideoThread(waitTime, requester));

#else
        VideoHandler newVideoPlayer = (VideoHandler)requester.GetComponent(typeof(VideoHandler));
             newVideoPlayer.StartVideo();
#endif


    }

    IEnumerator WaitforVideoThread(float time, GameObject requester) {
        yield return new WaitForSeconds(time);
        VideoHandler newVideoPlayer = (VideoHandler)requester.GetComponent(typeof(VideoHandler));
        newVideoPlayer.StartVideo();
        yield return null;

    }

}
