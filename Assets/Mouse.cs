using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public RandomItem shop;
    public bool buy;
    void Start()
    {
        shop = GameObject.FindWithTag("Shop").GetComponent<RandomItem>();
        buy = shop.bought;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        buy = shop.bought;
        if (buy == true && Input.GetMouseButtonDown(0))
        {
            shop.bought = false;
            buy = false;
            Instantiate(shop.item, mousePos, Quaternion.identity);
        }
    }
}
