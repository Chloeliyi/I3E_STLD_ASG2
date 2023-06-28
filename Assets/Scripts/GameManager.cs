using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace KeySystem
{
    public class GameManager : MonoBehaviour
    {
        public int Level1 = 3;
        public int Level2 = 4;
        public int Level3 = 5;

        public int Mainmenu = 2;
        public GameObject Quitmenu;
        public int Deathmenu = 0;
        public int Optionmenu = 1;

        //public GameObject Dialogue;
        public int CactusDamage = 3;

        int HealthBar = 30;
        public TextMeshProUGUI displayHealth;

        public Slider SoundSlider;
        public TextMeshProUGUI Sound;

        public GameObject playerPrefab;
        private GameObject activePlayer;
        public static GameManager instance;

        //public GameObject playerEnemy;
        //private GameObject activeEnemy;

        //[SerializeField] private KeyItemController Collectable_1;

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
            //Dialogue.gameObject.SetActive(false);
        }

        void Update()
        {
            Debug.DrawLine(transform.position, transform.position + (transform.forward * maxInteractionDistance));
            RaycastHit hitInfo;
            if (Physics.Raycast(transform.position, transform.forward, out hitInfo, maxInteractionDistance))
            {
                /*if (instance != null && instance != this)
                {
                    Destroy(playerPrefab);
                    Destroy(playerEnemy);
                }*/
                if (hitInfo.transform.tag == "exit")
                {
                    Debug.Log("Exit");

                    if (instance != null && instance != this)
                    {
                        Destroy(playerPrefab);
                    }

                    else
                    {
                        SceneManager.LoadScene(Level2);
                        DontDestroyOnLoad(playerPrefab);

                        SceneManager.activeSceneChanged += SpawnPlayerOnSceneLoad;

                        instance = this;
                    }
                    //GetComponent<Animator>().Play("FadeToBlack");
                    //SceneManager.LoadScene(Level2);


                    //DontDestroyOnLoad(playerPrefab);
                    //DontDestroyOnLoad(playerEnemy);
                    //SceneManager.activeSceneChanged += SpawnPlayerOnSceneLoad;

                    //instance = this;
                }

                else if (hitInfo.transform.tag == "entrance")
                {
                    Debug.Log("Entrance");
                    SceneManager.LoadScene(Level1);
                    SceneManager.activeSceneChanged += SpawnPlayerOnSceneLoad;

                    instance = this;
                }

                /*else if (hitInfo.transform.tag == "collectible_1")
                {
                    Debug.Log("First");

                    if (activeEnemy == null)
                    {
                        EnemySpawnSpot enemySpot = FindObjectOfType<EnemySpawnSpot>();
                        GameObject newEnemy = Instantiate(playerEnemy, enemySpot.transform.position, enemySpot.transform.rotation);
                        activeEnemy = newEnemy;
                    }
                }

                else if (hitInfo.transform.tag == "collectible_2")
                {
                    Debug.Log("Second");

                }

                else if (hitInfo.transform.tag == "collectible_3")
                {
                    Debug.Log("Third");
                }*/

                else if (hitInfo.transform.tag == "teleporter")
                {
                    Debug.Log("Go To Level2");
                    SceneManager.LoadScene(Level2);

                    //DontDestroyOnLoad(playerPrefab);
                    SceneManager.activeSceneChanged += SpawnPlayerOnSceneLoad;

                    instance = this;

                    //Collectable_1.Collectable_1 = true;
                }

                else if (hitInfo.transform.tag == "houseTeleporter")
                {
                    Debug.Log("Go To Level3");
                    SceneManager.LoadScene(Level3);

                    //DontDestroyOnLoad(playerPrefab);
                    SceneManager.activeSceneChanged += SpawnPlayerOnSceneLoad;

                    instance = this;
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
                    HealthBar -= CactusDamage;
                    Debug.Log(HealthBar);
                    displayHealth.text = "Health Bar : " + HealthBar;
                }
                else if (HealthBar == 0)
                {
                    SceneManager.LoadScene(Deathmenu);
                }
            }
        }

        public void Death()
        {
            SceneManager.LoadScene(Deathmenu);
        }
        public void OnStartButton()
        {
            if (instance != null && instance != this)
            {
                Destroy(playerPrefab);
                //Destroy(playerEnemy);
            }
            else
            {
                SceneManager.LoadScene(Level1);

                DontDestroyOnLoad(playerPrefab);
                //DontDestroyOnLoad(playerEnemy);
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

        /*public void SpawnEnemy()
        {
            if (activeEnemy == null)
            {
                EnemySpawnSpot enemySpot = FindObjectOfType<EnemySpawnSpot>();
                GameObject newEnemy = Instantiate(playerEnemy, enemySpot.transform.position, enemySpot.transform.rotation);
                activeEnemy = newEnemy;
            }
        }*/

        public void TeleportToLevelTwo()
        {
            /*SceneManager.LoadScene(Level2);
            DontDestroyOnLoad(playerPrefab);
            //DontDestroyOnLoad(playerEnemy);
            SceneManager.activeSceneChanged += SpawnPlayerOnSceneLoad;

            instance = this;*/
            Debug.Log("Go Back To Level 2");
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

        public void OnRestartButton()
        {

        }

        public void OnSoundSlider()
        {
            //Sound.GetComponent<TextMeshPro>().text = SoundSlider.value;

            SoundSlider.onValueChanged.AddListener((v) =>
            {
                Sound.text = v.ToString("0");
            });
        }
    }
}


