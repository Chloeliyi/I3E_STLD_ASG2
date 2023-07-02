using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

namespace KeySystem
{
    public class GameManager : MonoBehaviour
    {

        /// <summary>
        ///  Gameobject of player
        /// </summary>
        public GameObject PlayerPrefab;
        /// <summary>
        /// This refernces the playermovement script
        /// </summary>
        private PlayerMovement activePlayer;
        /// <summary>
        /// Set static instance for gamemanger
        /// </summary>
        public static GameManager instance;
        /// <summary>
        /// Gameobject of the quit menu
        /// </summary>
        public GameObject QuitMenu;
        /// <summary>
        /// Gameobject of the main menu
        /// </summary>
        public GameObject MainMenuCanvas;
        /// <summary>
        /// Gameobject of the audio menu
        /// </summary>
        public GameObject AudioMenuCanvas;
        /// <summary>
        /// Gameobject of how to play menu
        /// </summary>
        public GameObject HowToCanvas;
        /// <summary>
        /// Gameobject of credits canvas;
        /// </summary>
        public GameObject CreditsCanvas;
        /// <summary>
        /// Gameobject of the on click button sound
        /// </summary>
        public AudioSource ButtonSound;

        /// <summary>
        /// Sets the different menus to hidden
        /// </summary>
        private void Start()
        {
            QuitMenu.SetActive(false);
            AudioMenuCanvas.SetActive(false);
            HowToCanvas.SetActive(false);
        }

        /// <summary>
        /// Spawns player on load
        /// </summary>
        /// <param name="prev"></param>
        /// <param name="next"></param>
        private void SpawnPlayerOnLoad(Scene prev, Scene next)
        {
            Debug.Log("Entering Scene is:" + next.buildIndex);

            PlayerSpawnSpot playerSpot = FindObjectOfType<PlayerSpawnSpot>();
            if (activePlayer == null)
            {
                GameObject player = Instantiate(PlayerPrefab, playerSpot.transform.position, playerSpot.transform.rotation);
                activePlayer = player.GetComponent<PlayerMovement>();
            }
            else
            {
                activePlayer.transform.position = playerSpot.transform.position;
                activePlayer.transform.rotation = playerSpot.transform.rotation;
            }
        }

        /// <summary>
        /// Checks the static instance
        /// </summary>
        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
                SceneManager.activeSceneChanged += SpawnPlayerOnLoad;

                instance = this;
            }
        }

        /// <summary>
        /// Click the start button and plays this function 
        /// </summary>
        public void OnStartButton()
        {
            Debug.Log(PlayerPrefab.name);

            ButtonSound.Play();
            SceneManager.LoadScene(1);
            MainMenuCanvas.gameObject.SetActive(false);

            if (instance != null && instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
                SceneManager.activeSceneChanged += SpawnPlayerOnLoad;

                instance = this;
            }
        }

        /// <summary>
        /// Click the audio button and to get audio menu
        /// </summary>
        public void OnAudioButton()
        {
            ButtonSound.Play();
            MainMenuCanvas.gameObject.SetActive(false);
            AudioMenuCanvas.SetActive(true);
        }

        /// <summary>
        /// Click the how to play button and to get how to play menu
        /// </summary>
        public void OnHowToButton()
        {
            ButtonSound.Play();
            MainMenuCanvas.gameObject.SetActive(false);
            HowToCanvas.SetActive(true);
        }

        /// <summary>
        /// Click the credits button and to get credits menu
        /// </summary>
        public void OnCreditsButton()
        {
            ButtonSound.Play();
            MainMenuCanvas.gameObject.SetActive(false);
            CreditsCanvas.SetActive(true);
        }

        /// <summary>
        /// Click the quit button and to get quit menu
        /// </summary>
        public void OnQuitButton()
        {
            QuitMenu.SetActive(true);
            ButtonSound.Play();
        }

        /// <summary>
        /// Click the yes button and to quit the game
        /// </summary>
        public void OnYesButton()
        {
            ButtonSound.Play();
            Application.Quit();
        }

        /// <summary>
        /// Click the no button and hides the quit menu
        /// </summary>
        public void OnNoButton()
        {
            QuitMenu.SetActive(false);
            ButtonSound.Play();
        }

        /// <summary>
        /// Click the return button and return to main menu
        /// </summary>
        public void OnReturnButton()
        {
            ButtonSound.Play();
            AudioMenuCanvas.SetActive(false);
            HowToCanvas.SetActive(false);
            MainMenuCanvas.gameObject.SetActive(true);
        }
    }
}


