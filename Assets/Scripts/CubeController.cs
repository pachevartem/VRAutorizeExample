using System;
using UnityEngine;

namespace VRGame
{
    public class CubeController: MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("OnTriggerEnter");
            if (other.gameObject.name == "ThirdPersonController") //TODO: change
            {
                GameManager.HP -= 20;
                Debug.LogWarning("DAMAGE");
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            Debug.Log(other.gameObject.name);
        }

        private void OnCollisionExit(Collision other)
        {
            Debug.Log(other.gameObject.name);
        }
    }
}