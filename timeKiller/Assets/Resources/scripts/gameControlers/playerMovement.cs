using UnityEngine;

public class playerMovement : MonoBehaviour {

	public float movementSpeed = 5.0f;
	public CharacterController controller;
	private Vector3 movementVector;
	void Start () {
		
	}
	

	void Update () {
		Debug.Log(controller.isGrounded);

		movementVector = new  Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
		movementVector = transform.TransformDirection(movementVector);
		movementVector *= movementSpeed;
		
		controller.Move(movementVector * Time.deltaTime);
	}
}
