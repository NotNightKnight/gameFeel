using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace memo
{
    public class Rocket : MonoBehaviour
    {
        public float speed;

        protected Rigidbody myRB;

        protected AudioSource audioSource;

        protected MeshRenderer meshRenderer;

        [SerializeField]
        protected AudioClip launchClip, explosionClip;

        protected virtual void Awake()
        {
            myRB = GetComponent<Rigidbody>();
            audioSource = GetComponent<AudioSource>();
            meshRenderer = GetComponent<MeshRenderer>();
        }

        public virtual void Launch() 
        {
            audioSource.PlayOneShot(launchClip);
        }
        protected virtual void Explode()        
        {
            //audioSource.PlayOneShot(explosionClip);        
        }
    }
}