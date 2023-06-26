using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemy : MonoBehaviour
{
    public Transform visionPoint;
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

    /*public void Hurt()
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