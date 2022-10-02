using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace memo
{
    public class Cube : MonoBehaviour
    {
        [SerializeField]
        private GameObject destCube;
        [SerializeField]
        private Transform parent;

        private bool isQuitting = false;

        private void OnApplicationQuit()
        {
            isQuitting = true;
        }

        private void OnDestroy()
        {
            if(!isQuitting)
            {
                Instantiate(destCube, transform.position, Quaternion.identity, parent);
            }
        }
    }
}