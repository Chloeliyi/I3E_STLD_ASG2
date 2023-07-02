using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to control the teleporters
/// </summary>
namespace KeySystem
{
    public class KeyTeleportController : MonoBehaviour
    {
        private bool teleporterOpen = false;

        [SerializeField] private int timeToShowUI = 1;
        [SerializeField] private GameObject showTeleportInputLockedUI = null;
        [SerializeField] private GameObject showTeleportInputUnlockedUI = null;

        [SerializeField] private GameObject showTeleporterLockedUI = null;
        [SerializeField] private GameObject showTeleporterUnlockedUI = null;

        [SerializeField] private GameObject Teleporter = null;

        [SerializeField] private GameObject SecondTeleporter = null;

        [SerializeField] private KeyInventory _keyInventory = null;

        public void ShowTeleportUI()
        {
            if(_keyInventory.hasBlueKey)
            {
                if (!teleporterOpen)
                {
                    teleporterOpen = true;

                    StartCoroutine(showTeleportUnLocked());
                }
                
                else if (teleporterOpen)
                {
                    teleporterOpen = false;
                }
            }
            /*else if(_keyInventory.hasThirdKey)
            {
                if (!teleporterOpen)
                {
                    teleporterOpen = true;

                    StartCoroutine(showSecondTeleportUnLocked());
                }

                else if (teleporterOpen)
                {
                    teleporterOpen = false;
                }
            }*/
            else
            {
                StartCoroutine(showTeleportLocked());
                //StartCoroutine(showSecondTeleportLocked());
            }
        }

        public void ShowSecondTeleportUI()
        {
            if(_keyInventory.hasThirdKey)
            {
                if (!teleporterOpen)
                {
                    teleporterOpen = true;

                    StartCoroutine(showSecondTeleportUnLocked());
                }

                else if (teleporterOpen)
                {
                    teleporterOpen = false;
                }
            }
            else
            {
                StartCoroutine(showSecondTeleportLocked());
            }
        }

        IEnumerator showTeleportLocked()
        {
            showTeleporterLockedUI.SetActive(true);
            showTeleportInputLockedUI.SetActive(true);
            yield return new WaitForSeconds(timeToShowUI);
            showTeleporterLockedUI.SetActive(false);
            showTeleportInputLockedUI.SetActive(false);
            Teleporter.SetActive(false);
            //SecondTeleporter.SetActive(false);
        }

        IEnumerator showSecondTeleportLocked()
        {
            showTeleporterLockedUI.SetActive(true);
            showTeleportInputLockedUI.SetActive(true);
            yield return new WaitForSeconds(timeToShowUI);
            showTeleporterLockedUI.SetActive(false);
            showTeleportInputLockedUI.SetActive(false);
            SecondTeleporter.SetActive(false);
        }

        IEnumerator showTeleportUnLocked()
        {
            showTeleporterUnlockedUI.SetActive(false);
            showTeleportInputUnlockedUI.SetActive(false);
            yield return new WaitForSeconds(timeToShowUI);
            showTeleporterUnlockedUI.SetActive(true);
            showTeleportInputUnlockedUI.SetActive(true);
            Teleporter.SetActive(true);
            //SecondTeleporter.SetActive(true);
        }

        IEnumerator showSecondTeleportUnLocked()
        {
            showTeleporterUnlockedUI.SetActive(false);
            showTeleportInputUnlockedUI.SetActive(false);
            yield return new WaitForSeconds(timeToShowUI);
            showTeleporterUnlockedUI.SetActive(true);
            showTeleportInputUnlockedUI.SetActive(true);
            SecondTeleporter.SetActive(true);
        }
    }
}
