using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour {

    public Click click;
    public UnityEngine.UI.Text itemInfo;
    public float cost;
    public int count = 0;
    public int clickPower;
    public int baseClickPower;
    public string itemName;
    public Color standard;
    public Color affordable;
    private float _baseCost;
    private Slider _slider;

    void Start()
    {
        clickPower = baseClickPower;
        _baseCost = cost;
        _slider = GetComponentInChildren<Slider>();
    }

    void Update()
    {
        if(count > 0)
        {
            itemInfo.text = itemName + " (" + count + ")" + "\nCost: " + CurrencyConverter.Instance.GetCurrencyIntoString(cost, false, false) + "\nPower: +" + clickPower;
        }
        else
        {
            itemInfo.text = itemName + "\nCost: " + CurrencyConverter.Instance.GetCurrencyIntoString(cost, false, false) + "\nPower: +" + clickPower;
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

    public void PurchasedUpgrade()
    {
        if(click.gold >= cost)
        {
            click.gold -= cost;
            count += 1;
            click.goldperclick += clickPower;
            cost = Mathf.Round(_baseCost * Mathf.Pow(1.25f, count));
        }
    }


}
