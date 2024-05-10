using OWML.Common;
using OWML.ModHelper;
using UnityEngine.Assertions;

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
        }
    }

}
