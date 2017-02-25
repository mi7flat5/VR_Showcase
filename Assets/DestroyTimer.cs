using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour {

    // Use this for initialization
   public float SecondsToDespawn = 60.0f;
	void Start () {
        StartCoroutine(KillClock());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator KillClock() {
        yield return new WaitForSeconds(SecondsToDespawn);
        Destroy(gameObject);
    }
}
