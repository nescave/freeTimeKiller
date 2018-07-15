using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float hitPoints;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void getHit(float damage){
		this.hitPoints -= damage;
		if (hitPoints <=0){
			Destroy(this.gameObject);
		}
	}
}
