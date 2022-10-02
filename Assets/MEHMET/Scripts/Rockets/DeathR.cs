using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace memo
{
    public class DeathR : Rocket
    {
        [SerializeField]
        private GameObject particle;

        [SerializeField]
        private GameObject unityChan;

        [SerializeField]
        private Trees treeManager;

        [SerializeField]
        private CanvasGroup effectPanel;

        [SerializeField]
        private GameObject expArea;

        [SerializeField]
        private float alphaDecrease;

        private float number = 1;

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

            Destroy(unityChan);
            treeManager.ChangeTrees();
            expArea.SetActive(true);

            effectPanel.alpha = 1;
            InvokeRepeating(nameof(DecreaseAlpha), 0, 0.1f);

            particle.SetActive(false);
            meshRenderer.enabled = false;
            Invoke(nameof(DestroyMe), 20);
        }

        private void DestroyMe()
        {
            gameObject.SetActive(false);
        }

        private void DecreaseAlpha()
        {
            effectPanel.alpha -= number * Time.deltaTime;
            if(effectPanel.alpha < 0)
            {
                effectPanel.alpha = 0;
                CancelInvoke(nameof(DecreaseAlpha));
            }

            number += alphaDecrease;
        }
    }
}