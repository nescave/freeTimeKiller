using UnityEngine;

public class playerMovement : MonoBehaviour {

	public float movementSpeed = 5.0f;
	public CharacterController controller;
	private Vector3 movementVector;

	private Transform cam;
	public Vector3 camPos;
	
	private void Awake() {

	}

	void Start () {
		cam = transform.GetChild(0);
		camPos = cam.transform.localPosition /2;
		//cam.transform.position = Vector3.zero;
	}
	

	void Update () {

		cam.GetComponent<cameraMovement>().camfixedLocation = transform.position + camPos;

		Debug.Log(controller.isGrounded);

		movementVector = new  Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical")); 
		movementVector = transform.TransformDirection(movementVector);
		movementVector *= movementSpeed;
		
		controller.Move(movementVector * Time.deltaTime);
	}
}
