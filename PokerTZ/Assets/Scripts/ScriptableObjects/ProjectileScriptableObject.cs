//#region import
using System.Collections.Generic;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;
//#endregion
[CreateAssetMenu(fileName = "Data", menuName = "Data/ProjectileSettings", order = 1)]
public class ProjectileScriptableObject : ScriptableObject
{
    public float timeLife = 1;
}
