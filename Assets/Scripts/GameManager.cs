using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VRGame
{
    
    /// <summary>
    /// Данный класс отвечает за перезагрузку текущего уровня в случае смерти от противников.
    /// Необходимо для работы всей сцены
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static int HP = 100;

        private void Awake()
        {
            HP = 100;
        }


        // Update is called once per frame
        void Update()
        {
            if (HP <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}