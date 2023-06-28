using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyCollectableController : MonoBehaviour
    {
        private bool reactorOpen = false;

        [SerializeField] private int timeToShowUI = 1;
        [SerializeField] private GameObject showReactorLockedUI = null;
        [SerializeField] private GameObject showReactorUnlockedUI = null;

        [SerializeField] private KeyInventory _keyInventory = null;

        public void ReactorLockSystem()
        {
            if(_keyInventory.isCollectable_1)
            {
                if(!reactorOpen)
                {
                    //reactorOpen = true;

                    //StartCoroutine(showReactorUnlocked());

                    reactorOpen = false;

                    Debug.Log(" Key Is Collectable_1");
                    //Debug.Log(_keyInventory);
                }
                else if (reactorOpen)
                {
                    reactorOpen = false;
                }
            }

            else if (_keyInventory.isCollectable_1 && _keyInventory.isCollectable_2)
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
        }
    }
}
