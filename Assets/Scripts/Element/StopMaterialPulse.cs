using System;
using UnityEngine;

namespace VRGame
{
    public class StopMaterialPulse: MonoBehaviour
    {
        private Renderer _renderer;
        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
        }

        private void Update()
        {
            _renderer.material.mainTextureOffset+= Vector2.right*Time.deltaTime*0.1f;
        }
    }
}