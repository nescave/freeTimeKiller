using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour {

	private int activeWeapon = 0;

	void start(){
		switchWeapon();
	}
	void Update () {
		if (Input.GetButtonDown("PrimaryWeapon")){
			activeWeapon = 1;
			switchWeapon();
		}else if(Input.GetButtonDown("SecondaryWeapon")){
			activeWeapon = 0;
			switchWeapon();
		}

	}

	private void switchWeapon(){
		int i = 0;
		foreach(Transform weapon in transform){
			if (i == activeWeapon){
				weapon.gameObject.SetActive(true);
			}else{
				weapon.gameObject.SetActive(false);
			}
			i++;
		}
	}
}
