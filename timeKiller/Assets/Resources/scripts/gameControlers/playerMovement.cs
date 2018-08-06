using UnityEngine;

public class playerMovement : MonoBehaviour {

	public float movementSpeed = 5.0f;
	private CharacterController controller;
	public Vector3 movementVector;
	public float gravity = 100.0f;

	[Header("CameraStuff")]
	private GameObject camTransform;
	private cameraMovement camMove;
	public Camera cam;
	private Vector3 camPos;
	public Vector2 mousePos;
 	public Vector3 targetPos;
	public Vector3 AlignDir;
	public float planeDistance;
	private RaycastHit hit;
	private Ray ray;
	public LayerMask mask;
	
	private void Awake() {

	}

	void Start () {
		camTransform = GameObject.Find("/CameraParent");
		camPos = camTransform.transform.localPosition;
		cam = camTransform.GetComponentInChildren<Camera>();
		camMove = camTransform.GetComponent<cameraMovement>();
		//camPos.transform.position = Vector3.zero;
		controller = GetComponent<CharacterController>();
		
	}
	

	void Update () {
		camMove.camfixedLocation = transform.position + camPos;
		mousePos = Input.mousePosition;
		ray = cam.ScreenPointToRay(new Vector3(mousePos.x,mousePos.y, 0f));
		Debug.DrawRay(ray.origin, ray.direction *10f, Color.red);
		Physics.Raycast(ray, out hit,20f, mask);
		planeDistance = hit.distance;
		targetPos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, planeDistance));
		AlignDir = targetPos - transform.position;
		AlignDir.y = 0;
		transform.rotation = Quaternion.LookRotation(AlignDir);

		move();
	}


	private void move(){
		movementVector = new  Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
		//Vector3  WDirection = transform.TransformDirection(movementVector);

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
		//movementVector = transform.TransformDirection(movementVector);

		controller.Move(movementVector * Time.deltaTime);
	}
}
