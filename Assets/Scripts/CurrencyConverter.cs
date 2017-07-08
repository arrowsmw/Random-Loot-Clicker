using UnityEngine;
using System.Collections;

public class CurrencyConverter : MonoBehaviour {

    private static CurrencyConverter instance;
    public static CurrencyConverter Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        CreateInstance();
    }

    void CreateInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public string GetCurrencyIntoString(float valueToConvert, bool currencyPerSec, bool currencyPerClick)
    {
        string converted;
        if(valueToConvert >= 1000000000)
        {
            converted = (valueToConvert / 1000000000).ToString("F3") + " Bil";
        }
        else if(valueToConvert >= 1000000)
        {
            converted = (valueToConvert / 1000000).ToString("F3") + " Mil";
        }
        else if(valueToConvert >= 1000)
        {
            converted = (valueToConvert / 1000).ToString("F3") + " K";
        }
        else
        {
            converted = "" + valueToConvert.ToString("F0");
        }

        if (currencyPerSec == true)
        {
            converted = converted + " gold/sec";
        }

        if(currencyPerClick == true)
        {
            converted = converted + " gold/click";
        }

        return converted;

    }
        
}
