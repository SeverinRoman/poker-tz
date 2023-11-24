//#region import
using System.Collections.Generic;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;
//#endregion

public class ChangeSpeedZone : MonoBehaviour
{
    //#region editors fields and properties

    [SerializeField] private ChangeSpeedZoneScriptableObject changeSpeedZoneScriptableObject;

    //#endregion

    //#region public fields and properties
    //#endregion

    //#region private fields and properties
    //#endregion


    //#region life-cycle callbacks
    //#endregion

    //#region public methods

    //#endregion

    //#region private methods

    //#endregion

    //#region event handlers

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.TryGetComponent<ISlowMotion>(out ISlowMotion slowMotion))
        {
            slowMotion.ChangeSpeed(changeSpeedZoneScriptableObject.slowMultiplayer);
        }
    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.TryGetComponent<ISlowMotion>(out ISlowMotion slowMotion))
        {
            slowMotion.ReturnNormalSpeed(changeSpeedZoneScriptableObject.slowMultiplayer);
        }
    }

    //#endregion
}
