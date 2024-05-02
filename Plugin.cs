using BepInEx;
using HarmonyLib;
using TurnTheGameOn.SimpleTrafficSystem;

namespace NoMoreCars
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded! Applying patch...");
            Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            harmony.PatchAll();
        }
    }
    public static class CarRemovalPatch
    {
        [HarmonyPatch(typeof(AITrafficCar), "RegisterCar")]
        public static class AITrafficCar_RegisterCar_Patch
        {
            public static void Postfix(AITrafficCar __instance)
            {
                __instance.gameObject.SetActive(false);
            }
        }
    }
}
