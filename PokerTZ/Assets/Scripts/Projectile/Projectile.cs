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

public class Projectile : MonoBehaviour, ISlowMotion
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

    private float startGravityScale;
    private float startDrag;
    private float startMass;

    //#endregion


    //#region life-cycle callbacks

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        startGravityScale = rigidbody.gravityScale;
        startDrag = rigidbody.drag;
        startMass = rigidbody.mass;
    }

    //#endregion

    //#region public methods

    public void AddForce(Vector2 force)
    {
        rigidbody.AddRelativeForce(force);
    }

    public void ChangeSpeed(float speed)
    {
        rigidbody.velocity *= speed;
        rigidbody.gravityScale *= speed / 10f;
        rigidbody.drag *= speed;
        rigidbody.mass *= speed;
    }

    public void ReturnNormalSpeed(float speed)
    {
        rigidbody.velocity *= speed;
        SetStartPhysics2DSettings();
    }

    public void SetStartPhysics2DSettings()
    {
        rigidbody.gravityScale = 1f;
        rigidbody.drag = startDrag;
        rigidbody.mass = startMass;
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
