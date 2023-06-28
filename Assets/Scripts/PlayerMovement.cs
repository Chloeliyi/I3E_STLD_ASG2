using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace KeySystem
{
    public class PlayerMovement : MonoBehaviour
    {

        public float Playerhealth = 30;

        private  int DeathMenu = 0;

        //private Enemy destroyEnemy;
        //public GameObject Enemy;

        private void Start()
        {
            //destroyEnemy.GetComponent<Enemy>();
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "projectile")
            {
                Debug.Log("Hit");
                Playerhealth -= 3;
                Debug.Log(Playerhealth);
                collision.gameObject.GetComponent<Projectile>().DestroyProjectiles();

                if (Playerhealth == 0)
                {
                    Debug.Log("Dead");
                    //Destroy(Enemy);
                    SceneManager.LoadScene(DeathMenu);
                }
            }
        }
        /*public GameObject Playerenemy;

        private void Start()
        {
            Playerenemy.SetActive(false);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "test")
            {
                Playerenemy.SetActive(true);
            }
        }*/


        /*public float PlayerHealth = 30;
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
                        //Debug.Log("Dead");
                        SceneManager.LoadScene(0);
                    }
                }
            }
        }*/
    }
}

