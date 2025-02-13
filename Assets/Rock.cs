using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public Rigidbody2D rb;
    public int damage;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right*5f;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Enemy")
        {
            collider.gameObject.GetComponent<Enemy>().Damage(damage);
            Destroy(gameObject);
        } 
    }
}
