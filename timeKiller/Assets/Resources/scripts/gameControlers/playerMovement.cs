using UnityEngine;

public class playerMovement : MonoBehaviour {

	public float movementSpeed = 5.0f;
	private CharacterController controller;
	private Vector3 movementVector;
	public float gravity = 200.0f;

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

		controller = GetComponent<CharacterController>();
		cam.GetComponent<cameraMovement>().camfixedLocation = transform.position + camPos;

		movementVector = new  Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical")); 
		if (Mathf.Abs(movementVector.x) + Mathf.Abs(movementVector.z) == 2){
			movementVector *= 0.6f;  // fixing the bug where going both forward and sideways made player move faster
		}

		movementVector = transform.TransformDirection(movementVector);
		movementVector *= movementSpeed;
		movementVector.y -= gravity * Time.deltaTime;
		controller.Move(movementVector * Time.deltaTime);
	}
}
