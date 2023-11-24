//#region import
using System.Collections.Generic;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;
//#endregion

public class Projectile : MonoBehaviour
{
    //#region editors fields and properties
    //#endregion

    //#region public fields and properties
    //#endregion

    //#region private fields and properties

    private new Rigidbody2D rigidbody;

    //#endregion


    //#region life-cycle callbacks

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {

    }

    void OnDisable()
    {

    }

    void Start()
    {

    }

    //#endregion

    //#region public methods

    public void AddForce(Vector2 force)
    {
        rigidbody.AddForce(force);
    }

    //#endregion

    //#region private methods

    //#endregion

    //#region event handlers

    //#endregion
}
