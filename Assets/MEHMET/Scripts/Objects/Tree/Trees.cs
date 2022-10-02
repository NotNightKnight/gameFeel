using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace memo
{
    public class Trees : MonoBehaviour
    {
        [SerializeField]
        private List<MeshRenderer> treeList;

        [SerializeField]
        private List<GameObject> treeParticle;

        [SerializeField]
        private Material newMat;

        public void ChangeTrees()
        {
            foreach(var tree in treeList)
            {
                tree.material = newMat;
            }
            foreach(var particle in treeParticle)
            {
                particle.SetActive(true);
            }
        }
    }
}