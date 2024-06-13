using OWML.Common;
using OWML.ModHelper;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UnityEngine;

namespace OWTrunic
{
    public class OWTrunic : ModBehaviour
    {
        private void Awake()
        {
            // You won't be able to access OWML's mod helper in Awake.
            // So you probably don't want to do anything here.
            // Use Start() instead.
        }

        private void Start()
        {
            var api = ModHelper.Interaction.TryGetModApi<ILocalizationAPI>("xen.LocalizationUtility");
            api.RegisterLanguage(this, "Trunic", "Assets/Translation.xml");
            api.AddLanguageFont(this, "Trunic", "Assets/trunic_lite", "Assets/Trunic_Lite.otf");

            FixSpacing();

            LoadManager.OnCompleteSceneLoad += (scene, loadScene) =>
            {
                ModHelper.Events.Unity.FireOnNextUpdate(() => { FixSpacing(); });
            };
        }

        private void FixSpacing()
        {
            var styles = Resources.FindObjectsOfTypeAll(typeof(TextStyleApplier)) as TextStyleApplier[];

            foreach(var style in styles)
            {
                style.spacing = 0;
            }

            var texts = Resources.FindObjectsOfTypeAll(typeof(Text)) as Text[];

            foreach(var text in texts)
            {
                text.lineSpacing = 1;
            }
        }
    }

}
