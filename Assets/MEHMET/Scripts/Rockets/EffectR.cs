using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace memo
{
    public class EffectR : Rocket
    {
        [SerializeField]
        private GameObject particle;

        [SerializeField]
        private GameObject unityChan;

        [SerializeField]
        private GameObject poisonedChan;

        [SerializeField]
        private GameObject poisonArea;

        [SerializeField]
        private GameObject fireArea;

        [SerializeField]
        private GameObject iceArea;

        [SerializeField]
        private GameObject chicken;

        [SerializeField]
        private AudioClip ice, shape;

        public EffectType effectType;

        public enum EffectType
        {
            Poison,
            Fire,
            Ice,
            ShapeChange
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

            if(effectType == EffectType.Poison)
            {
                audioSource.PlayOneShot(explosionClip);
                poisonArea.SetActive(true);
                Destroy(unityChan);
            }
            else if(effectType == EffectType.Fire)
            {
                audioSource.PlayOneShot(explosionClip);
                fireArea.SetActive(true);
                Destroy(unityChan);
            }
            else if(effectType == EffectType.Ice)
            {
                audioSource.PlayOneShot(ice);
                iceArea.SetActive(true);

                unityChan.GetComponent<UnityChan>().Freeze();
            }
            else if(effectType == EffectType.ShapeChange)
            {
                audioSource.PlayOneShot(shape);
                chicken.SetActive(true);
                unityChan.SetActive(false);
            }

            particle.SetActive(false);
            meshRenderer.enabled = false;
            Invoke(nameof(DestroyMe), 20);
        }

        private void DestroyMe()
        {
            gameObject.SetActive(false);
        }
    }
}