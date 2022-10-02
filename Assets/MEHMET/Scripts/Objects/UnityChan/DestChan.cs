using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace memo
{
    public class DestChan : Destructible
    {
        protected override void Awake()
        {
            base.Awake();

            myRB.AddForce(0, expForce, 0, ForceMode.VelocityChange);
        }
    }
}