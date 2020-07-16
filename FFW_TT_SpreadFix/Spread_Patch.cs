using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harmony;
using System.Reflection;
using UnityEngine;
using System.Runtime.CompilerServices;

namespace FFW_TT_SpreadMod
{
    public static class WrappedDataHolder
    {
        [HarmonyPatch(typeof(Projectile), "Fire")]
        class Projectile_Fire_Patch
        {
            static Vector3 Random2(Vector3 v, float variance)
            {
                return new Vector3(
                    v.x + Vector3.Magnitude(v) * 0.5f * UnityEngine.Random.Range(-variance, variance),
                    v.y + Vector3.Magnitude(v) * 0.5f * UnityEngine.Random.Range(-variance, variance),
                    v.z + Vector3.Magnitude(v) * 0.5f * UnityEngine.Random.Range(-variance, variance)
                );
            }

            static void Postfix(ref Projectile __instance, Vector3 fireDirection, FireData fireData, ModuleWeapon weapon, Tank shooter = null, bool seekingRounds = false, bool replayRounds = false)
            {
                FieldInfo field_LastFireDirection = typeof(Projectile)
                    .GetField("m_LastFireDirection", BindingFlags.NonPublic | BindingFlags.Instance);

                Vector3 vector = fireDirection * fireData.m_MuzzleVelocity;
                if (!replayRounds)
                {
                    field_LastFireDirection.SetValue(__instance, Random2(vector, fireData.m_BulletSprayVariance));
                    vector = (Vector3)field_LastFireDirection.GetValue(__instance);
                }
                else
                {
                    vector = (Vector3)field_LastFireDirection.GetValue(__instance);
                }
                if (shooter != null)
                {
                    vector += shooter.rbody.velocity;
                }
                __instance.rbody.velocity = vector;
            }
        }
    }
}

