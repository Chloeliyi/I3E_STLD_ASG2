using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{

    public int HealthBar;

    /*private void OnCollisionEnter(Collision door)
    {
        if(door.gameObject.tag == "Enemy")

        {
            if (HealthBar > 0)
            {
                Debug.Log("Enemy");
                Debug.Log("Current Health" + HealthBar);
                HealthBar = HealthBar - 3;
                Debug.Log("New Health" + HealthBar);
            }

            else if (HealthBar == 0)
            {
                Debug.Log("Dead");
            }
        }
    }*/

    /*private void OnCollisionEnter(Collision door)
    {
        if (door.gameObject.tag == "exit")

        //Playerpos = newPos.position;

        {
            Debug.Log("Exit");
            SceneManager.LoadScene(Level2);
            //Player.position = newPos.position;
            Debug.Log(Player.position);
            Playerpos = Player.position;
        }

        else if (door.gameObject.tag == "entrance")
        {
            Debug.Log("Entrance");
            SceneManager.LoadScene(Level1);
            //Player.position = Playerpos;
        }
    }*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    bool HaveNumber(out int i)
    {
        if (true)
        {
            i = 1;
            return true;
        }
    }

    float maxInteractionDistance = 3f;

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + (transform.forward * maxInteractionDistance));
        RaycastHit hitInfo;
        if(Physics.Raycast(transform.position, transform.forward, out hitInfo, maxInteractionDistance))
        {
            if(hitInfo.transform.tag == "Enemy")
            {
                if (HealthBar > 0)
                {
                    Debug.Log("Enemy");
                    Debug.Log("Current Health" + HealthBar);
                    HealthBar = HealthBar - 3;
                    Debug.Log("New Health" + HealthBar);
                }

                else if (HealthBar == 0)
                {
                    Debug.Log("Dead");
                }
            }
        }
    }
}
