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


        //Patroling
        public Vector3 walkPoint;
        bool walkPointSet;
        public float walkPointRange;

        //Attacking
        public float timeBetweenAttacks;
        bool alreadyAttacked;

        //States
        public float sightRange, attackRange;
        public bool playerInSightRange, playerInAttackRange;
        private void Awake()
        {
            player = GameObject.Find("FirstPerson-AIO").transform;
            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

            if (!playerInSightRange && !playerInAttackRange) Patroling();
            if (playerInSightRange && !playerInAttackRange) ChasePlayer();
            if (playerInSightRange && playerInAttackRange) AttackPlayer();
        }

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

            if (!alreadyAttacked)
            {

                //Attack code here
                Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
                rb.AddForce(transform.up * 8f, ForceMode.Impulse);

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

        /*public Transform visionPoint;
        private PlayerMovement player;

        public GameObject PlayerEnemy;

        public Transform Player;

        // set the vision and movement speed of the enemy
        public float visionAngle = 30f;
        public float visionDistance = 10f;
        public float moveSpeed = 2f;
        public float chaseDistance = 3f;

        private Vector3? lastKnownPlayerPosition;

        // set health of enemy
        public float EnemyHealth = 5;
        public float PlayerAttack = 3;

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindAnyObjectByType<PlayerMovement>();
        }

        private void Awake()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Vector3 lookAt = Player.position;
            lookAt.y = transform.position.y;
            transform.LookAt(lookAt); // allows enemy to rotate and face player

            //Let the enemy move towards the player
            PlayerEnemy.transform.position = Vector3.MoveTowards(transform.position, Player.position, moveSpeed * Time.deltaTime);
        }

        void Look()
        {
            Vector3 deltaToPlayer = player.transform.position - visionPoint.position;
            Vector3 directionToPlayer = deltaToPlayer.normalized;

            float dot = Vector3.Dot(transform.forward, directionToPlayer);

            if (dot < 0)
            {
                return;
            }

            float distanceToPlayer = directionToPlayer.magnitude;

            if (distanceToPlayer > visionDistance)
            {
                return;
            }

            float angle = Vector3.Angle(transform.forward, directionToPlayer);

            if(angle >visionAngle)
            {
                return;
            }

            RaycastHit hitInfo;
            if (Physics.Raycast(transform.position, directionToPlayer, out hitInfo, visionDistance))
            {
                if (hitInfo.collider.gameObject == player.gameObject)
                {
                    lastKnownPlayerPosition = player.transform.position;
                }
            }
        }

        public void Hurt()
            // enemy is hurt when this function is called
        {
            EnemyHealth -= PlayerAttack;
            Debug.Log("Enemy Health : " + EnemyHealth);

            if (EnemyHealth <= 0)
            {
                Destroy(this.gameObject);
            }
        }*/

    }
}