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
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if(target != null){
            Vector3 Look = transform.InverseTransformPoint(target.transform.position);
            float Angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg;
            transform.Rotate(0,0,Angle);
        }
        if(isAttack && isCoroutine)
        {
            StartCoroutine(Damage());
        }

    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Enemy"){
            isAttack = true;
            enemy = collider.gameObject.GetComponent<Enemy>();
            target = collider.gameObject;
        } else{
            isAttack = false;
            target = null;
        }
    }

    IEnumerator Damage(){
        isCoroutine = false;
        enemy.Damage(damage);
        yield return new WaitForSecondsRealtime(wait);
        isCoroutine = true;
    }
}
