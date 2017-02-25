using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAt : MonoBehaviour {
    public GameObject target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.forward = Vector3.Normalize(new Vector3(target.transform.position.x,0,target.transform.position.z)-transform.position);
        transform.position = new Vector3(transform.position.x, .5f,transform.position.z);

    }
    public void SetTarget(GameObject InTarget) { target = InTarget;  }
}
