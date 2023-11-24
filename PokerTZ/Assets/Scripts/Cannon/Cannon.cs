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

public class Cannon : MonoBehaviour
{
    //#region editors fields and properties
    [SerializeField] CannonConfigScriptableObject cannonConfigScriptableObject;
    [SerializeField] private Transform muzzle;
    //#endregion

    //#region public fields and properties

    public IObjectPool<GameObject> Pool
    {
        get
        {
            if (pool == null)
            {
                if (cannonConfigScriptableObject.poolType == PoolType.Stack)
                    pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, 10, cannonConfigScriptableObject.maxPoolSize);
                else
                    pool = new LinkedPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, cannonConfigScriptableObject.maxPoolSize);
            }
            return pool;
        }
    }

    //#endregion

    //#region private fields and properties
    private IObjectPool<GameObject> pool;
    private Coroutine shotCoroutine;

    //#endregion


    //#region life-cycle callbacks
    void Awake()
    {
    }


    void Start()
    {
        shotCoroutine = StartCoroutine(CodeHelper.Helper.ForeverDelayAction(Shot, cannonConfigScriptableObject.timeShot));
        Shot();
    }

    //#endregion

    //#region public methods

    public void Shot()
    {
        GameObject gameObject = Pool.Get();

        Projectile projectile = gameObject.GetComponent<Projectile>();

        Vector2 direction = (muzzle.position - transform.position).normalized;
        Vector2 impulse = direction * cannonConfigScriptableObject.force;
        projectile.AddForce(impulse);
    }

    //#endregion

    //#region private methods

    private GameObject CreatePooledItem()
    {
        GameObject newGameObject = Instantiate(cannonConfigScriptableObject.projectile);
        newGameObject.transform.SetParent(muzzle);
        newGameObject.transform.localPosition = cannonConfigScriptableObject.projectile.transform.localPosition;
        newGameObject.transform.localScale = cannonConfigScriptableObject.projectile.transform.localScale;
        newGameObject.transform.rotation = cannonConfigScriptableObject.projectile.transform.rotation;

        Projectile projectile = newGameObject.GetComponent<Projectile>();
        projectile.Pool = pool;
        projectile.StartTimeLife();


        return newGameObject;
    }

    void OnTakeFromPool(GameObject gameObject)
    {
        gameObject.transform.localPosition = cannonConfigScriptableObject.projectile.transform.localPosition;
        gameObject.transform.localScale = cannonConfigScriptableObject.projectile.transform.localScale;
        gameObject.transform.rotation = cannonConfigScriptableObject.projectile.transform.rotation;
        gameObject.SetActive(true);
        Projectile projectile = gameObject.GetComponent<Projectile>();

        projectile.StartTimeLife();

    }

    private void OnReturnedToPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    void OnDestroyPoolObject(GameObject gameObject)
    {
        Destroy(gameObject);
    }

    //#endregion

    //#region event handlers

    //#endregion
}
