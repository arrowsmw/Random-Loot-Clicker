using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour {
    private Item item;
    private string data;
    private GameObject tooltip;
    private GameObject equippedTooltip;
    private CInventory inv1;
    private CInventory inv2;
    private CInventory inv3;
    private CInventory inv4;
    private PlayerController pControl;
    private GlobalStats glblstats;

    void Start()
    {
        tooltip = GameObject.Find("ToolTip");
        tooltip.SetActive(false);
        equippedTooltip = GameObject.Find("EquippedToolTip");
        inv1 = GameObject.Find("C1Inventory").GetComponent<CInventory>();
        inv2 = GameObject.Find("C2Inventory").GetComponent<CInventory>();
        inv3 = GameObject.Find("C3Inventory").GetComponent<CInventory>();
        inv4 = GameObject.Find("C4Inventory").GetComponent<CInventory>();
        pControl = GameObject.Find("StatsController").GetComponent<PlayerController>();
        glblstats = GameObject.Find("StatsController").GetComponent<GlobalStats>();
        equippedTooltip.SetActive(false);
    }
    
    void Update()
    {
        if (tooltip.activeSelf)
        {
            RectTransform rt = (RectTransform)tooltip.transform;
            if((Input.mousePosition.x + rt.rect.width) >= 800)
            {
                tooltip.transform.position = new Vector3(780 - rt.rect.width, Input.mousePosition.y, Input.mousePosition.z);
            }
            else
            {
                tooltip.transform.position = Input.mousePosition;
            }
            
            
        }
        if (equippedTooltip.activeSelf && tooltip.activeSelf)
        {
            equippedTooltip.transform.position = new Vector3(tooltip.transform.position.x, tooltip.transform.position.y, tooltip.transform.position.z);
        }
        else if (equippedTooltip.activeSelf)
        {
            RectTransform rt = (RectTransform)equippedTooltip.transform;
            if((Input.mousePosition.x - rt.rect.width) <= 0)
            {
                if(Input.mousePosition.y - rt.rect.height <= 0)
                {
                    equippedTooltip.transform.position = new Vector3(20 + rt.rect.width, 20 + rt.rect.height, Input.mousePosition.z);
                }
                else
                {
                    equippedTooltip.transform.position = new Vector3(20 + rt.rect.width, Input.mousePosition.y, Input.mousePosition.z);
                }
                
            }
            else if(Input.mousePosition.y - rt.rect.height <= 0)
            {
                equippedTooltip.transform.position = new Vector3(Input.mousePosition.x, 20 + rt.rect.height, Input.mousePosition.z);
            }
            else
            {
                equippedTooltip.transform.position = Input.mousePosition;
            }
            
        }
    }

	public void Activate(Item item)
    {
        this.item = item;
        if(item.Equipped == false)
        {
            ConstructDataString();
            tooltip.SetActive(true);
        }
        else
        {
            ConstructEquippedDataString();
            equippedTooltip.SetActive(true);
        }        
    }

    public void ActivateComparison(Item item)
    {
        this.item = item;
        ConstructComparisonDataString();
        tooltip.SetActive(true);
    }

    public void Deactivate()
    {
        
        equippedTooltip.SetActive(false);
        tooltip.SetActive(false);
        
        
    }

    public void ConstructDataString()
    {
        string color ="";
        string stats ="";
        string level ="";
        if(item.Power != 0)
        {
            stats = "\n\nPower: " + item.Power;
        }
        else if(item.Armour != 0)
        {
            stats = "\n\nArmour: " + item.Armour;
        }

        stats += "\n\n<color=#2AA1F6FF>";
        if(item.DamageMulti != 0)
        {
            stats += "Damage increased by: " + pControl.ValueIntoString(item.DamageMulti, false) + "%\n";
        }
        if(item.CritChance != 0)
        {
            stats += "Crit chance increase by: " + item.CritChance + "%\n";
        }
        if(item.CritDamage != 0)
        {
            stats += "Crit damage increased by: " + item.CritDamage + "%\n";
        }
        if(item.Regen != 0)
        {
            stats += "Health Regen increased by: " + pControl.ValueIntoString(item.Regen, false) + "\n";
        }
        if(item.ArmourMulti != 0)
        {
            stats += "Armour increase by: " + pControl.ValueIntoString(item.ArmourMulti, false) + "%\n";
        }
        if(item.EleResist != 0)
        {
            stats += "Elemental resistance increased by: " + item.EleResist + "%\n";
        }
        stats += "</color>";

        switch (item.Rarity)
        {
            case 1:
                color = "#3BEA60FF";
                break;
            case 2:
                color = "#3224E7FF";
                break;
            case 3:
                color = "#93009CFF";
                break;
            case 4:
                color = "#FF8502FF";
                break;
        }

        if(item.Level > glblstats.playerLevel)
        {
            level = "<color=#FF0000FF>\nLevel: " + item.Level + " </color>";
        }
        else
        {
            level = "<color=#FFFFFFFF>\nLevel: " + item.Level + " </color>";
        }

        data = "<color=" + color + "><b>" + item.Title + "</b></color>\n" + item.Description + stats + level + "\n<color=#DFEC00FF>Sells for: " + pControl.ValueIntoString(item.Value, false) + " gold</color>";
        item.TooltipDesc = data;
        tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
        
    }

    public void ConstructEquippedDataString()
    {
        string color = "";
        string stats = "";
        string level = "";

        if (item.Power != 0)
        {
            stats = "\n\nPower: " + item.Power;
        }
        else if (item.Armour != 0)
        {
            stats = "\n\nArmour: " + item.Armour;
        }

        stats += "\n\n<color=#2AA1F6FF>";
        if (item.DamageMulti != 0)
        {
            stats += "Damage increased by: " + pControl.ValueIntoString(item.DamageMulti, false) + "%\n";
        }
        if (item.CritChance != 0)
        {
            stats += "Crit chance increase by: " + item.CritChance + "%\n";
        }
        if (item.CritDamage != 0)
        {
            stats += "Crit damage increased by: " + item.CritDamage + "%\n";
        }
        if (item.Regen != 0)
        {
            stats += "Health Regen increased by: " + pControl.ValueIntoString(item.Regen, false) + "\n";
        }
        if (item.ArmourMulti != 0)
        {
            stats += "Armour increase by: " + pControl.ValueIntoString(item.ArmourMulti, false) + "%\n";
        }
        if (item.EleResist != 0)
        {
            stats += "Elemental resistance increased by: " + item.EleResist + "%\n";
        }
        stats += "</color>";

        switch (item.Rarity)
        {
            case 1:
                color = "#3BEA60FF";
                break;
            case 2:
                color = "#3224E7FF";
                break;
            case 3:
                color = "#93009CFF";
                break;
            case 4:
                color = "#FF8502FF";
                break;
        }

        if (item.Level > glblstats.playerLevel)
        {
            level = "<color=#FF0000FF>\nLevel: " + item.Level + " </color>";
        }
        else
        {
            level = "<color=#FFFFFFFF>\nLevel: " + item.Level + " </color>";
        }

        data = "<b>Equipped</b>" + "\n<color=" + color + "><b>" + item.Title + "</b></color>\n" + item.Description + stats + level + "\n<color=#DFEC00FF>Sells for: " + pControl.ValueIntoString(item.Value, false) + " gold</color>";
        equippedTooltip.transform.GetChild(0).GetComponent<Text>().text = data;

    }

    public void ConstructComparisonDataString()
    {
        string color = "";
        string stats = "";
        string level = "";

        if (item.Power != 0)
        {
            stats = "\n\nPower: " + item.Power;
        }
        else if (item.Armour != 0)
        {
            stats = "\n\nArmour: " + item.Armour;
        }

        stats += "\n\n<color=#2AA1F6FF>";
        if (item.DamageMulti != 0)
        {
            stats += "Damage increased by: " + pControl.ValueIntoString(item.DamageMulti, false) + "%\n";
        }
        if (item.CritChance != 0)
        {
            stats += "Crit chance increase by: " + item.CritChance + "%\n";
        }
        if (item.CritDamage != 0)
        {
            stats += "Crit damage increased by: " + item.CritDamage + "%\n";
        }
        if (item.Regen != 0)
        {
            stats += "Health Regen increased by: " + pControl.ValueIntoString(item.Regen, false) + "\n";
        }
        if (item.ArmourMulti != 0)
        {
            stats += "Armour increase by: " + pControl.ValueIntoString(item.ArmourMulti, false) + "%\n";
        }
        if (item.EleResist != 0)
        {
            stats += "Elemental resistance increased by: " + item.EleResist + "%\n";
        }
        stats += "</color>";

        switch (item.Rarity)
        {
            case 1:
                color = "#3BEA60FF";
                break;
            case 2:
                color = "#3224E7FF";
                break;
            case 3:
                color = "#93009CFF";
                break;
            case 4:
                color = "#FF8502FF";
                break;
        }

        string comparison = "";

        if(pControl.playerActive[1] == true)
        {
            comparison += pControl.ItemComparison(inv1.items[item.ID], item, 1);
        }
        else if(pControl.playerActive[2] == true)
        {
            comparison += pControl.ItemComparison(inv2.items[item.ID], item, 2);

        }
        else if(pControl.playerActive[3] == true)
        {
            comparison += pControl.ItemComparison(inv3.items[item.ID], item, 3);
        }
        else if(pControl.playerActive[4] == true)
        {
            comparison += pControl.ItemComparison(inv4.items[item.ID], item, 4);
        }

        if (item.Level > glblstats.playerLevel)
        {
            level = "<color=#FF0000FF>\nLevel: " + item.Level + " </color>";
        }
        else
        {
            level = "<color=#FFFFFFFF>\nLevel: " + item.Level + " </color>";
        }

        data = "<color=" + color + "><b>" + item.Title + "</b></color>\n" + item.Description + stats + level + "\n<color=#DFEC00FF>Sells for: " + pControl.ValueIntoString(item.Value, false) + " gold</color>";

        if(comparison != "")
        {
            data += "\n\nEquipping this will give you: \n\n" + comparison;
        }
        else
        {
            data += "\n\nEquipping this will give you no stat changes.\n\n";
        }
        tooltip.transform.GetChild(0).GetComponent<Text>().text = data;

    }
}
