using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables;
using VRTK.Examples;

namespace VRGame
{
    public class VRButtonGate : ControllableReactor
    {
        public Gate gate;
        protected override void MaxLimitReached(object sender, ControllableEventArgs e)
        {
            gate.SwitchDoor();
        }
    }
}