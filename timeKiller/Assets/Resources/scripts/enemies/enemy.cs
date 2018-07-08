using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class enemy : enemyBehaviours {

	public bool isWalking = false;
	public bool reachingTarget = false;

	private float rnd;
	private float cooldown = 0;

	public float distance;

	private Vector3 randomPos;
	private NavMeshAgent agent;
	private SphereCollider detector;
	private RaycastHit hit;

	void Start () {
		randomPos = transform.position;
		agent = GetComponent<NavMeshAgent>();
		path = new NavMeshPath();
		detector = GetComponent<SphereCollider>();
	}
	
	void Update () {

		if(target != null && !reachingTarget){
			Incoming();
		}
		if(target != null && reachingTarget){
			distance = agent.remainingDistance;
			agent.SetDestination(target.position);
			if(distance >  8f){
				target = null;
				reachingTarget = false;
			}
		}

		if( !isWalking){
			if(cooldown <= 0 ){
				rnd = Random.Range(-0f,1f);
				if( rnd > .5f){
					Crawl();
				}else{
					cooldown = Random.Range(1f, 4f);
				}
			}else if(cooldown > 0){
				cooldown -= Time.deltaTime;
			}
		}

		if(agent.velocity.magnitude == 0){
			isWalking = false;
		}

	}

	void Crawl(){
		float crawlRange = 1;
		isWalking = true;
		agent.speed = unitSpeed * .2f;
		randomPos = transform.position + new Vector3(Random.Range(-crawlRange,crawlRange), 0, Random.Range(-crawlRange,crawlRange));
		NavMesh.CalculatePath(transform.position, randomPos, NavMesh.AllAreas, path);
		agent.path = path;
	}

	void Incoming(){
		isWalking = true;
		reachingTarget = true;
		agent.speed = unitSpeed;
		agent.SetDestination(target.position);
	}

	private void OnTriggerEnter(Collider detection) {
		Debug.Log("dupa");
		string tg = "Player";
		FindTarget(detection.transform, transform.position, tg);
	}
	private void OnTriggerStay(Collider detection) {
		if(target == null){
			string tg = "Player";
			FindTarget(detection.transform, transform.position, tg);
		}
	}
}
