using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace memo
{
    public class Destructible : MonoBehaviour
    {
        protected Rigidbody myRB;

        [SerializeField]
        protected float expForce;

        protected virtual void Awake()
        {
            myRB = GetComponent<Rigidbody>();
        }
    }
}