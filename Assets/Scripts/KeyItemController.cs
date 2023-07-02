using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to check if object has been picked up and references other scripts to do the specific action
/// </summary>
namespace KeySystem
{
    public class KeyItemController : MonoBehaviour
    {
        [SerializeField] private bool RedDoor = false;
        [SerializeField] private bool RedKey = false;

        [SerializeField] private bool RightDoor = false;

        [SerializeField] private bool BlueKey = false;
        [SerializeField] private bool Teleporter = false;
        [SerializeField] private bool SecondTeleporter = false;
        [SerializeField] private bool ThirdKey = false;

        [SerializeField] public bool Collectable_1 = false;
        [SerializeField] private bool Collectable_2 = false;
        [SerializeField] private bool Reactor = false;

        [SerializeField] private bool Enemy = false;
        [SerializeField] private bool Gun = false;

        //[SerializeField] private bool Exit = false;

        [SerializeField] private KeyInventory _keyInventory = null;

        private KeyDoorController doorObject;

        private KeyTeleportController teleportObject;

        private KeyCollectableController collectObject;

        private GunController gunDamage;

        private void Start()
        {
            if (RedDoor)
            {
                doorObject = GetComponent<KeyDoorController>();
            }

            if (RightDoor)
            {
                doorObject = GetComponent<KeyDoorController>();
            }

            if (Teleporter)
            {
                teleportObject = GetComponent<KeyTeleportController>();
            }

            if (SecondTeleporter)
            {
                teleportObject = GetComponent<KeyTeleportController>();
            }

            if (Reactor)
            {
                collectObject = GetComponent<KeyCollectableController>();
            }
            
            if (Enemy)
            {
                gunDamage = GetComponent<GunController>();
            }
        }

        public void ObjectInteraction()
        {
            if (RedDoor)
            {
                doorObject.PlayAnimation();
            }

            if (RightDoor)
            {
                doorObject.RightDoorLocked();
            }
            else if (Teleporter)
            {
                //Debug.Log("Teleport Is Open");
                teleportObject.ShowTeleportUI();
            }
            else if (SecondTeleporter)
            {
                teleportObject.ShowSecondTeleportUI();
            }

            else if (Reactor)
            {
                collectObject.ReactorLockSystem();
            }

            else if (Enemy)
            {
                gunDamage.DamageEnemy();
            }
            
            else if (RedKey)
            {
                _keyInventory.hasRedKey = true;
                Debug.Log("RedKey");
                gameObject.SetActive(false);

            }

            else if (BlueKey)
            {
                _keyInventory.hasBlueKey = true;
                Debug.Log("BlueKey");
                gameObject.SetActive(false);
            }

            else if (ThirdKey)
            {
                _keyInventory.hasThirdKey = true;
                Debug.Log("Third Key");
                gameObject.SetActive(false);
            }

            else if (Collectable_1)
            {
                _keyInventory.isCollectable_1 = true;
                gameObject.SetActive(false);

                Debug.Log("Colllectable_1" + _keyInventory.isCollectable_1);

            }
            else if (Collectable_2)
            {
                _keyInventory.isCollectable_2 = true;
                gameObject.SetActive(false);

                Debug.Log("Collectable_2" + _keyInventory.isCollectable_2);
            }

            else if (Gun)
            {
                _keyInventory.hasGun = true;
                Debug.Log("Gun is " + _keyInventory.hasGun);
                gameObject.SetActive(false);

            }
        }
    }
}

