using System;
using UnityEngine;
using VRGame;
using VRTK;

namespace VR_int
{
    public class Vr_fire: MonoBehaviour
    {
        public VRTK_InteractableObject linkedObject;
        private Gun gun;
            
        private void OnEnable()
        {
            if (linkedObject==null)
            {
                linkedObject = GetComponent<VRTK_InteractableObject>();
            }

            if (gun==null)
            {
                gun = GetComponent<Gun>();
            }
                
            Debug.Log(linkedObject);
            linkedObject.InteractableObjectUsed += (sender, args) => { gun.Fire(); };
        }

        private void OnDisable()
        {
            linkedObject.InteractableObjectUsed -= (sender, args) => { gun.Fire(); };
        }
    }
}