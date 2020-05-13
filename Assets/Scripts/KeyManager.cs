using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VRGame
{
    public class KeyManager : MonoBehaviour
    {
        public List<Key> Keys = new List<Key>();

        /// <summary>
        /// данная переменная отвечает за количество ключей, для активации кнопки
        /// </summary>
        private int countKey = 3;

        private int curentKey = 0;

        public GameObject pregrada;

        public static Action OnKeyManager = () => { };
        private void Awake()
        {
            Debug.Log("Всего ключей в сцене - " + Keys.Count);

            foreach (var key in Keys)
            {
                key.OnKey += AddKey;
            }
            
        }


        public void AddKey()
        {
            curentKey++;
            Debug.Log(curentKey + " - " + countKey);
            if (curentKey == countKey) // Вотэто место для событий. они потом будут меняться
            {
                OnKeyManager();
                pregrada.SetActive(false);
            }
        }

        private void OnDestroy()
        {
            foreach (var key in Keys)
            {
                key.OnKey -= AddKey;
            }
        }

        private void OnDrawGizmos()
        {
            if (Keys.Count != 0 && pregrada!=null)
            {
                foreach (var key in Keys)
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawLine(key.transform.position, pregrada.transform.position);
                }
            }
        }
    }
}