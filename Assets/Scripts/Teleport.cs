using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{

    static Vector3 Playerpos;
    public int Level1;
    public int Level2;
    //public Transform newPos;
    public Transform Player;

    private void OnCollisionEnter(Collision door)
    {
        if(door.gameObject.tag == "exit")

            //Playerpos = newPos.position;

        {
            Debug.Log("Exit");
            SceneManager.LoadScene(Level2);
            //Player.position = newPos.position;
            Debug.Log(Player.position);
            Playerpos = Player.position;
        }

        else if(door.gameObject.tag == "entrance")
        {
            Debug.Log("Entrance");
            SceneManager.LoadScene(Level1);
            //Player.position = Playerpos;
        }
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
