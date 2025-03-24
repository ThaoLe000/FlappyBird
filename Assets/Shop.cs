using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private Text costTXT;
    private ShopPanel shopPanel;
    [SerializeField] private string text;
    private void Awake()
    {
        shopPanel = FindObjectOfType<ShopPanel>();
    }
    private void Start()
    {
        
    }
    public void Payment()
    {
        string value = costTXT.text;
        int price = int.Parse(value);
        bool request =  shopPanel.Payment(price);
        if (request)
        {
            int item = PlayerPrefs.GetInt(text, 0);
            item++;
            PlayerPrefs.SetInt(text, item);
            Debug.Log(item);
        }
        else
        {
            Debug.Log("Khong du tien");
        }
    }
}
