using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VRGame
{
    /// <summary>
    /// Класс отвечает за сбор ключей и убирает преграду, для допуска к кнопке..
    /// Необходимо указать сколько ключей надо собрать, чтобы убрать преграду
    /// </summary>
    public class KeyManager : MonoBehaviour
    {
        #region PublicVariables

        [Header("Перетяни сюда все необходимые ключи, для разблокировке преграды")]
        public List<Key> Keys = new List<Key>();


        [Header("данная переменная отвечает за количество ключей, которые разблокируют преграду")]
        public int countKey;


        [Header("Перетяни сюда преграду преграды")]
        public GameObject pregrada;

        #endregion

        private int curentKey = 0;

        public static Action OnKeyManager = () => { };

        private void Awake()
        {
            if (countKey == 0)
            {
                Debug.LogError("не назначена переменная - countKey");
            }

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

        private void OnDrawGizmosSelected()
        {
            if (Keys.Count != 0 && pregrada != null)
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