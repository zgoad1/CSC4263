using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyUpdate : MonoBehaviour {

    /* Pick a random destination point (within a radius) and walk there, 
     * wait a random amount of time, repeat.
     */

    public NavMeshAgent agent;

    private Vector3 destination = Vector3.zero;
    private int waitFrames;
    private int waitMin = 60;
    private int waitMax = 300;
    private float distance;
    private float distanceMin = 10f;
    private float distanceMax = 25f;
    private string state = "wait";

    void SetWaitFrames() {
        waitFrames = Random.Range(waitMin, waitMax);
        Debug.Log("setting waitframes to " + waitFrames);
    }

    void SetDestination() {
        distance = Random.Range(distanceMin, distanceMax);
        Vector2 randomMove;

        // move a random direction in a radius of this distance
        randomMove = Random.insideUnitCircle * distance;
        destination.x += randomMove.x;
        destination.z += randomMove.y;
        Debug.Log("Moving");

        agent.SetDestination(destination);

        Debug.Log("setting destination to " + destination);
    }

    // Use this for initialization
    void Start() {
        agent = GetComponent<NavMeshAgent>();
        SetWaitFrames();
        destination = transform.position;
    }

    // Update is called once per frame
    void Update() {
        if(state == "wait") {
            if(waitFrames <= 0) {
                SetDestination();
                SetWaitFrames();
                state = "move";
            }

            waitFrames--;
        } else {
            // if we're basically at the destination, change state to wait
            if(transform.position.x == destination.x && transform.position.z == destination.z) {
                Debug.Log("Stopped, changing to wait");
                state = "wait";
            }
        }
    }
}
