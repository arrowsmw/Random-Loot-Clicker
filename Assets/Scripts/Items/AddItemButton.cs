using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddItemButton : MonoBehaviour {

    private Inventory inv;
    private GlobalStats stats;
    private UnityEngine.UI.Button addButton;
    private UnityEngine.UI.Button addMaxButton;
    private UnityEngine.UI.Button buyButton;
    private UnityEngine.UI.Button killEnemyButton;
    private PlayerController pControl;
    

    void Start ()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        stats = GameObject.Find("StatsController").GetComponent<GlobalStats>();
        addButton = GameObject.Find("AddItem").GetComponent<Button>();
        addMaxButton = GameObject.Find("AddMaxItem").GetComponent<Button>();
        buyButton = GameObject.Find("BuyButton").GetComponent<Button>();
        killEnemyButton = GameObject.Find("EnemyKill").GetComponent<Button>();
        pControl = GameObject.Find("StatsController").GetComponent<PlayerController>();
	}

    void Update()
    {
        if(stats.gold >= 50 * (Mathf.Pow(1.3f, stats.playerLevel - 1)))
        {
            ColorBlock colors = buyButton.colors;
            colors.normalColor = new Color32(253, 173, 173, 255);
            colors.highlightedColor = new Color32(253, 173, 173, 255);
            colors.pressedColor = new Color32(253, 173, 173, 255);
            buyButton.colors = colors;
        }
        else
        {
            
            ColorBlock colors = buyButton.colors;
            colors.normalColor = new Color32(0, 0, 0, 50);
            colors.highlightedColor = new Color32(0, 0, 0, 50);
            colors.pressedColor = new Color32(0, 0, 0, 50);
            buyButton.colors = colors;
        }
        buyButton.GetComponentInChildren<Text>().text = "Buy Item: " + pControl.ValueIntoString(50 * (Mathf.Pow(1.3f, stats.playerLevel - 1)), false) + " gold";
    }
	
    public void OnMaxClicked()
    {
        for (int i = 0; i < 95; i++)
        {
            int type = Random.Range(0, 10);
            Item itemToAdd = new Item(type, stats.playerLevel);
            inv.AddItem(itemToAdd);
            switch (itemToAdd.Rarity)
            {
                case 1:
                    stats.commons += 1;
                    break;
                case 2:
                    stats.rares += 1;
                    break;
                case 3:
                    stats.epics += 1;
                    break;
                case 4:
                    stats.legendaries += 1;
                    break;
            }
        }
    }

    public void OnSingleClicked()
    {
        

        int type = Random.Range(0, 10);
        Item itemToAdd = new Item(type, stats.playerLevel);
        inv.AddItem(itemToAdd);
        switch (itemToAdd.Rarity)
        {
            case 1:
                stats.commons += 1;
                break;
            case 2:
                stats.rares += 1;
                break;
            case 3:
                stats.epics += 1;
                break;
            case 4:
                stats.legendaries += 1;
                break;
        }

    }

    public void OnBuyClicked()
    {
        if(stats.gold >= 50 * (Mathf.Pow(1.3f, stats.playerLevel - 1)))
        {
            stats.gold -= 50 * (Mathf.Pow(1.3f, stats.playerLevel - 1));
            Item itemToAdd = new Item(Random.Range(0, 10), stats.playerLevel);
            inv.AddItem(itemToAdd);
            switch(itemToAdd.Rarity)
            {
                case 1:
                    stats.commons += 1;
                    break;
                case 2:
                    stats.rares += 1;
                    break;
                case 3:
                    stats.epics += 1;
                    break;
                case 4:
                    stats.legendaries += 1;
                    break;
            }
        }
    }

    public void createStarterItem()
    {
        Item itemToAdd = new Item(9, 1);
        itemToAdd.Power = 10;
        itemToAdd.DamageMulti = 9;
        itemToAdd.CritChance = 0;
        itemToAdd.CritDamage = 0;
        itemToAdd.ArmourMulti = 0;
        itemToAdd.EleResist = 0;
        itemToAdd.Regen = 0;
        itemToAdd.Rarity = 1;
        itemToAdd.Value = 10;
        itemToAdd.Title = "Sharp Starter Sword";
        itemToAdd.Description = "A gift to begin your adventure";
        inv.AddItem(itemToAdd);
    }
}
