using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotEvents : MonoBehaviour {
    public GameObject SparkPrefab;
    public GameObject PartDirty,PartClean;
    public GameObject steamPrefab;
    public GameObject SpawnPoint;
    public GameObject weldPoint;
    public GameObject drillPoint;
    public GameObject steamPoint;
    public GameObject HolderRobot;
    private bool HolderTurned = false;
    private Animator animator;
    public string RobotName;
    private bool correctTurn = false;
    private GameObject Engine;
    private GameObject Particles;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        if (animator)
            animator.Stop();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void PlayAnimation() { animator.Rebind(); SendMessageUpwards("UpdateRobotChoice", gameObject); }
    public void WeldSparkSpark() { Particles = (GameObject)Instantiate(SparkPrefab);
        Particles.transform.position = weldPoint.transform.position;
        Particles.transform.rotation = weldPoint.transform.rotation;
    }
    public void RobotHolderTurn() { animator.Play("RobotHolderTurn"); HolderTurned = true; }
    public void RobotHolderTurnBack() { animator.Play("RobotHolderTurnBack"); }
    public bool HolderRobotTurned() { return HolderTurned; }
    public void SetHolderTurned(bool turnState) { HolderTurned = turnState; }

    public void EventRobotTurn() {
        if (!HolderRobot.GetComponent<RobotEvents>().HolderRobotTurned()&& correctTurn)
        {
            HolderRobot.GetComponent<RobotEvents>().RobotHolderTurn();
        }
    }

    public void EventRobotTurnBack() {
         
        if (HolderRobot.GetComponent<RobotEvents>().HolderRobotTurned())
        {
            HolderRobot.GetComponent<RobotEvents>().RobotHolderTurnBack();
            HolderRobot.GetComponent<RobotEvents>().SetHolderTurned(false);
            
        }
    }
    public string GetRobotName() { return RobotName; }
    public void SetCorrectTurn(bool TurnState) { correctTurn = TurnState; }
    public void ResetChoice() {
        correctTurn = false;
        Destroy(Engine);
    }
    public void DestroyParticles() { Destroy(Particles); }
    public void DrillSpark()
    {
        if (correctTurn)
        {
            Particles = Instantiate(SparkPrefab, new Vector3(drillPoint.transform.position.x, drillPoint.transform.position.y, drillPoint.transform.position.z), Quaternion.identity);
            Particles.transform.rotation = drillPoint.transform.rotation;
            Particles.transform.parent = drillPoint.gameObject.transform;
        }
    }
    public void Steam()
    {
      
        Particles = Instantiate(steamPrefab,new Vector3(steamPoint.transform.position.x, steamPoint.transform.position.y, steamPoint.transform.position.z), Quaternion.identity);
        Particles.transform.rotation = steamPoint.transform.rotation;
        Particles.transform.parent = steamPoint.gameObject.transform;
    
      
    }
    public void SpawnFirstEngine() {
        if (correctTurn)
        {
            Destroy(Engine);
            Engine = Instantiate(PartDirty, new Vector3(SpawnPoint.transform.position.x, SpawnPoint.transform.position.y, SpawnPoint.transform.position.z), Quaternion.identity);
            Engine.transform.rotation = SpawnPoint.transform.rotation;
            Engine.transform.parent = SpawnPoint.gameObject.transform;
        }
    }
    public void SpawnSecondEngine() {
        //if (Engine)
            Destroy(Engine);
      

            Engine = Instantiate(PartClean, new Vector3(SpawnPoint.transform.position.x, SpawnPoint.transform.position.y, SpawnPoint.transform.position.z), Quaternion.identity);
            Engine.transform.rotation = SpawnPoint.transform.rotation;
            // Engine.transform.parent = SpawnPoint.gameObject.transform;
        
    }
}
