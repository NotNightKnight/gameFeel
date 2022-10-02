using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace memo
{
    public class SpearR : Rocket
    {
        [SerializeField]
        private GameObject particle;

        [SerializeField]
        private GameObject explosion;

        public float afterSpeed;
        public float expRange;

        private void OnCollisionEnter(Collision collision)
        {
            var dir = afterSpeed * Vector3.back;
            myRB.AddForce(dir, ForceMode.VelocityChange);
        }

        private void OnTriggerEnter(Collider other)
        {
            Explode();
        }

        public override void Launch()
        {
            base.Launch();

            var dir = speed * Vector3.back;
            myRB.AddForce(dir, ForceMode.VelocityChange);

            particle.SetActive(true);
        }

        protected override void Explode()
        {
            base.Explode();

            audioSource.PlayOneShot(explosionClip);

            explosion.SetActive(true);
            Invoke(nameof(ExpEnd), 2);

            var objs = Physics.SphereCastAll(transform.position, expRange, Vector3.one, expRange, LayerMask.GetMask("Destructibles"));
            
            foreach(var obj in objs)
            {
                if(obj.transform.CompareTag("Destructible"))
                {
                    Destroy(obj.transform.gameObject);
                }
                else if(obj.transform.CompareTag("UnityChan"))
                {
                    Destroy(obj.transform.gameObject);
                }
            }

            meshRenderer.enabled = false;
            particle.SetActive(false);
            Invoke(nameof(DestroyMe), 20);
        }

        private void ExpEnd()
        {
            explosion.SetActive(false);
        }

        private void DestroyMe()
        {
            gameObject.SetActive(false);
        }

        public float AfterSpeed
        {
            get { return afterSpeed; }
            set { afterSpeed = value; }
        }
        public float ExpRange
        {
            get { return expRange; }
            set { expRange = value; }
        }
    }
}