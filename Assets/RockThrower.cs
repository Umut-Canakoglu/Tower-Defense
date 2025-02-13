using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockThrower : MonoBehaviour
{
    public bool isAttack = false;
    public float wait;
    public Enemy enemy;
    private bool isCoroutine = true;
    public Transform transform;
    public LayerMask enemyLayer;
    private GameObject target;
    public Transform startPosition;
    private GameObject targetBefore;
    public GameObject rock;
    
    

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    void Update()
    {
        if(target != null){
            Vector3 Look = transform.InverseTransformPoint(target.transform.position);
            float Angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg;
            transform.Rotate(0,0,Angle);
        }
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, 6f, enemyLayer);
        if (collider2Ds.Length > 0)
        {
            isAttack = true;
            enemy = collider2Ds[0].gameObject.GetComponent<Enemy>();
            target = collider2Ds[0].gameObject;
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
            isAttack = false;
            target = null;
        }
        if(isAttack && isCoroutine)
        {
            StartCoroutine(Damage());
        }

    }

    IEnumerator Damage(){
        Quaternion change = Quaternion.Euler(0, 0, -10f);
        Instantiate(rock, startPosition.position, transform.rotation*change);
        isCoroutine = false;
        yield return new WaitForSecondsRealtime(wait);
        isCoroutine = true;
    }
}
