using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class physicsCamera : MonoBehaviour {

	private Rigidbody rig;
	public Transform target;

	public Vector3 pullVector;

	[Header("pullProperties")]
	public float strength = 1;
	public float maxVelocity =1;

	void Start () {
		rig = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		pullVector = target.position -  transform.position;

		if(rig.velocity.magnitude < maxVelocity	){
			rig.AddForce(pullVector * strength, ForceMode.Force);
		}
	}
}
