using System.Collections;
using System.Collections.Generic;
using UnityChan;
using UnityEngine;

namespace memo
{
    public class UnityChan : MonoBehaviour
    {
        [SerializeField]
        private GameObject destChan;
        [SerializeField]
        private Transform parent;

        [SerializeField]
        private RandomWind wind;

        private bool isQuitting = false;

        private void OnApplicationQuit()
        {
            isQuitting = true;
        }

        private void OnDestroy()
        {
            if(!isQuitting)
            {
                Instantiate(destChan, transform.position, Quaternion.identity, parent);
            }
        }

        public void Freeze()
        {
            wind.enabled = false;
        }
    }
}