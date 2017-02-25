using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOrient : MonoBehaviour {
    public GameObject CameraToFollow;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.rotation = Quaternion.Euler(0, CameraToFollow.transform.eulerAngles.y, 0);
    }
    void Disable() {
      
    }
}
