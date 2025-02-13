using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public GameObject fire;
    public bool isCoroutine = true;
    public bool isAttack;
    public float wait;
    public LayerMask enemyLayer;

    void Start()
    {
        fire.SetActive(false);
    }

    void Update()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, 2f, enemyLayer);
        if (collider2Ds.Length > 0){
            isAttack = true;
        } else{
            isAttack = false;
        }

        if(isCoroutine && isAttack){
            StartCoroutine(startFire());
        }
    }


    IEnumerator startFire(){
        fire.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        isCoroutine = false;
        fire.SetActive(false);
        yield return new WaitForSecondsRealtime(wait);
        isCoroutine = true;
    }
}
