//#region import
using System.Collections.Generic;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;
//#endregion


[CreateAssetMenu(fileName = "Data", menuName = "Data/ChangeSpeedZoneSettings", order = 1)]
public class ChangeSpeedZoneScriptableObject : ScriptableObject
{
    [Range(1, 50)] public float slowMultiplayer = 10f;
}

