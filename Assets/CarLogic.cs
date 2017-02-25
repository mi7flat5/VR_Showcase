using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CarLogic : MonoBehaviour {
    public GameObject VideoPanel;
    public GameObject Pointer;
    public GameObject NextPointOfInterest;
    public GameObject Viewer;
    public GameObject DriversSeat;
    private Vector3 previousPosition;
    public GameObject InCarUI;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

     
    }
    public void GetInCar() {
        previousPosition = Viewer.transform.position;
        //Google cardboard sdk removes any rotation applied to camera, so 
        // if you want viewer to face another direction you have to rotate the entire scene
        
        Viewer.transform.position = DriversSeat.transform.position;
        Viewer.GetComponentInChildren<RaycastMovement>().enabled = false;
        InCarUI.SetActive(true);
        VideoPanel.GetComponent<VideoHandler>().RequestVideo();
        
       
     
        
    
    }
    public void ExitCar() {
       // InCarUI.SetActive(false);
        Viewer.transform.position = previousPosition;
        Viewer.GetComponentInChildren<RaycastMovement>().enabled = true;
        Pointer.GetComponent<PointAt>().SetTarget(NextPointOfInterest);
     
       
    }
}
