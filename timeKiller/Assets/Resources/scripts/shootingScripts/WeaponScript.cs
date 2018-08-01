using UnityEngine;

public class WeaponScript : MonoBehaviour {
	
	public AmmunitionSystem ammunition;

	[Header("WeaponStats")]
	public float attackSpeed; 
	public float bulletSpeed;
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
		}else {
			ammunition.reload();
			shootProgress = 99;
		}
	}

	private Vector3 calculateBulletDirection(){
		Vector3 bulletDirection =  -1* transform.parent.right;
		return bulletDirection;
	}

	private void fireBullet(Vector3 bulletDirection){
		GameObject bulletFired = Instantiate(bullet,calculateBulletSpawnPosition(),Quaternion.identity);
		bulletFired.GetComponent<Rigidbody>().AddForce(bulletDirection*bulletSpeed,ForceMode.VelocityChange);
	}
	
	private Vector3 calculateBulletSpawnPosition(){
		Vector3 calculatedBulletSpawnPosition = transform.GetChild(0).position;
		return calculatedBulletSpawnPosition;
	}

	public void setInactive(){
		this.isActive = false;
	}

	public void setActive(){
		this.isActive = true;
	}
}
