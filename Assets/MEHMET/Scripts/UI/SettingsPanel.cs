using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace memo
{
    public class SettingsPanel : MonoBehaviour
    {
        [SerializeField]
        private List<Cube> cubeList;

        [SerializeField]
        private List<UnityChan> unityChanList;

        [SerializeField]
        private CanvasGroup canvasGroup;

        [SerializeField]
        private SpearR spearR;

        [SerializeField]
        private EffectR effectR;

        [SerializeField]
        private DeathR deathR;

        private EffectR.EffectType effectType;

        [SerializeField]
        private TMP_InputField spearSpeed, spearAfterSpeed,
            spearExpRange, effectSpeed, deathSpeed;

        [SerializeField]
        private TMP_Dropdown dropdown;

        private void Start()
        {
            dropdown.onValueChanged.AddListener(delegate
            {
                EffectTypeChanged(dropdown);
            });
        }

        private void EffectTypeChanged(TMP_Dropdown drop)
        {
            switch(drop.value)
            {
                case 0:
                    effectType = EffectR.EffectType.Fire;
                    break;
                case 1:
                    effectType = EffectR.EffectType.Ice;
                    break;
                case 2:
                    effectType = EffectR.EffectType.Poison;
                    break;
                case 3:
                    effectType = EffectR.EffectType.ShapeChange;
                    break;
            }
        }

        public void ChangeClick()
        {
            CheckSetSpeed();
            
            effectR.effectType = effectType;
        }

        //I'm really sad for this func :(
        public void RestartClick()
        {
            foreach(var cube in cubeList)
            {
                Destroy(cube);
            }
            foreach(var chan in unityChanList)
            {
                Destroy(chan);
            }

            var scene = SceneManager.GetActiveScene().name;
            SceneManager.LoadSceneAsync(scene);
        }

        public void OpenPanel()
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        public void ClosePanel()
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;

            ClearTexts();
        }

        //Checks input areas then sets them with a lot of "if"s
        private void CheckSetSpeed()
        {
            if (spearSpeed.text != "")
            {
                spearR.speed = float.Parse(spearSpeed.text);
            }
            if (spearAfterSpeed.text != "")
            {
                spearR.AfterSpeed = float.Parse(spearAfterSpeed.text);
            }
            if (spearExpRange.text != "")
            {
                spearR.ExpRange = float.Parse(spearExpRange.text);
            }
            if (effectSpeed.text != "")
            {
                effectR.speed = float.Parse(effectSpeed.text);
            }
            if (deathSpeed.text != "")
            {
                deathR.speed = float.Parse(deathSpeed.text);
            }
        }

        //Poorly written clear text func
        private void ClearTexts()
        {
            spearSpeed.text = "";
            spearAfterSpeed.text = "";
            spearExpRange.text = "";
            effectSpeed.text = "";
            deathSpeed.text = "";
        }
    }
}