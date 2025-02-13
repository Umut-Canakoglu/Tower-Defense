using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mizrak : MonoBehaviour
{
    private bool isCoroutine;
    public Transform pointA;
    public Transform pointB;
    private Transform transform;
    private GameObject target;
    private GameObject targetBefore;
    private Transform currentPoint;
    private bool isAttack;
    public Enemy enemy;
    public LayerMask enemyLayer;
    public Transform main;
    void Start()
    {
        transform = GetComponent<Transform>();
        currentPoint = pointB;
        isCoroutine = false;
    }
    void Update()
    {
        if(target != null){
            Vector3 Look = main.InverseTransformPoint(target.transform.position);
            float Angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg;
            main.Rotate(0,0,Angle);
        }
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, 2.5f, enemyLayer);
        if (collider2Ds.Length > 0)
        {
            isAttack = true;
            target = collider2Ds[0].gameObject;
            enemy = collider2Ds[0].gameObject.GetComponent<Enemy>();
            if (targetBefore != target)
            {
                foreach (Collider2D collider2D in collider2Ds)
                {
                    if (targetBefore == collider2D.gameObject)
                    {
                        target = targetBefore;
                    }
                }
            }
            targetBefore = target;

        } else {
            isCoroutine = false;
            isAttack = false;
            target = null;
        }
        if(isAttack == true && isCoroutine == false)
        {
            isCoroutine = true;
            StartCoroutine(Spear());
        }
    }
    IEnumerator Spear()
    {
        while (true)
        {
            if (currentPoint == pointA)
            {
                currentPoint = pointB;
            } else {
                currentPoint = pointA;
            }
            transform.position = currentPoint.position;
            Debug.Log("Annen");
            yield return new WaitForSecondsRealtime(1f);
        }
    }
    void OnCollisionEnter(Collision other) {
        enemy.Damage(3);
    }
}
