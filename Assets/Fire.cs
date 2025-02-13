using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public int damageValue;

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag ==  "Enemy"){
            Enemy enemyCode = collider.gameObject.GetComponent<Enemy>();
            enemyCode.Damage(damageValue);
        }
    }
}
