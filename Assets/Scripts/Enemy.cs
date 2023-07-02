using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace KeySystem
{
    public class Enemy : MonoBehaviour
    {

        public NavMeshAgent agent;
        public Transform player;

        public LayerMask whatIsGround, whatIsPlayer;
        public GameObject projectile;

        public float Enemyhealth = 30;
        public float Playerattack = 3;

        //private PlayerMovement Playerhealth;

        /// <summary>
        /// Patroling
        /// </summary>
        public Vector3 walkPoint;
        bool walkPointSet;
        public float walkPointRange;

        /// <summary>
        /// Attacking
        /// </summary>
        public float timeBetweenAttacks;
        bool alreadyAttacked;

        /// <summary>
        /// States
        /// </summary>
        public float sightRange = 20, attackRange = 12;
        public bool playerInSightRange, playerInAttackRange;

        /// <summary>
        /// Get sound of projectile
        /// </summary>
        SoundManager soundManager;
        /// <summary>
        /// Awake function
        /// </summary>
        private void Awake()
        {
            //player = GameObject.Find("FirstPerson-AIO").transform;
            //player = GameObject.Find("FirstPerson-AIO(Clone)").transform;
            agent = GetComponent<NavMeshAgent>();
            soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManager>();
        }

        /// <summary>
        /// Update function
        /// </summary>
        private void Update()
        {
            player = GameObject.FindObjectOfType<PlayerMovement>().transform;
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

            if (!playerInSightRange && !playerInAttackRange) Patroling();
            if (playerInSightRange && !playerInAttackRange) ChasePlayer();
            if (playerInSightRange && playerInAttackRange) AttackPlayer();
        }

        /// <summary>
        /// Patroling function
        /// </summary>
        private void Patroling()
        {
            if (!walkPointSet) SearchWalkPoint();

            if (walkPointSet) agent.SetDestination(walkPoint);

            Vector3 distanceToWalkPoint = transform.position - walkPoint;

            //Walkpoint reached
            if (distanceToWalkPoint.magnitude < 1f) walkPointSet = false;
        }

        private void SearchWalkPoint()
        {
            float randomZ = Random.Range(-walkPointRange, walkPointRange);
            float randomX = Random.Range(-walkPointRange, walkPointRange);

            walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

            if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)) walkPointSet = true;

        }
        private void ChasePlayer()
        {
            agent.SetDestination(player.position);
        }

        private void AttackPlayer()
        {
            //Make sure enemy doesn't move

            agent.SetDestination(transform.position);
            transform.LookAt(player);
            
            /*if (Playerhealth.currentHealth > 0 )
            {
                if (!alreadyAttacked)
                {

                    //Attack code here
                    Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                    soundManager.PLaySFX(soundManager.Cannonsound);
                    rb.AddForce(transform.forward * 12f, ForceMode.Impulse);
                    rb.AddForce(transform.up * 3f, ForceMode.Impulse);

                    alreadyAttacked = true;
                    Invoke(nameof(ResetAttack), timeBetweenAttacks);
                }
            }
            else
            {
                alreadyAttacked = true;
            }*/
            if (!alreadyAttacked)
            {

                //Attack code here
                Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                soundManager.PLaySFX(soundManager.Cannonsound);
                rb.AddForce(transform.forward * 15f, ForceMode.Impulse);
                rb.AddForce(transform.up * 5f, ForceMode.Impulse);

                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }
        }

        private void ResetAttack()
        {
            alreadyAttacked = false;
        }

        /*public void TakeDamage(int damage)
        {
            Enemyhealth -= damage;

            if (Enemyhealth <= 0) Invoke(nameof(DestroyEnemy), .5f);
        }*/

        public void DestroyEnemy()
        {
            Destroy(gameObject);
        }

        /*public void Hurt()
        {
            Enemyhealth -= Playerattack;
            Debug.Log("Enemy health: " + Enemyhealth);

            if (Enemyhealth <= 0)
            {
                Destroy(gameObject);
            }
        }*/

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, sightRange);
        }

    }
}