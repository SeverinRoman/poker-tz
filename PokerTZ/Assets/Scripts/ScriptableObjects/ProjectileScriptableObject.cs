//#region import
using UnityEngine;
//#endregion


[CreateAssetMenu(fileName = "Data", menuName = "Data/ProjectileSettings", order = 1)]
public class ProjectileScriptableObject : ScriptableObject
{
    public float timeLife = 1;
}
