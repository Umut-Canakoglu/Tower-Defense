using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RandomItem : MonoBehaviour
{
    public Sprite[] images;
    public Sprite item;
    public bool bought;
    public TMP_Text moneyText;

    public TMP_Text item1costText;
    public TMP_Text item2costText;
    public TMP_Text item3costText;

    public int money;

    public int item1cost;
    public int item2cost;
    public int item3cost;

    public Image item1;
    public Image item2;
    public Image item3;


    void Start()
    {
        bought = false;
        refreshShop1();
        refreshShop2();
        refreshShop3();
    }

    void Update(){
        moneyText.text = money + " " + "$";

        item1costText.text = item1cost + " " + "$";
        item2costText.text = item2cost + " " + "$";
        item3costText.text = item3cost + " " + "$";
    }

    public void refreshShop1(){
        bought = true;
        int randomNum = Random.Range(0,images.Length);
        item1.sprite = images[randomNum];
        item = item1.sprite;

        if(randomNum == 0){
            item1cost = 5;
        } else if(randomNum == 1){
            item1cost = 10;
        } else if(randomNum == 2){
            item1cost = 15;
        } else if(randomNum == 3){
            item1cost = 20;
        } else{
            item1cost = 25;
        }
    }

    public void refreshShop2(){
        bought = true;
        int randomNum = Random.Range(0,images.Length);
        item2.sprite = images[randomNum];
        item = item2.sprite;
        if(randomNum == 0){
            item2cost = 5;
        } else if(randomNum == 1){
            item2cost = 10;
        } else if(randomNum == 2){
            item2cost = 15;
        } else if(randomNum == 3){
            item2cost = 20;
        } else{
            item2cost = 25;
        }
    }

    public void refreshShop3(){
        bought = true;
        int randomNum = Random.Range(0,images.Length);
        item3.sprite = images[randomNum];
        item = item3.sprite;
        if(randomNum == 0){
            item3cost = 5;
        } else if(randomNum == 1){
            item3cost = 10;
        } else if(randomNum == 2){
            item3cost = 15;
        } else if(randomNum == 3){
            item3cost = 20;
        } else{
            item3cost = 25;
        }
    }
}
