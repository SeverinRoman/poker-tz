//#region import
using System.Collections.Generic;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;
//#endregion

public interface ISlowMotion
{
    void ChangeSpeed(float speed);

    void ReturnNormalSpeed(float speed);
}
