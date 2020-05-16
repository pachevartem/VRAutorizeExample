using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace VRGame
{
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(Animator))]
    public class ButtonFloor : MonoBehaviour
    {
        public bool isDrawGizmo;
        [FormerlySerializedAs("door")] public Barrier barrier;

        // public UnityEvent ButtonPress;

        [Range(1, 10)] public float DistanceActivate = 1;

        // trigger - pressed
        // trigger - off    
        private Animator _anim;
        private BoxCollider _collider;

        //костыль
        private bool k = false;

        private void Awake()
        {
            _anim = GetComponent<Animator>();
            _collider = GetComponent<BoxCollider>();
            _collider.center = new Vector3(0, 0, DistanceActivate / 2);
            _collider.size = Vector3.one * DistanceActivate;
            CloseButton(); //set default state;
        }

        public void SwitchButton()
        {
            if (k)
            {
                _anim.SetTrigger("off");
                k = !k;
                barrier.SwitchDoor();
            }
            else
            {
                _anim.SetTrigger("pressed");
                k = !k;
                barrier.SwitchDoor();
            }
        }

        public void CloseButton()
        {
            if (k)
            {
                _anim.SetTrigger("off");
                k = false;
            }
        }


        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
            {
                SwitchButton();
                // ButtonPress.Invoke();
            }
        }


        private void OnDrawGizmos()
        {
            if (isDrawGizmo)
            {
                if (barrier != null)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawLine(transform.position + Vector3.up * 1.2f,
                        barrier.gameObject.transform.position + Vector3.up * 2);
                }

                Gizmos.DrawWireCube(transform.position + Vector3.up * (DistanceActivate / 2),
                    Vector3.one * DistanceActivate);
            }
        }
    }
}