using System;
using UnityEngine;

namespace VRGame
{
    public class Bullet: MonoBehaviour
    {
        private void Start()
        {
            Invoke("KickMe", 4);
        }

        void KickMe()
        {
            Destroy(gameObject);
        }
    }
}