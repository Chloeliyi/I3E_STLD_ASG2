using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class for raycasting to pick up keys, reactor parts and gun
/// </summary>
namespace KeySystem
{
    public class KeyRayCast : MonoBehaviour
    {
        [SerializeField] private int rayLength = 5;
        [SerializeField] private LayerMask layerMaskInteract;
        [SerializeField] private string excluseLayerName = null;

        private KeyItemController raycastedObject;
        [SerializeField] private KeyCode openDoorKey = KeyCode.Mouse0;

        [SerializeField] private Image crosshair = null;
        private bool isCrosshairActive;
        private bool doOnce;

        private string interactableTag = "InteractiveObject";

        private void Update()
        {
            RaycastHit hitInfo;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            int mask = 1 << LayerMask.NameToLayer(excluseLayerName) | layerMaskInteract.value;

            if (Physics.Raycast(transform.position, fwd, out hitInfo, rayLength, mask))
            {
                if(hitInfo.collider.CompareTag(interactableTag))
                {
                    if (!doOnce)
                    {
                        raycastedObject = hitInfo.collider.gameObject.GetComponent<KeyItemController>();
                        CrosshairChange(true);
                    }

                    isCrosshairActive = true;
                    doOnce = true;

                    if(Input.GetKeyDown(openDoorKey))
                    {
                        raycastedObject.ObjectInteraction();
                    }
                }
            }
            else
            {
                if (isCrosshairActive)
                {
                    CrosshairChange(false);
                    doOnce = false;
                }
            }
        }

        void CrosshairChange (bool on)
        {
            if (on && !doOnce)
            {
                crosshair.color = Color.red;
            }
            else
            {
                crosshair.color = Color.yellow;
                isCrosshairActive = false;
            }
        }
    }
}
