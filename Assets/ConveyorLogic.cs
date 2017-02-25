using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConveyorLogic : MonoBehaviour {
   public GameObject[] ConveyorBelts;
    public GameObject ConveyorInfoBoard;
    public GameObject RobotInfoBoard;
   public GameObject Pointer;
   public GameObject NextPointOfInterest;

 
    // Use this for initialization
    private float conveyorspeedSum;
    private bool success = false;
    private Text ConveyorOptimizedMessage; 


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void UpdateConveyorSpeeds() {
        if (success)
            return;
        float sum = 0;
        foreach (GameObject belt in ConveyorBelts)
        {
            sum += belt.GetComponent<ConveyorScript>().GetConveyorSpeed();
        }
        conveyorspeedSum = sum;
       

        if (conveyorspeedSum > 8.9f && conveyorspeedSum < 9.1f)
            success = true;

        if(success)
        {
           // Destroy(RobotInfoBoard);
          
            ConveyorOptimizedMessage = ConveyorInfoBoard.GetComponent<Text>();
            ConveyorOptimizedMessage.text = "Conveyors Optimized! The next area is available, but feel free to play with the conveyor speeds.";
            Pointer.GetComponent<PointAt>().SetTarget(NextPointOfInterest);
        }
    }
}
