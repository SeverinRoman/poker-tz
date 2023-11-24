//#region import
using System.Collections.Generic;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;
using UnityEngine.Pool;
//#endregion


[CreateAssetMenu(fileName = "Data", menuName = "Data/CannonSettings", order = 1)]
public class CannonConfigScriptableObject : ScriptableObject
{
    public float force;
    public float timeShot;
    public GameObject projectile;

    [BoxGroup("Pool")] public PoolType poolType;
    [BoxGroup("Pool")] public int maxPoolSize = 10;
}
