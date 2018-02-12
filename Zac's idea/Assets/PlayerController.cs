using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    public LayerMask movementMask;
    public LayerMask enemyMask;

    private float attackRange = 1f;
    private PlayerMotor motor;
    private GameObject focus;

	// Use this for initialization
	void Start () {
        motor = GetComponent<PlayerMotor>();
	}

    // Update is called once per frame
    void Update() {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Cast out a ray every frame to determine cursor icon & click action
        if(Physics.Raycast(ray, out hit, movementMask)) {

            // walk icon cursor

            // Walk there
            if(Input.GetAxis("LMB") != 0f) {
                motor.MoveToPoint(hit.point);
                focus = null;
            }
        } else if(Physics.Raycast(ray, out hit, enemyMask)) {

            // change cursor based on hit type & position
            if(hit.collider.tag == "Enemy") {

                // attack icon cursor

                // Follow enemy, and attack when in range
                if(Input.GetAxis("LMB") != 0f) {
                    focus = hit.collider.gameObject;
                }
            }
        } else {

            // crossed-out movement cursor

            // play menacing sound effect because can't do anything

        }

        // follow focus object
        if(focus != null) {
            // continuously set the destination point in case the focus is moving
            motor.MoveToPoint(focus.transform.position);

            if(Vector3.Distance(focus.transform.position, transform.position) < attackRange) {
                // attack enemy

                // Stop following them (assuming enemies won't run away)
                focus = null;
            }
        }
    }
}
