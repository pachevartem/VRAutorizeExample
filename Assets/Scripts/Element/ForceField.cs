using System;
using System.Collections.Generic;
using UnityEngine;


namespace VRGame
{
    public class ForceField : MonoBehaviour
    {
        GameObject StopObj; //TODO: Запечатать в префабе

        bool isActive = true;

        private void Awake()
        {
            StopObj = transform.GetChild(2).gameObject;
        }


        public void SetActive(bool isActive)
        {
            this.isActive = isActive;
        }

        private void Update()
        {
            StopObj.SetActive(isActive);
        }
    }
}