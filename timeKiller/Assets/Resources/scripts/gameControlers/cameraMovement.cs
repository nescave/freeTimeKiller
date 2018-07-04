using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {

	public float cameraRange = 1f;
	public Vector2 cursorLocation;
	private Vector3 camLocation = Vector3.zero;
	public Vector3 camfixedLocation;
	// Use this for initialization
	void Start () {
		Cursor.SetCursor(null, new Vector2(.5f,.5f), CursorMode.Auto);
	}
	
	// Update is called once per frame
	void Update () {
		float camRangeX = cameraRange ;
		float camRangeZ = cameraRange ;
		camLocation.x = Mathf.Lerp(- camRangeX, camRangeX, Mathf.Sin(Mathf.Clamp(cursorLocation.x,0,1)));
		camLocation.z = Mathf.Lerp(- camRangeZ, camRangeZ, Mathf.Sin(Mathf.Clamp(cursorLocation.y,0,1)));
		cursorLocation = Input.mousePosition / new Vector2(Screen.width, Screen.height);
		transform.position = camfixedLocation + camLocation;
	}
}
