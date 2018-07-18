using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehaviour : MonoBehaviour {

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
		if(other.gameObject.tag !=("Player"))
			Destroy(this.gameObject);
	}
}
