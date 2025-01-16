using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public bool isAttack = false;
    public int damage;
    public float wait;
    public Enemy enemy;
    private bool isCoroutine = true;
    public Transform transform;
    public LayerMask enemyLayer;
    private GameObject target;
    public Transform startPosition;
    
    public GameObject arrow;
    
    

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
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, 5f, enemyLayer);
        if (collider2Ds.Length > 0)
        {
            isAttack = true;
            enemy = collider2Ds[0].gameObject.GetComponent<Enemy>();
            target = collider2Ds[0].gameObject;
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
        Instantiate(arrow, startPosition.position, transform.rotation*change);
        isCoroutine = false;
        yield return new WaitForSecondsRealtime(wait);
        isCoroutine = true;
    }
}
