// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.AI;


// public class enemyMovement : enemyBehaviours {

// 	public NavMeshAgent agent;
// 	public bool isMoving;
// 	private float crawlCooldown;
// 	// Use this for initialization
// 	void Start () {
// 		agent = GetComponent<NavMeshAgent>();
// 		path = new NavMeshPath();
// 		destination = transform.position;
// 		agent.stoppingDistance = .1f;
// 	}
	
// 	// Update is called once per frame
// 	void Update () {

// 		if(agent.velocity.magnitude < .1f){
// 			isMoving = false;
// 		}

// 		if( !isMoving){
// 			if(crawlCooldown <= 0 ){
// 				if( Random.Range(-0f,1f) > .1f){
// 					agent.SetDestination(Crawl(transform.position));
// 					isMoving = true;	
// 				}else{
// 					crawlCooldown = CooldownCounter(3f);
// 				}
// 			}else if(crawlCooldown > 0){
// 				crawlCooldown -= Time.deltaTime;
// 			}
// 		}
		
// 	}

// 	private IEnumerator WaitAfterCrawl(float t){
// 		yield return new WaitForSeconds(t);
// 		if(!isMoving)
// 			agent.SetDestination(Crawl(transform.position));
// 		isMoving = true;
// 	}
	
// }
