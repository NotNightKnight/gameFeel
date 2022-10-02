using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace memo
{
    public class RocketBtns : MonoBehaviour
    {
        [SerializeField]
        private SpearR spearR;

        [SerializeField]
        private EffectR effectR;

        [SerializeField]
        private DeathR deathR;

        [SerializeField]
        private SettingsPanel settingsPanel;

        private bool isOpen = false;

        public void SpearClick()
        {
            spearR.Launch();
        }
        public void EffectClick()
        {
            effectR.Launch();
        }
        public void DeathClick()
        {
            deathR.Launch();
        }

        public void SettingsClick()
        {
            if(isOpen)
            {
                settingsPanel.ClosePanel();
                isOpen = false;
                return;
            }
            else
            {
                settingsPanel.OpenPanel();
                isOpen = true;
                return;
            }
        }
    }
}