using System;
using UnityEngine;

namespace VRGame
{
    [RequireComponent(typeof(BoxCollider))]
    public class Key: MonoBehaviour
    {
        private BoxCollider _collider;

        public Action OnKey = () => { };
        
        private void Awake()
        {
            _collider = GetComponent<BoxCollider>();
            _collider.isTrigger = true;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                OnKey();
                
                gameObject.SetActive(false);
            }
        }
    }
}