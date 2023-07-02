using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor.Audio;

/// <summary>
/// Controls player movement
/// </summary>
namespace KeySystem
{
    public class PlayerMovement : MonoBehaviour
    {
        /// <summary>
        /// Player max health
        /// </summary>
        public int maxHealth = 30;
        /// <summary>
        /// Player current health
        /// </summary>
        public int currentHealth;
        /// <summary>
        /// Reference healthbar script
        /// </summary>
        public HealthBar healthBar;
        /// <summary>
        /// TextMesh of player health
        /// </summary>
        public TextMeshProUGUI HealthDisplay;
        /// <summary>
        /// Damage by cactus
        /// </summary>
        public int CactusDamage = 3;
        /// <summary>
        /// Current scene
        /// </summary>
        private int CurrentScene;
        /// <summary>
        /// Death Menu
        /// </summary>
        [SerializeField] private GameObject DeathMenu;

        private GameManager MainMenuCanvas;

        /// <summary>
        /// Sound when player walks around
        /// </summary>
        public AudioSource Walkingsound;
        /// <summary>
        /// Transition of the fade animation
        /// </summary>
        public Animator transition;
        /// <summary>
        /// Animation transition time
        /// </summary>
        public float transitionTime = 1f;

        bool HaveNumber(out int i)
        {
            if (true)
            {
                i = 1;
                return true;
            }
        }

        float maxInteractionDistance = 3f;

        /// <summary>
        /// Start function, set the health and hide death menu
        /// </summary>
        private void Start()
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
            DeathMenu.SetActive(false);
        }
        /// <summary>
        /// Awake function, don't destroy game object
        /// </summary>
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            Debug.Log("Current Health is " + currentHealth);
        }
        /// <summary>
        /// Update function that checks to teleport to other scenes and plays transitions
        /// </summary>
        void Update()
        {
            if (currentHealth > 0)
            {
                CurrentScene = SceneManager.GetActiveScene().buildIndex;

                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
                {
                    Walkingsound.enabled = true;
                    Debug.Log("Walking");
                }
                else
                {
                    Walkingsound.enabled = false;
                    Debug.Log("Not Walking");
                }
                Debug.DrawLine(transform.position, transform.position + (transform.forward * maxInteractionDistance));
                RaycastHit hitInfo;
                if (Physics.Raycast(transform.position, transform.forward, out hitInfo, maxInteractionDistance))
                {
                    if (hitInfo.transform.tag == "exit")
                    {
                        Debug.Log("Exit");
                        Debug.Log("Raycast Hit: " + hitInfo.transform.gameObject.name);

                        //CurrentScene = SceneManager.GetActiveScene().buildIndex;

                        StartCoroutine(LoadLevel(CurrentScene + 1));
                        SceneManager.LoadScene(CurrentScene + 1);
                    }

                    else if (hitInfo.transform.tag == "entrance")
                    {
                        Debug.Log("Entrance");
                        CurrentScene = SceneManager.GetActiveScene().buildIndex;
                        StartCoroutine(LoadLevel(CurrentScene - 1));
                        SceneManager.LoadScene(CurrentScene - 1);
                    }

                    else if (hitInfo.transform.tag == "houseTeleporter")
                    {
                        Debug.Log("Go To Level3");
                        CurrentScene = SceneManager.GetActiveScene().buildIndex;
                        StartCoroutine(LoadLevel(CurrentScene + 1));
                        SceneManager.LoadScene(CurrentScene + 1);
                    }

                    else if (hitInfo.transform.tag == "teleporter")
                    {
                        Debug.Log("Go To Level2");
                        CurrentScene = SceneManager.GetActiveScene().buildIndex;
                        StartCoroutine(LoadLevel(CurrentScene - 1));
                        SceneManager.LoadScene(CurrentScene - 1);

                    }
                }

                IEnumerator LoadLevel(int levelIndex)
                {
                    transition.SetTrigger("Start");
                    yield return new WaitForSeconds(transitionTime);
                    SceneManager.LoadScene(levelIndex);
                }
            }
            else
            {
                //Death menu is unhidden
                DeathMenu.gameObject.SetActive(true);
                CurrentScene = SceneManager.GetActiveScene().buildIndex;
                Debug.Log("You Died In Scene :" + CurrentScene);
            }

        }
        /// <summary>
        /// Oncollision function, if player collides with projectile or cactus, player loses health
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "projectile")
            {
                Debug.Log("Hit");
                currentHealth -= 3;
                Debug.Log("Current Health is : " + currentHealth);
                collision.gameObject.GetComponent<Projectile>().DestroyProjectiles();
                healthBar.SetHealth(currentHealth);
                HealthDisplay.text = currentHealth.ToString();
                if (currentHealth == 0)
                {
                    Debug.Log("Dead");
                    
                }
            }
            else if (collision.gameObject.tag == "Cactus")
            {
                Debug.Log("Cactus");
                currentHealth -= CactusDamage;
                Debug.Log("Current Health is : " + currentHealth);
                healthBar.SetHealth(currentHealth);
                HealthDisplay.text = currentHealth.ToString();
                if (currentHealth == 0)
                {
                    Debug.Log("Dead");

                }

            }
        }

        /// <summary>
        /// Function to restart the level if player dies
        /// </summary>
        public void OnRestartArea()
        {
            Debug.Log("You have restarted the area!");
            CurrentScene = SceneManager.GetActiveScene().buildIndex;
            Debug.Log(CurrentScene);
            SceneManager.LoadScene(CurrentScene);
            DeathMenu.SetActive(false);
            currentHealth = 30;
            healthBar.SetHealth(currentHealth);
        }

        /// <summary>
        /// function to return to main menu if player dies
        /// </summary>
        public void OnReturnButton()
        {
            Debug.Log("You have returned to main menu!");
            SceneManager.LoadScene(0);
            DeathMenu.SetActive(false);
            Destroy(gameObject);
            MainMenuCanvas.MainMenuCanvas.SetActive(true);
            currentHealth = 30;
            healthBar.SetHealth(currentHealth);
        }
    }
}

