using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour {
    private Item item;
    private string data;
    private GameObject tooltip;
    private GameObject equippedTooltip;
    private C1Inventory inv1;
    private C2Inventory inv2;
    private C3Inventory inv3;
    private C4Inventory inv4;
    private Player1Stats p1stats;
    private Player2Stats p2stats;
    private Player3Stats p3stats;
    private Player4Stats p4stats;
    private PlayerController pcontrol;

    void Start()
    {
        tooltip = GameObject.Find("ToolTip");
        tooltip.SetActive(false);
        equippedTooltip = GameObject.Find("EquippedToolTip");
        inv1 = GameObject.Find("C1Inventory").GetComponent<C1Inventory>();
        inv2 = GameObject.Find("C2Inventory").GetComponent<C2Inventory>();
        inv3 = GameObject.Find("C3Inventory").GetComponent<C3Inventory>();
        inv4 = GameObject.Find("C4Inventory").GetComponent<C4Inventory>();
        p1stats = GameObject.Find("P1Stats").GetComponent<Player1Stats>();
        p2stats = GameObject.Find("P2Stats").GetComponent<Player2Stats>();
        p3stats = GameObject.Find("P3Stats").GetComponent<Player3Stats>();
        p4stats = GameObject.Find("P4Stats").GetComponent<Player4Stats>();
        pcontrol = GameObject.Find("StatsController").GetComponent<PlayerController>();
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
            if (item.TooltipDesc == "empty")
            {
                ConstructDataString();
            }
            else
            {
                tooltip.transform.GetChild(0).GetComponent<Text>().text = item.TooltipDesc;
            }
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
            stats += "Damage increased by: " + pcontrol.ValueIntoString(item.DamageMulti, false) + "%\n";
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
            stats += "Health Regen increased by: " + pcontrol.ValueIntoString(item.Regen, false) + "\n";
        }
        if(item.ArmourMulti != 0)
        {
            stats += "Armour increase by: " + pcontrol.ValueIntoString(item.ArmourMulti, false) + "%\n";
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
        data = "<color=" + color + "><b>" + item.Title + "</b></color>\n" + item.Description + stats + "Level: " + item.Level + "\n<color=#DFEC00FF>Sells for: " + pcontrol.ValueIntoString(item.Value, false) + " gold</color>";
        item.TooltipDesc = data;
        tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
        
    }

    public void ConstructEquippedDataString()
    {
        string color = "";
        string stats = "";

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
            stats += "Damage increased by: " + pcontrol.ValueIntoString(item.DamageMulti, false) + "%\n";
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
            stats += "Health Regen increased by: " + pcontrol.ValueIntoString(item.Regen, false) + "\n";
        }
        if (item.ArmourMulti != 0)
        {
            stats += "Armour increase by: " + pcontrol.ValueIntoString(item.ArmourMulti, false) + "%\n";
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
        data = "<b>Equipped</b>" + "\n<color=" + color + "><b>" + item.Title + "</b></color>\n" + item.Description + stats + "\nLevel: " + item.Level + "\n<color=#DFEC00FF>Sells for: " + pcontrol.ValueIntoString(item.Value, false) + " gold</color>";
        equippedTooltip.transform.GetChild(0).GetComponent<Text>().text = data;

    }

    public void ConstructComparisonDataString()
    {
        string color = "";
        string stats = "";

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
            stats += "Damage increased by: " + pcontrol.ValueIntoString(item.DamageMulti, false) + "%\n";
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
            stats += "Health Regen increased by: " + pcontrol.ValueIntoString(item.Regen, false) + "\n";
        }
        if (item.ArmourMulti != 0)
        {
            stats += "Armour increase by: " + pcontrol.ValueIntoString(item.ArmourMulti, false) + "%\n";
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

        if(p1stats.active == true)
        {
            comparison += pcontrol.ItemComparison(inv1.items[item.ID], item, 1);
        }
        else if(p2stats.active == true)
        {
            comparison += pcontrol.ItemComparison(inv2.items[item.ID], item, 2);

        }
        else if(p3stats.active == true)
        {
            comparison += pcontrol.ItemComparison(inv3.items[item.ID], item, 3);
        }
        else if(p4stats.active == true)
        {
            comparison += pcontrol.ItemComparison(inv4.items[item.ID], item, 4);
        }

        data = "<color=" + color + "><b>" + item.Title + "</b></color>\n" + item.Description + stats + "\nLevel: " + item.Level + "\n<color=#DFEC00FF>Sells for: " + pcontrol.ValueIntoString(item.Value, false) + " gold</color>";

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
