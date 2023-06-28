using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyItemController : MonoBehaviour
    {
        [SerializeField] private bool RedDoor = false;
        [SerializeField] private bool RedKey = false;

        [SerializeField] private bool BlueKey = false;
        [SerializeField] private bool Teleporter = false;
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

        //private Teleportion Levelteleportion;

        private void Start()
        {
            if (RedDoor)
            {
                doorObject = GetComponent<KeyDoorController>();
            }

            if (Teleporter)
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

            //enemy = GetComponent<GameManager>();

            /*if (Exit)
            {
                Levelteleportion = GetComponent<Teleportion>();
            }*/
        }

        public void ObjectInteraction()
        {
            if (RedDoor)
            {
                doorObject.PlayAnimation();
            }

            else if (Teleporter)
            {
                //Debug.Log("Teleport Is Open");
                teleportObject.ShowTeleportUI();
            }

            else if (Reactor)
            {
                collectObject.ReactorLockSystem();
            }

            else if (Enemy)
            {
                gunDamage.DamageEnemy();
            }

            /*else if (Exit)
            {
                Levelteleportion.GoToLevel();
            }*/
            
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
                Debug.Log("Collectable_1");
                gameObject.SetActive(false);

                //enemy.SpawnEnemy();

            }
            else if (Collectable_2)
            {
                _keyInventory.isCollectable_2 = true;
                Debug.Log("Collectable_2");
                gameObject.SetActive(false);
            }

            else if (Gun)
            {
                _keyInventory.hasGun = true;
                Debug.Log("Gun");
                gameObject.SetActive(false);
            }
        }
    }
}

