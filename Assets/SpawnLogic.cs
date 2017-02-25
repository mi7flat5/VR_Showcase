using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLogic : MonoBehaviour {
    public GameObject[] Spawnables;
    private bool waiting;
    public float SpawnRate = 30.0f;
	// Use this for initialization
	void Start () {
        StartCoroutine(Spawner());

	}
	
	// Update is called once per frame
	void Update () {
        if(!waiting)
            StartCoroutine(Spawner());

    }

    IEnumerator Spawner() {
        waiting = true;
        yield return new WaitForSeconds(SpawnRate);

        GameObject NewObject = (GameObject)Instantiate(Spawnables[Random.Range(0,Spawnables.Length)]);
        NewObject.transform.position = transform.position;
        waiting = false;
    }
}
