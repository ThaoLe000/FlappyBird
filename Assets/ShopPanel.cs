using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] private Text yourMoney;

    private void Awake()
    {
        UpdateMoney();
    }
    private void FixedUpdate()
    {
        UpdateMoney();
    }
    private void UpdateMoney()
    {
        yourMoney.text = PlayerPrefs.GetInt("Money", 1000).ToString();
    }
    public bool Payment(int value)
    {

        int money = PlayerPrefs.GetInt("Money", 1000);
        if(money >= value)
        {
            money -= value;
            PlayerPrefs.SetInt("Money", money);
            UpdateMoney();
            return true;
        }
        else
        {
            return false;
        }
    }


}
