using System;
using System.Collections.Generic;
using UnityEngine;


namespace VRGame
{
    public class ForceField : MonoBehaviour
    {
       public GameObject StopObj;

        public bool isActive = true;
        
        private void Update()
        {
            StopObj.SetActive(isActive);
        }
    }
}