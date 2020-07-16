using System;
using System.Reflection;
using Harmony;
using UnityEngine;

namespace FFW_TT_SpreadMod
{
    internal class QPatch
    {
        public static void Main()
        {
            HarmonyInstance harmonyInstance = HarmonyInstance.Create("ffw.ttmm.spreadfix.mod");
            harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
