using UnityEngine;
using VRTK.Controllables;
using VRTK.Examples;

namespace VRGame
{
    public class VR_ButtonGateV2: ControllableReactor
    {
        public Gate gate;
        
        protected override void MaxLimitReached(object sender, ControllableEventArgs e)
        {
            gate.SwitchDoor(); }
    }
}