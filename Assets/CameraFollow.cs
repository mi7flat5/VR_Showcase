using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour {
    public GameObject CameraToFollow;
    public GameObject MainMenu;
    public GameObject ToMainMenu;
    public GameObject CameraFaceing;
    public GameObject Logic;

	// Use this for initialization
	void Start () {
        Logic.GetComponent<RaycastMovement>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 newpos = CameraToFollow.transform.position+CameraToFollow.transform.forward;// new Vector3(CameraToFollow.transform.position.x+1, 1.0F,CameraToFollow.transform.position.z+1); 
        transform.position = new Vector3(newpos.x, 0.25F, newpos.z);
        transform.rotation = Quaternion.Euler(90, CameraToFollow.transform.eulerAngles.y, 0);


        MainMenu.transform.position = new Vector3(MainMenu.transform.position.x, 3.0F, MainMenu.transform.position.z);
       MainMenu.transform.rotation = Quaternion.Euler(0, CameraToFollow.transform.eulerAngles.y, 0);

        if (Vector3.Dot(CameraToFollow.transform.forward, new Vector3(0, 1, 0)) < -0.75f)
        { GetComponent<Canvas>().enabled = true; }
        if (Vector3.Dot(CameraToFollow.transform.forward, new Vector3(0, 1, 0)) > -0.75f)
        { GetComponent<Canvas>().enabled = false; }

        
    }

    public void ActivateMainMenu() {
        
        MainMenu.GetComponent<Canvas>().enabled = true;
        Logic.GetComponent<RaycastMovement>().enabled = false;
    }
    public void DisactivateMainMenu()
    {
       
        MainMenu.GetComponent<Canvas>().enabled = false;
        Logic.GetComponent <RaycastMovement> ().enabled = true;
      

    }
    public void Reload() {
        SceneManager.LoadScene("main");
      
    }
}
