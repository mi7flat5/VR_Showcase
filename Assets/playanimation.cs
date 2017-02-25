using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playanimation : MonoBehaviour {

  
    private Animator animator;
   
  
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        if(animator)
        animator.Stop();
       
    }
	
	// Update is called once per frame
	void Update () {
     
       
    }
    public void PlayAnimation() {  animator.Rebind(); }
    //Specific to Robot events
  
    
    
}
