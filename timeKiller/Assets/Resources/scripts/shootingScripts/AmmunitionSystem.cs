using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionSystem : MonoBehaviour {

	
	public int magazineCapacity;
	public int currentlyLoaded;
		
	public int currentlyCarried;
	public float reloadTime;

	
	public bool isMagazineEmpty(){
		return currentlyLoaded == 0;
	}

	public bool isMagazineFull(){
		return currentlyLoaded == magazineCapacity;
	}

	public bool isCarryingAmmo(){
		return currentlyCarried > 0;
	}


	public void reload(){
		if(isCarryingAmmo()){
			Invoke("fillMagazine",reloadTime);
			GetComponent<WeaponScript>().setInactive();	
		}
	}

	private void fillMagazine(){
		
		if (magazineCapacity < (currentlyLoaded+currentlyCarried) ){
			currentlyCarried -= magazineCapacity;
			currentlyCarried += currentlyLoaded;
			currentlyLoaded = magazineCapacity;
		}else{
			currentlyLoaded += currentlyCarried;
			currentlyCarried = 0;
			}
		GetComponent<WeaponScript>().setActive();	

	}
	
}
