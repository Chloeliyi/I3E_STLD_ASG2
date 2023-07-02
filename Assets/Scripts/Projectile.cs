using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to destroy projectile if it hits ground or house
/// </summary>
public class Projectile : MonoBehaviour
{
    public void DestroyProjectiles()
    {
        if (gameObject.tag == "projectile")
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            Debug.Log("Ground collision");
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "house")
        {
            Debug.Log("House collision");
            Destroy(gameObject);
        }
        /*else if (collision.gameObject.tag == "test")
        {
            Debug.Log("Object collision");
            Destroy(gameObject);
        }*/
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
