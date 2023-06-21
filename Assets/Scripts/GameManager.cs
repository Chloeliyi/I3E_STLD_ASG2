using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    static Vector3 Playerpos;
    public int Level1;
    public int Level2;
    //public Transform newPos;
    public Transform Player;

    public int Mainmenu;
    public GameObject Quitmenu;
    public int Deathmenu;
    public int Optionmenu;

    public int HealthBar;

    public Slider SoundSlider;
    public TextMeshProUGUI Sound;

    private void OnCollisionEnter(Collision door)
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
    }

    private void Start()
    {
        Quitmenu.gameObject.SetActive(false);
    }
    public void OnStartButton()
    {
        SceneManager.LoadScene(Level1);
    }

    public void OnQuitButton()
    {
        //Application.Quit();
        Quitmenu.gameObject.SetActive(true);
    }

    public void OnYesButton()
    {
        Application.Quit();
    }

    public void OnNoButton()
    {
        Quitmenu.gameObject.SetActive(false);
    }

    public void OnReturnButton()
    {
        SceneManager.LoadScene(Mainmenu);
    }

    public void OnOptionButton()
    {
        SceneManager.LoadScene(Optionmenu);
    }

    public void OnSoundSlider()
    {
        //Sound.GetComponent<TextMeshPro>().text = SoundSlider.value;

        SoundSlider.onValueChanged.AddListener((v) =>
        {
            Sound.text = v.ToString("0");
        });
    }

    /*void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Enemy")
        {
            GetComponent<Animator>().Play("Death");
            this.enabled = false;
            HealthBar = HealthBar - 3;
            Debug.Log(HealthBar);
        }
    }*/

    public void OnDeath()
    {
        if(HealthBar == 0)
        {
            SceneManager.LoadScene(Deathmenu);
        }
    }
}
