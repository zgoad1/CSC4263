using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour {

    public PlayerController player;

    private Vector3 newPos;
    private float maxHeight = 40f;
    private float zMin = 13f;
    private float zMax = 55f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate() {

        // calculate desired position of camera, then lerp to it
        newPos.z = Mathf.Clamp(player.transform.position.z - 5, zMin, zMax);    // offset because angled forward
        newPos.x = transform.position.x;
        newPos.y = maxHeight;

        transform.position = Vector3.Lerp(transform.position, newPos, 0.1f);
    }
}
