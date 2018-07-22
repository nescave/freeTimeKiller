using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehaviour : MonoBehaviour {

	public float bulletDamage = 1f;
	private int lifetimeTimer;
	void Start () {
		Invoke("DeleteBullet",6f);
	}

	private void DeleteBullet(){
		Destroy(gameObject);
	}
	
	void Update (){

	}
	

	
	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag ==("Enemy")){
			other.gameObject.GetComponent<Health>().getHit(bulletDamage);
		}
			Destroy(this.gameObject);
	}
}
