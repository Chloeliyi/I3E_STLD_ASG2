using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Key Collectable Controller. After finding the two pieces of the reactor, the reactor should unlock after clicking on it and game is won
/// </summary>
namespace KeySystem
{
    public class KeyCollectableController : MonoBehaviour
    {
        private bool reactorOpen = false;

        [SerializeField] private int timeToShowUI = 3;
        [SerializeField] private GameObject showReactorLockedUI = null;
        [SerializeField] private GameObject showReactorUnlockedUI = null;

        [SerializeField] private KeyInventory _keyInventory = null;

        [SerializeField] private GameObject WinMenu;

        //public static KeyCollectableController instance;
        public void Start()
        {
            //Debug.Log(_keyInventory);
            WinMenu.SetActive(false);
        }

        /*private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(_keyInventory);
            }
            else
            {
                Destroy(_keyInventory);
            }
        }*/
        public void ReactorLockSystem()
        {

            if (_keyInventory.isCollectable_1 && _keyInventory.isCollectable_2)
            {
                if (!reactorOpen)
                {
                    reactorOpen = true;
                    StartCoroutine(showReactorUnlocked());
                }
                else if (reactorOpen)
                {
                    reactorOpen = false;
                }
            }
            /*if(_keyInventory.isCollectable_1)
            {
                if(!reactorOpen)
                {
                    //reactorOpen = true;

                    //StartCoroutine(showReactorUnlocked());

                    reactorOpen = false;

                    Debug.Log("Key Is Collectable_1");
                }
                else if (reactorOpen)
                {
                    reactorOpen = false;
                }
            }
            if (_keyInventory.isCollectable_2)
            {
                if (!reactorOpen)
                {
                    //reactorOpen = true;

                    //StartCoroutine(showReactorUnlocked());

                    reactorOpen = false;

                    Debug.Log("Key Is Collectable_2");
                }
                else if (reactorOpen)
                {
                    reactorOpen = false;
                }
            }*/

            else
            {
                StartCoroutine(showReactorLocked());
            }
        }

        IEnumerator showReactorLocked()
        {
            showReactorLockedUI.SetActive(true);
            yield return new WaitForSeconds(timeToShowUI);
            showReactorLockedUI.SetActive(false);
        }

        IEnumerator showReactorUnlocked()
        {
            showReactorUnlockedUI.SetActive(false);
            yield return new WaitForSeconds(timeToShowUI);
            showReactorUnlockedUI.SetActive(true);
            Debug.Log("You Have Won!");

            StartCoroutine(YouHaveWon());
        }

        IEnumerator YouHaveWon()
        {
            WinMenu.SetActive(false);
            yield return new WaitForSeconds(5.0f);
            WinMenu.SetActive(true);  
        }

        public void OnReturnButton()
        {
            Debug.Log("You have returned to main menu!");
            SceneManager.LoadScene(0);
            /*DeathMenu.SetActive(false);
            Destroy(gameObject);
            currentHealth = 30;
            healthBar.SetHealth(currentHealth);
            MainMenuCanvas.MainMenuCanvas.SetActive(true);*/
        }
    }
}
