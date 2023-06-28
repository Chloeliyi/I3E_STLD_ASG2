using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KeySystem
{
    public class Teleportion : MonoBehaviour
    {

        private bool Levelteleporter = false;
        [SerializeField] private KeyInventory _keyInventory = null;

        public void GoToLevel()
        {
            if(!Levelteleporter)
            {
                Debug.Log("Go To Level");
            }
        }
    }
}
