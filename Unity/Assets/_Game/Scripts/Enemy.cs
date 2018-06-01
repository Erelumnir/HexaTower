using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Variables
	[Header("Enemy Settings")]
	public float speed = 10f;

	[Header ("Setup")]
	private Transform target;
	private int targetIndex = 0;

	// Use this for initialization
	void Start () {
		target = Waypoints.wayPoints [0];
	}
	
	// Update is called once per frame
	void Update () {
		// Set direction to target
		Vector3 dir = target.position - transform.position;
		// Move in direction
		transform.Translate (dir.normalized * speed * Time.deltaTime, Space.World);

		// If near target..
		if (Vector3.Distance (transform.position, target.position) <= 0.2f){
			// ..Go to next target
			SetNewTarget();
		}
	}

	void SetNewTarget(){
		// If there are no waypoints..
		if (targetIndex >= Waypoints.wayPoints.Length - 1){
			// ..EndPath
			EndPath();
			return;
		}
		// Increase the target Index
		targetIndex++;
		target = Waypoints.wayPoints [targetIndex];
	}

	void EndPath(){
		//REDUCE PLAYER LIVES
		Destroy(gameObject);
	}
}
