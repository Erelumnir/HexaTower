// Partially from Brackeys
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	// Variables
	private bool doMovement = true;

	[Header("Camera Settings")]
	public float panSpeed = 30f;
	public float panBorderThickness = 5f;

	public float scrollSpeed = 5f;
	public float minY = 8f;
	public float maxY = 20f;
	public float minX = -1f;
	public float maxX = 15f;
	public float minZ = -15f;
	public float maxZ = 3f;

	// Update is called once per frame
	void Update () {
		// Lock camera movement
		if (Input.GetKeyDown(KeyCode.Escape)) {
			doMovement = !doMovement;
		}

		if (!doMovement) {
			return;
		}

		// Camera panning with buttons and mouse edge scrolling
		if (Input.GetKey ("w") || Input.mousePosition.y >= Screen.height - panBorderThickness) {
			transform.Translate (Vector3.forward * panSpeed * Time.deltaTime, Space.World);
		} 
		if (Input.GetKey ("s") || Input.mousePosition.y <= panBorderThickness) {
			transform.Translate (Vector3.back * panSpeed * Time.deltaTime, Space.World);
		} 
		if (Input.GetKey ("a") || Input.mousePosition.x <= panBorderThickness) {
			transform.Translate (Vector3.left * panSpeed * Time.deltaTime, Space.World);
		} 
		if (Input.GetKey ("d") || Input.mousePosition.x >= Screen.width - panBorderThickness) {
			transform.Translate (Vector3.right * panSpeed * Time.deltaTime, Space.World);
		} 

		// Scroll camera
		float scroll = Input.GetAxis("Mouse ScrollWheel");

		Vector3 pos = transform.position;

		pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
		pos.y = Mathf.Clamp (pos.y, minY, maxY);
		pos.x = Mathf.Clamp (pos.x, minX, maxX);
		pos.z = Mathf.Clamp (pos.z, minZ, maxZ);

		transform.position = pos;
	}
}
