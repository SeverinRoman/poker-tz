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
    [SerializeField] private float force;
    [SerializeField] private float timeShot;
    [SerializeField] private Transform muzzle;
    [SerializeField] private GameObject projectile;

    [SerializeField][BoxGroup("Pool")] private PoolType poolType;
    [SerializeField][BoxGroup("Pool")] private int maxPoolSize = 10;

    //#endregion

    //#region public fields and properties



    private enum PoolType
    {
        Stack,
        LinkedList
    }

    public IObjectPool<GameObject> Pool
    {
        get
        {
            if (pool == null)
            {
                if (poolType == PoolType.Stack)
                    pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, 10, maxPoolSize);
                else
                    pool = new LinkedPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, maxPoolSize);
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
        shotCoroutine = StartCoroutine(CodeHelper.Helper.ForeverDelayAction(Shot, timeShot));
        Shot();
    }

    //#endregion

    //#region public methods

    public void Shot()
    {
        GameObject gameObject = Pool.Get();
        Projectile projectile = gameObject.GetComponent<Projectile>();

        Vector2 direction = (muzzle.position - transform.position).normalized;
        Vector2 impulse = direction * force;
        projectile.AddForce(impulse);
    }

    //#endregion

    //#region private methods

    private GameObject CreatePooledItem()
    {
        GameObject newGameObject = Instantiate(projectile);
        newGameObject.transform.SetParent(muzzle);
        newGameObject.transform.localScale = projectile.transform.localScale;
        newGameObject.transform.localPosition = projectile.transform.localPosition;
        return newGameObject;
    }

    void OnTakeFromPool(GameObject gameObject)
    {
        gameObject.SetActive(true);
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
