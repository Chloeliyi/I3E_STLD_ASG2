using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to check key inventory
/// </summary>
namespace KeySystem
{
    public class KeyInventory : MonoBehaviour
    {
        public bool hasRedKey = false;
        public bool hasBlueKey = false;
        public bool hasThirdKey = false;

        public bool isCollectable_1 = false;
        public bool isCollectable_2 = false;

        public bool hasGun = false;

        public void Start()
        {
        }
    }

}