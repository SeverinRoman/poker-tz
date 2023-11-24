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

public class Projectile : MonoBehaviour
{
    //#region editors fields and properties

    [SerializeField] private ProjectileScriptableObject projectileScriptableObject;

    //#endregion

    //#region public fields and properties
    public IObjectPool<GameObject> Pool { set { pool = value; } }

    //#endregion

    //#region private fields and properties

    private new Rigidbody2D rigidbody;
    private IObjectPool<GameObject> pool;

    private Coroutine lifeCoroutine;

    //#endregion


    //#region life-cycle callbacks

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    //#endregion

    //#region public methods

    public void AddForce(Vector2 force)
    {
        rigidbody.AddForce(force);
    }

    //#endregion

    //#region private methods

    public void StartTimeLife()
    {
        lifeCoroutine = StartCoroutine(CodeHelper.Helper.DelayAction(() => pool.Release(gameObject), projectileScriptableObject.timeLife));
    }

    //#endregion

    //#region event handlers

    //#endregion
}
