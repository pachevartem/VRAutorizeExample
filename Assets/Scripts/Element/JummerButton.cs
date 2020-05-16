using System;
using UnityEngine;

namespace VRGame
{
    
    public class JummerButton : MonoBehaviour  // TODO: Переосмылить его необходимость
    {
        public ForceField Fz;

        private void Awake()
        {
            if (Fz == null)
            {
                Debug.LogError("Не назначена силовое поля для отключения");
                Debug.Break();
            }
        }
    }
}