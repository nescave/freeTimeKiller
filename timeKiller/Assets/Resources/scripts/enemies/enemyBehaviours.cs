using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class enemyBehaviours : MonoBehaviour {

	[Header("UnitProperties")]
	public float unitSpeed =1f;
	public float crawlRange =1f;

	[Header("Attack Properties")]
	public float attackRange;
	public float attackSpeed;

	[Header("AI")]
	public Transform target;
	[HideInInspector] public NavMeshPath path;
	[HideInInspector] public Vector3 destination;

	void Start () {
		
	}

	void Attack (Transform player){

	}

	public Transform FindTarget (Transform detected, Vector3 startPos, string tag){
		if(detected.gameObject.CompareTag(tag)){
			Vector3 direction = detected.transform.position - startPos;
			Ray ray = new Ray(startPos,direction);
			RaycastHit hit;
			Physics.Raycast(ray, out hit, 8f);
			Debug.DrawRay(startPos, direction, Color.red, .5f);
			if(detected.transform == hit.transform){
				target = detected.transform;
			}
		}
		return target; 
	}
	// public Vector3 Crawl (Vector3 startPos){
	// 	NavMeshHit hit;

	// 	if(true){
	// 		destination = startPos + new Vector3(Random.Range(-crawlRange,crawlRange), 0, Random.Range(-crawlRange,crawlRange));
	// 		if(NavMesh.SamplePosition(startPos, out hit, .1f, NavMesh.AllAreas)){
	// 			NavMesh.FindClosestEdge(startPos, out hit, NavMesh.AllAreas);
	// 			return hit.position;
	// 		}else{
	// 			return destination;
	// 		}
	// 	}
		 
	// }

	public float CooldownCounter(float time){

		time += Random.Range(time -1f, time +1f);

		return time;
	}

	private bool IsOnMove (Vector3 startLoc, Vector3 endLoc){

		bool isMoving;
		if((startLoc - endLoc).magnitude > .1f){
			Debug.Log("IS MOVING");
			isMoving = true;
		}else {
			isMoving = false;
		}
		return isMoving;

	}
}
