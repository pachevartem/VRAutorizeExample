using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRGame
{
    public class GameManager : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            //Debug mode for developer
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // FindObjectOfType<ButtonFloor>().SwitchButton();
            }
        }
    }
}