using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {

	public float cameraRange = 1f;
	public Vector2 cursorLocation;
	private Vector3 camLocation;
	public Vector3 camfixedLocation;
	// Use this for initialization
	void Start () {
		camfixedLocation = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float camRangeX = cameraRange ;
		float camRangeY = cameraRange ;
		camLocation.x = Mathf.Lerp(camfixedLocation.x - camRangeX, camfixedLocation.x + camRangeX, Mathf.Sin(Mathf.Clamp(cursorLocation.x,0,1)));
		camLocation.y = Mathf.Lerp(camfixedLocation.z - camRangeY*1.7f, camfixedLocation.z + camRangeY, Mathf.Sin(Mathf.Clamp(cursorLocation.y,0,1)));
		cursorLocation = Input.mousePosition / new Vector2(Screen.width, Screen.height);
		transform.position = new Vector3(camLocation.x, transform.position.y, camLocation.y);
	}
}
