using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        [SerializeField] private KeyInventory _keyInventory = null;

        private GameManager Level2Teleport;

        public void ShowTeleportUI()
        {
            if(_keyInventory.hasBlueKey)
            {
                if (!teleporterOpen)
                {
                    teleporterOpen = true;

                    StartCoroutine(showTeleportUnLocked());

                    Level2Teleport.TeleportToLevelTwo();
                }
                
                else if (teleporterOpen)
                {
                    teleporterOpen = false;
                }
            }
            else if(_keyInventory.hasThirdKey)
            {
                if (!teleporterOpen)
                {
                    teleporterOpen = true;

                    StartCoroutine(showTeleportUnLocked());

                    //Level2Teleport.TeleportToLevelTwo();
                }

                else if (teleporterOpen)
                {
                    teleporterOpen = false;
                }
            }
            else
            {
                StartCoroutine(showTeleportLocked());
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
        }

        IEnumerator showTeleportUnLocked()
        {
            showTeleporterUnlockedUI.SetActive(false);
            showTeleportInputUnlockedUI.SetActive(false);
            yield return new WaitForSeconds(timeToShowUI);
            showTeleporterUnlockedUI.SetActive(true);
            showTeleportInputUnlockedUI.SetActive(true);
            Teleporter.SetActive(true);
        }
    }
}
