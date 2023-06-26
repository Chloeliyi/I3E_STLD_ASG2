using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int Level1;
    public int Level2;

    public int Mainmenu;
    public GameObject Quitmenu;
    public int Deathmenu;
    public int Optionmenu;

    public int CactusDamage = 3;

    int HealthBar = 30;
    public TextMeshProUGUI displayHealth;

    public Slider SoundSlider;
    public TextMeshProUGUI Sound;

    public GameObject playerPrefab;
    private GameObject activePlayer;
    public static GameManager instance;

    public GameObject playerEnemy;
    private GameObject activeEnemy;

    public GameObject Floor;

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

    private void Start()
    {
        Quitmenu.gameObject.SetActive(false);
    }

    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + (transform.forward * maxInteractionDistance));
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, maxInteractionDistance))
        {
            if (instance != null && instance != this)
            {
                Destroy(playerPrefab);
                Destroy(playerEnemy);
            }
            else if (hitInfo.transform.tag == "exit")
            {
                Debug.Log("Exit");
                //GetComponent<Animator>().Play("FadeToBlack");
                SceneManager.LoadScene(Level2);
                DontDestroyOnLoad(playerPrefab);
                DontDestroyOnLoad(playerEnemy);
                SceneManager.activeSceneChanged += SpawnPlayerOnSceneLoad;

                instance = this;
            }

            else if (hitInfo.transform.tag == "entrance")
            {
                Debug.Log("Entrance");
                SceneManager.LoadScene(Level1);
                SceneManager.activeSceneChanged += SpawnPlayerOnSceneLoad;
            }
            
            else if (hitInfo.transform.tag == "collectible_1")
            {
                Debug.Log("First");
            }
            
            else if (hitInfo.transform.tag == "collectible_2")
            {
                Debug.Log("Second");

                /*if (Time.time > 20f)
                {
                    Debug.Log("Attacking");
                }*/

                if (activeEnemy == null)
                {
                    EnemySpawnSpot enemySpot = FindObjectOfType<EnemySpawnSpot>();
                    GameObject newEnemy = Instantiate(playerEnemy, enemySpot.transform.position, enemySpot.transform.rotation);
                    activeEnemy = newEnemy;
                }
            }

            else if (hitInfo.transform.tag == "collectible_3")
            {
                Debug.Log("Third");
            }

            else if (hitInfo.transform.tag == "floor")
            {
                Debug.Log("floor");
                //Floor.gameObject.SetActive(false);
            }

            /*else if ( hitInfo.collider.gameObject.tag == "Cactus")
            {
                if (HealthBar > 0)
                {
                    Debug.Log("Cactus");
                    Debug.Log(HealthBar);
                    HealthBar -= CactusDamage;
                    displayHealth.text = "Health Bar : " + HealthBar;
                }
                else if (HealthBar == 0)
                {
                    SceneManager.LoadScene(Deathmenu);
                }
            }

            else if (hitInfo.transform.tag == "Enemy")
            {
                if (HealthBar > 0)
                {
                    Debug.Log("Enemy");
                    Debug.Log(HealthBar);
                    HealthBar -= 3;
                    displayHealth.text = "Health Bar : " + HealthBar;
                }
                else if (HealthBar == 0)
                {
                    SceneManager.LoadScene(Deathmenu);
                }
            }*/

            /*else
            {
                DontDestroyOnLoad(playerPrefab);
                DontDestroyOnLoad(playerEnemy);
                instance = this; 
            }*/
        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Cactus")
        {
            if (HealthBar > 0)
            {
                Debug.Log("Cactus");
                Debug.Log(HealthBar);
                HealthBar -= CactusDamage;
                displayHealth.text = "Health Bar : " + HealthBar;
            }
            else if (HealthBar == 0)
            {
                SceneManager.LoadScene(Deathmenu);
            }
        }
    }
    public void OnStartButton()
    {
        if (instance != null && instance != this)
        {
            Destroy(playerPrefab);
            Destroy(playerEnemy);
        }
        else
        {
            SceneManager.LoadScene(Level1);

            DontDestroyOnLoad(playerPrefab);
            DontDestroyOnLoad(playerEnemy);
            SceneManager.activeSceneChanged += SpawnPlayerOnSceneLoad;

            instance = this;
        }

        /*SceneManager.LoadScene(Level1);
        DontDestroyOnLoad(Quitmenu);*/
    }

    private void SpawnPlayerOnSceneLoad(Scene currentScene, Scene nextScene)
    {
        if (activePlayer == null)
        {
            PlayerSpawnSpot playerSpot = FindObjectOfType<PlayerSpawnSpot>();
            GameObject newPlayer = Instantiate(playerPrefab, playerSpot.transform.position, playerSpot.transform.rotation);
            activePlayer = newPlayer;
            
        }
        else
        {
            return;
            /*PlayerSpawnSpot playerSpot = FindObjectOfType<PlayerSpawnSpot>();
            activePlayer.transform.position = playerSpot.transform.position;
            activePlayer.transform.rotation = playerSpot.transform.rotation;*/
        }
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

    /*public void OnFloorGiveAway()
    {
        if (Time.time > 3f)
        {

        }
    }*/
}
