//#region import
using System.Collections.Generic;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;
//#endregion
namespace PoolObjectHelper
{
    public static class PoolObjectHelper
    {
        public static void Create()
        {
            new GameObject("PooledObject");
        }
    }
}
