using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class GunController : MonoBehaviour
    {
        /// <summary>
        /// Get key inventory
        /// </summary>
        [SerializeField] private KeyInventory _keyInventory = null;
        
        /// <summary>
        /// Enemy health and player attack
        /// </summary>
        public float EnemyHealth = 30;
        public float PlayerAttack = 3;

        /// <summary>
        /// Sound for gun going off
        /// </summary>
        SoundManager soundManager;

        [SerializeField] private GameObject Key;
        
        /// <summary>
        /// Start function, key is hidden
        /// </summary>
        private void Start()
        {
            Key.SetActive(false);
        }

        /// <summary>
        /// Awake function, gun sound is found
        /// </summary>
        private void Awake()
        {
            soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManager>();
        }

        /// <summary>
        /// Check for key inventory has gun is true, and if so enemy health goes down
        /// </summary>
        public void DamageEnemy()
        {
            if(_keyInventory.hasGun)
            {
                Debug.Log("Enemy Is Attacked");

                soundManager.PLaySFX(soundManager.gunsound);

                EnemyHealth -= PlayerAttack;
                Debug.Log("Enemy health: " + EnemyHealth);
                if (EnemyHealth <= 0)
                {
                    soundManager.PLaySFX(soundManager.Deathsound);
                    Destroy(gameObject);
                    Key.SetActive(true);
                }
            }
        }
    }
}
