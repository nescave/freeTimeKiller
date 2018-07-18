using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

	public float attackSpeed; 
	public float bulletSpeed;
	public AmmunitionSystem ammunition;
	public GameObject bullet;
	private float shootProgress = 99;
	private bool isActive = true;
	
	
	void Update () {
		if (Input.GetButton("Fire1")){
			if (isActive){
				shoot();
				}
		}
		else if(Input.GetButtonDown("Reload")){
			ammunition.reload();
		}
		else shootProgress = 99;
		
	}

	private void shoot(){
		if(!ammunition.isMagazineEmpty()){
			shootProgress+=(attackSpeed*Time.deltaTime*100);
			if(shootProgress>=100){		
				fireBullet(calculateBulletDirection().normalized);
				ammunition.currentlyLoaded--;
				shootProgress = 0;
			}
		}else ammunition.reload();
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

	public void setInactive(){
		this.isActive = false;
	}

	public void setActive(){
		this.isActive = true;
	}
}
