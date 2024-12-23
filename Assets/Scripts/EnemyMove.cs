using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{

    public float moveSpeed, distanceToStop;
    // public Rigidbody theRigidbody;

    private Vector3 target;
    public NavMeshAgent agent;

    public GameObject bullet;
    public Transform firePoint;
    public float fireRate, waitBetweenShots = 2f, timeToShoot = 1f;
    private float fireCount, shotwaitCounter, shootTimeCounter;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
       shootTimeCounter = timeToShoot;
       shotwaitCounter = waitBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        target = PlayerMove.instance.transform.position;
        //target.y = transform.position.y;

        agent.destination = target;

       // transform.LookAt(target);

        //theRigidbody.velocity = transform.forward * moveSpeed;

        if(Vector3.Distance(transform.position, target) > distanceToStop){
            
            shootTimeCounter = timeToShoot;
            shotwaitCounter = waitBetweenShots;

            agent.destination = target;
            animator.SetBool("isMoving",true);
        }
        else{
            agent.destination = transform.position;
            animator.SetTrigger("fire");
        }

        if(shotwaitCounter > 0)
        {
            shotwaitCounter -= Time.deltaTime;
            if(shotwaitCounter <= 0)
            {
                shootTimeCounter = timeToShoot;
            }
        }
        else{
            shootTimeCounter -= Time.deltaTime;
            if(shootTimeCounter > 0)
            {
              fireCount -= Time.deltaTime;  
        
        if(fireCount <= 0)
        {
            fireCount = fireRate;

            firePoint.LookAt(PlayerMove.instance.transform.position + new Vector3(0f, 1.6f, 0f));

            Vector3 targetDirection = PlayerMove.instance.transform.position - transform.position;
            float angle = Vector3.SignedAngle(targetDirection, transform.forward, Vector3.up);

            if(Mathf.Abs(angle) < 30f)
            {
                Instantiate(bullet, firePoint.position, firePoint.rotation);

            } else{
                transform.LookAt(PlayerMove.instance.transform.position);
                shotwaitCounter = waitBetweenShots;
                
            }
        }
            }

            else {
                shotwaitCounter = waitBetweenShots;
            }

//             if(agent.remainingDistance < 0.3f)
//             {
//                 animator.SetBool("isMoving", false);
//             }
//             else{
//                 animator.SetBool("isMoving", true);
//             }

    
        }
    }
}
