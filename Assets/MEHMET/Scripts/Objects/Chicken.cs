using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace memo
{
    public class Chicken : MonoBehaviour
    {
        [SerializeField]
        private GameObject particle;

        private void Start()
        {
            particle.SetActive(true);
        }
    }
}