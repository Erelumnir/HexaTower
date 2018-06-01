using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour {

	// Variables
	public static Transform[] wayPoints;

	void Awake(){
		// Set waypoint to an array of transforms
		wayPoints = new Transform[transform.childCount];
		// Get all the waypoints in the Group Waypoints
		for (int i = 0; i < wayPoints.Length; i++) {
			wayPoints [i] = transform.GetChild (i);
		}
	}
}
