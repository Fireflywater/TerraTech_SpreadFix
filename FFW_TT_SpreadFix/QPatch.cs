using System;
using System.Reflection;
using HarmonyLib;
using UnityEngine;

namespace FFW_TT_SpreadFix
{
    internal class QPatch
    {
        public static void Main()
        {
            Harmony harmonyInstance = new Harmony("ffw.ttmm.spreadfix.mod");
            harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
