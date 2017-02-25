using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotLogic : MonoBehaviour {
    public GameObject infoPanel;
    public GameObject barrier;
    public GameObject pointer;
    public GameObject NextPointOfInterest;
    public AudioClip good;
    public AudioClip bad,success;
    public GameObject flowArrow;
    private Text InforMessage;
    private GvrAudioSource gameSound;
    enum robots {Holder, Driller,Welder,Washer }
    private bool []choice;
    private int numChoices;
	// Use this for initialization
	void Start () {
        gameSound = GetComponent<GvrAudioSource>();
        choice = new bool[4];
        for (int i = 0; i< choice.Length; ++i)
            { choice[i] = false; }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void DoLogic(GameObject robot)
    {
        if (numChoices == 4 && choice[(int)robots.Washer])
        {
            Success();
            return;
        }
        for (int i = 0;i< numChoices;++i)
        {
            if (!choice[i])
                Reset();
            else { gameSound.clip = good; gameSound.Play(); robot.GetComponent<RobotEvents>().SetCorrectTurn(true); }
        }
    }
    public void UpdateRobotChoice(GameObject ClickedRobot)
    {


        if (ClickedRobot.GetComponent<RobotEvents>().GetRobotName() == "Holder")
          {
           
            choice[(int)robots.Holder] = true;
            ++numChoices;
            DoLogic(ClickedRobot);

          }
        if (ClickedRobot.GetComponent<RobotEvents>().GetRobotName() == "Driller")
        {
            choice[(int)robots.Driller] = true;
            ++numChoices;
            DoLogic(ClickedRobot);

        }
        if (ClickedRobot.GetComponent<RobotEvents>().GetRobotName() == "Welder")
        {
            choice[(int)robots.Welder] = true;
            ++numChoices;
            DoLogic(ClickedRobot);

        }
        if (ClickedRobot.GetComponent<RobotEvents>().GetRobotName() == "Washer")
        {
            choice[(int)robots.Washer] = true;
            ++numChoices;
            DoLogic(ClickedRobot);

        }

  
    }
    void Reset()
    {
        
        Debug.Log("RESET ROBOTS");
        BroadcastMessage("ResetChoice");
        gameSound.clip = bad;
        gameSound.Play();
        numChoices = 0;
        for (int i = 0; i < choice.Length; ++i)
        { choice[i] = false; }
    }
    void Success() {
        BroadcastMessage("ResetChoice");
       // Destroy(barrier);
        flowArrow.SetActive(true);
        pointer.GetComponent<PointAt>().SetTarget(NextPointOfInterest);
        InforMessage = infoPanel.GetComponent<Text>();
        InforMessage.text = "Robot and personel training complete";
        gameSound.clip = success;
        gameSound.Play();
        numChoices = 0;
        for (int i = 0; i < choice.Length; ++i)
        { choice[i] = false; }
    }
}
