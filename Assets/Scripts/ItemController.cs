using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{

    public Click click;
    public UnityEngine.UI.Text upgradeInfo;
    public UnityEngine.UI.Text toolTip;
    public float cost;
    public int count = 0;
    public int upgradePower;
    public string upgradeName;
    public Color standard;
    public Color affordable;
    public ItemManager[] items;

    void Start()
    {
        toolTip.transform.localScale = new Vector3(0, 0, 0);
    }

    void Update()
    {

        if (count > 0)
        {
            upgradeInfo.text = "x" + upgradePower + " (" + count + ")";
        }
        else
        {
            upgradeInfo.text = "x" + upgradePower;
        }

        if (click.gold >= cost)
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
        if (click.gold >= cost)
        {
            click.gold -= cost;
            count += 1;

            switch (upgradeName)
            {
                case "Miner":
                    switch (count)
                    {
                        case 0:
                            cost = 1000;
                            break;
                        case 1:
                            cost = 10000;
                            break;
                        case 2:
                            cost = 100000;
                            
                            break;
                    }
                    break;
                case "Digger":
                    switch (count)
                    {
                        case 0:
                            cost = 1000;
                            break;
                        case 1:
                            cost = 10000;
                            break;
                        case 2:
                            cost = 100000;
                            break;
                    }
                    break;
                case "Dwarf":
                    switch (count)
                    {
                        case 0:
                            cost = 1000;
                            break;
                        case 1:
                            cost = 10000;
                            break;
                        case 2:
                            cost = 100000;
                            break;
                    }
                    break;
            }

            foreach (ItemManager item in items)
            {
                if (item.itemName == upgradeName)
                {
                    item.tickValue += item.baseTickValue * upgradePower;
                }
            }

            if (count >= 3)
            {
                switch(upgradeName)
                {
                    case "Miner":
                        GameObject.Find("ItemUpgrade1").GetComponent<Button>().enabled = false;
                        GameObject.Find("ItemUpgrade1").transform.localScale = new Vector3(0, 0, 0);
                        break;
                    case "Digger":
                        GameObject.Find("ItemUpgrade2").GetComponent<Button>().enabled = false;
                        GameObject.Find("ItemUpgrade2").transform.localScale = new Vector3(0, 0, 0);
                        break;
                    case "Dwarf":
                        GameObject.Find("ItemUpgrade3").GetComponent<Button>().enabled = false;
                        GameObject.Find("ItemUpgrade3").transform.localScale = new Vector3(0, 0, 0);
                        break;
                }
                
            }
        }
    }

    public void ShowToolTip()
    {
        toolTip.transform.localScale = new Vector3(1, 1, 1);
    }

    public void HideToolTip()
    {
        toolTip.transform.localScale = new Vector3(0, 0, 0);
    }
}
