using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables;
using VRTK.Examples;

public class MyReactor : ControllableReactor
{
    protected override void ValueChanged(object sender, ControllableEventArgs e)
    {
      
        base.ValueChanged(sender, e);
    }

    protected override void MinLimitReached(object sender, ControllableEventArgs e)
    {  
        Debug.Log("YASMOG");
        base.MinLimitReached(sender, e);
    }
}
