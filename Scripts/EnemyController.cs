using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

	public float lookRadius = 10f;
    public GameObject player;
    public bool touchedPlayer = false;

	Transform target;
	NavMeshAgent agent;
	
	public Transform[] destPoints;
	private int theDestPoint = 0;


    public float restartDelay = 3f;
    float restartTimer;
    public Text GameIsOver;




    void Start () {
		target = PlayerManager.instance.player.transform;
		agent = GetComponent<NavMeshAgent>();
		GotoNextPoint();
	}

	void GotoNextPoint() {
            // Returns if no points have been set up
            if (destPoints.Length == 0)
                return;

            // Set the agent to go to the currently selected destination.
            agent.destination = destPoints[theDestPoint].position;

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            theDestPoint = (theDestPoint + 1) % destPoints.Length;
        }
	

	void Update () {
		// Choose the next destination point when the agent gets
        // close to the current one.
		if (!agent.pathPending && agent.remainingDistance < 0.5f)
		{
			GotoNextPoint();
		}
               
				
		float distanceToPlayer = Vector3.Distance(target.position, transform.position);

		if (distanceToPlayer <= lookRadius)
		{
			agent.SetDestination(target.position);

            if(touchedPlayer)
            {
                GameIsOver.text = "GAME OVER";
                restartTimer += Time.deltaTime;
                
                if(restartTimer >= restartDelay)
                {
                    Application.LoadLevel(Application.loadedLevel);
                }

                Debug.Log("game over");
            }
		}
        
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            touchedPlayer = true;
        }
    }



    /*void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }*/


    void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookRadius);
	}
}
