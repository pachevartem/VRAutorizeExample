using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRGame
{
    [RequireComponent(typeof(Animator))]
    public class Door : MonoBehaviour
    {
        // trigger - isOpen
        // trigger -     
        private Animator _anim;

        //костыль
        private bool k = false;

        private void Awake()
        {
            _anim = GetComponent<Animator>();
            CloseDoor(); //set default state;
        }

        public void SwitchDoor()
        {
            if (k)
            {
                _anim.SetTrigger("isClose");
                k = !k;
            }
            else
            {
                _anim.SetTrigger("isOpen");
                k = !k;
            }
        }

        public void CloseDoor()
        {
            if (k)
            {
                _anim.SetTrigger("isClose");
                k = false;
            }
        }
    }
}