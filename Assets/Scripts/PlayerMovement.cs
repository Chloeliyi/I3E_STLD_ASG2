using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float PlayerHealth = 30;
    public float maxDistance = 10f;

    public GameObject PlayerEnemy;
    public float EnemyAttack = 3;
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "test")
        {
            Debug.Log("Test");
        }
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, maxDistance))
        {
            if (hitInfo.collider.gameObject == PlayerEnemy.gameObject)
            {
                if (PlayerHealth > 0)
                {
                    Debug.Log("Current Health :" + PlayerHealth);
                    PlayerHealth -= EnemyAttack;
                    Debug.Log("New Health : " + PlayerHealth);
                }
                else if (PlayerHealth == 0)
                {
                    Debug.Log("Dead");
                }
            }
        }
    }
}
