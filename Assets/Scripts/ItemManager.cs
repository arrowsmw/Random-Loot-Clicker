using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {

    public UnityEngine.UI.Text itemInfo;
    public Click click;
    public float cost;
    public int tickValue;
    public int baseTickValue;
    public int count;
    public string itemName;
    public Color standard;
    public Color affordable;
    private float _baseCost;
    private Slider _slider;

    void Start()
    {
        tickValue = baseTickValue;
        _baseCost = cost;
        _slider = GetComponentInChildren<Slider>();
    }

    void Update()
    {
        if(count > 0)
        {
            itemInfo.text = itemName + " (" + count + ")" + "\nCost: " + CurrencyConverter.Instance.GetCurrencyIntoString(cost, false, false) + "\nGold: " + tickValue + "/s";
        }
        else
        {
            itemInfo.text = itemName + "\nCost: " + CurrencyConverter.Instance.GetCurrencyIntoString(cost, false, false) + "\nGold: " + tickValue + "/s";
        }

        _slider.value = click.gold / cost * 100;
        if (_slider.value >= 100)
        {
            GetComponent<Image>().color = affordable;
        }
        else
        {
            GetComponent<Image>().color = standard;
        }


    }

    public void PurchasedItem()
    {
        if(click.gold >= cost)
        {
            click.gold -= cost;
            count += 1;
            cost = Mathf.Round(_baseCost * Mathf.Pow(1.25f, count));
        }
    }
    

	
}
