using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour {

	public float attackSpeed; 
	public float bulletSpeed = 10000f;
	public GameObject bullet;
	private float shootProgress = 99;

	void Start () {
		
	}
	
	void Update () {
		if (Input.GetButton("Fire1")){
			shoot();
		}
		else shootProgress = 99;
	}

	private void shoot(){
		shootProgress+=(attackSpeed*Time.deltaTime*100);
		if(shootProgress>=100){		
			fireBullet(calculateBulletDirection().normalized);
			shootProgress = 0;
		}
	}


	private Vector3 calculateBulletDirection(){
		Ray direction  = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit camHit;
		Physics.Raycast(direction,out camHit,18f);
		return  camHit.point - transform.position;
	}

	private void fireBullet(Vector3 bulletDirection){
		GameObject bulletFired = Instantiate(bullet,calculateBulletSpawnPosition(),Quaternion.identity);
		Physics.IgnoreCollision(bulletFired.GetComponent<Collider>(),GetComponentInParent<CharacterController>());
		bulletFired.GetComponent<Rigidbody>().AddForce(bulletDirection*bulletSpeed,ForceMode.VelocityChange);
	}
	
	private Vector3 calculateBulletSpawnPosition(){
		Vector3 calculatedBulletSpawnPosition = transform.position;
		calculatedBulletSpawnPosition += new Vector3(0,0,-0.31f); // the bullet spawns at the end of the gun
		return calculatedBulletSpawnPosition;
	}
}
