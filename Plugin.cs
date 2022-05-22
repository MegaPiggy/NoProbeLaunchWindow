using BepInEx;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace NoProbeLaunchWindow
{
    [BepInPlugin("MegaPiggy.NoProbeLaunchWindow", "NoProbeLaunchWindow", "1.0.0")]
    [BepInProcess("OuterWilds_Alpha_1_2.exe")]
    [HarmonyPatch]
    public class NoProbeLaunchWindow : BaseUnityPlugin
    {
        private static Harmony harmony = new Harmony("MegaPiggy.NoProbeLaunchWindow");
        private static NoProbeLaunchWindow instance;
        public static NoProbeLaunchWindow Instance => instance;

        private void Awake()
        {
            instance = this;
            Logger.LogInfo($"{nameof(NoProbeLaunchWindow)} was started");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(ProbeLauncher), "CheckLaunchWindow")]
        private static bool CheckLaunchWindow(ProbeLauncher __instance, ref bool __result, ref float launchWindowLength)
        {
            launchWindowLength = 0;
            __result = false;
            return false;
        }
    }
}
