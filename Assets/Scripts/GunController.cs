using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace KeySystem
{
    public class GunController : MonoBehaviour
    {

        [SerializeField] private KeyInventory _keyInventory = null;
        //public GameObject Enemy;
        public float EnemyHealth = 30;
        public float PlayerAttack = 3;

        public void DamageEnemy()
        {
            if(_keyInventory.hasGun)
            {
                Debug.Log("Enemy Is Attacked");

                EnemyHealth -= PlayerAttack;
                Debug.Log("Enemy health: " + EnemyHealth);

                if (EnemyHealth <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
