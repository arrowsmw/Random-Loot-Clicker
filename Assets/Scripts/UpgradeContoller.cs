using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeContoller : MonoBehaviour {

    public Click click;
    public UnityEngine.UI.Text upgradeInfo;
    public UnityEngine.UI.Text toolTip;
    public float cost;
    public int count = 0;
    public int upgradePower;
    public string upgradeName;
    public Color standard;
    public Color affordable;
    public UpgradeManager[] upgrades;

    void Start()
    {
        toolTip.transform.localScale = new Vector3(0, 0, 0);
    }
	void Update () {
	
        if(count > 0)
        {
            upgradeInfo.text = "x" + upgradePower + " (" + count + ")";
        }
        else
        {
            upgradeInfo.text = "x" + upgradePower;
        }

        if(click.gold >= cost)
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

            switch (upgradeName)
            {
                case "Pickaxe":
                    switch (count)
                    {
                        case 0: cost = 1000;
                            break;
                        case 1: cost = 10000;
                            break;
                        case 2: cost = 100000;
                            break;
                    }
                    break;
                case "Drill":
                    switch (count)
                    {
                        case 0: cost = 1000;
                            break;
                        case 1: cost = 10000;
                            break;
                        case 2: cost = 100000;
                            break;
                    }
                    break;
                case "Bagger 288":
                    switch (count)
                    {
                        case 0: cost = 1000;
                            break;
                        case 1: cost = 10000;
                            break;
                        case 2: cost = 100000;
                            break;
                    }
                    break;  
            }

            foreach(UpgradeManager upgrade in upgrades)
            {
                if(upgrade.itemName == upgradeName)
                {
                    click.goldperclick -= (upgrade.clickPower * upgrade.count);
                    upgrade.clickPower += upgrade.baseClickPower * upgradePower;
                    click.goldperclick += (upgrade.clickPower * upgrade.count);
                    
                    
                }
            }

            if (count >= 3)
            {
                switch (upgradeName)
                {
                    case "Pickaxe":
                        GameObject.Find("Upgrade1").GetComponent<Button>().enabled = false;
                        GameObject.Find("Upgrade1").transform.localScale = new Vector3(0, 0, 0);
                        break;
                    case "Drill":
                        GameObject.Find("Upgrade2").GetComponent<Button>().enabled = false;
                        GameObject.Find("Upgrade2").transform.localScale = new Vector3(0, 0, 0);
                        break;
                    case "Bagger 288":
                        GameObject.Find("Upgrade3").GetComponent<Button>().enabled = false;
                        GameObject.Find("Upgrade3").transform.localScale = new Vector3(0, 0, 0);
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
