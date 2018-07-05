using UnityEngine;

public class playerMovement : MonoBehaviour {

	public float movementSpeed = 5.0f;
	private CharacterController controller;
	private Vector3 movementVector;
	public float gravity = 100.0f;

	private Transform cam;
	public Vector3 camPos;
	
	private void Awake() {

	}

	void Start () {
		cam = transform.GetChild(0);
		camPos = cam.transform.localPosition /2;
		//cam.transform.position = Vector3.zero;
		controller = GetComponent<CharacterController>();
	}
	

	void Update () {
		cam.GetComponent<cameraMovement>().camfixedLocation = transform.position + camPos;
		move();
	}


	private void move(){
		movementVector = new  Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical")); 

		if (isButtonPressed())
			movementVector = movementVector.normalized; // the velocity vector must have a magnitude of 1, even if going in two directions at once

		makeMovement(movementVector);
	}

	private bool isButtonPressed(){
		return Input.GetButton("Horizontal") || Input.GetButton("Vertical");
	}

	private void makeMovement(Vector3 movementVector){
		movementVector *= movementSpeed;
		movementVector.y -= gravity;
		movementVector = transform.TransformDirection(movementVector);

		controller.Move(movementVector * Time.deltaTime);
	}
}
