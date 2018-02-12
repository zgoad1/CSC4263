using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyUpdate : MonoBehaviour {

    /* Pick a random destination point (within a radius) and walk there, 
     * wait a random amount of time, repeat.
     */

    public NavMeshAgent agent;

    private Vector3 destination;
    private int waitFrames;
    private int waitMin = 20;
    private int waitMax = 240;

    void setWaitFrames() {
        waitFrames = Random.Range(waitMin, waitMax);
    }

    void setDestination() {

    }

	// Use this for initialization
	void Start () {
        setWaitFrames();
        setDestination();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
