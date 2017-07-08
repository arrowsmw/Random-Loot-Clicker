using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private UnityEngine.UI.Text player1Stats;
    private UnityEngine.UI.Text player2Stats;
    private UnityEngine.UI.Text player3Stats;
    private UnityEngine.UI.Text player4Stats;
    private GlobalStats glblstats;
    public List<double> p1stats = new List<double>();
    public List<double> p2stats = new List<double>();
    public List<double> p3stats = new List<double>();
    public List<double> p4stats = new List<double>();
    public List<bool> playerCreated = new List<bool>();
    public List<bool> playerActive = new List<bool>();
    string p1statString;
    string p2statString;
    string p3statString;
    string p4statString;

    void Start()
    {
        glblstats = GameObject.Find("StatsController").GetComponent<GlobalStats>();
        player1Stats = GameObject.Find("P1Stats").GetComponent<Text>();
        player2Stats = GameObject.Find("P2Stats").GetComponent<Text>();
        player3Stats = GameObject.Find("P3Stats").GetComponent<Text>();
        player4Stats = GameObject.Find("P4Stats").GetComponent<Text>();

        p1statString = "";
        p2statString = "";
        p3statString = "";
        p4statString = "";

        //0 Health | 1 Damage | 2 Defense | 3 Power | 4 Amour 
        //5 DamageMulti | 6 Crit Chance | 7 Crit Damage
        //8 Health Regen | 9 ArmourMulti | 10 Elemental Resistance 
        //11 CurHealth
        for (int i = 0; i< 12; i++)
        {
            p1stats.Add(0);
            p2stats.Add(0);
            p3stats.Add(0);
            p4stats.Add(0);
        }

        p1stats[7] = 150;
        p2stats[7] = 150;
        p3stats[7] = 150;
        p4stats[7] = 150;

        p1stats[6] = 5;
        p2stats[6] = 5;
        p3stats[6] = 5;
        p4stats[6] = 5;

        p1statString = updateString(1);
        player1Stats.text = p1statString;
        p2statString = updateString(2);
        p3statString = updateString(3);
        p4statString = updateString(4);

        for(int i = 0; i<5; i++)
        {
            playerCreated.Add(false);
            playerActive.Add(false);
        }
    }

    void Update()
    {

    }

    public string updateString(int player)
    {
        string statString = "";

        switch(player)
        {
            case 1:
                statString += "<size=16><color=#FF0000FF>Damage: " + ValueIntoString(p1stats[1], true) + "</color></size>" + 
                    "<size=16><color=#2AA1F6FF>\nDefense: " + ValueIntoString(p1stats[2], true) + "</color></size>" + "\n\n<size=12>Damage increase: " + ValueIntoString(p1stats[5], false) + "%" + 
                    "\nCrit Chance: " + p1stats[6] + "%" + "\nCrit Damage: " + p1stats[7] + "%" + "\nHealth Regen: " + ValueIntoString(p1stats[8], false) + "/s" + 
                    "\nAmour increase: "+ ValueIntoString(p1stats[9], false) + "%";
                if(p1stats[10] > 75)
                {
                    statString += "\nElemental Resistance: 75%</size>";
                }
                else
                {
                    statString += "\nElemental Resistance: " + p1stats[10] + "%</size>";
                }
                break;
            case 2:
                statString += "<size=16><color=#FF0000FF>Damage: " + ValueIntoString(p2stats[1], true) + "</color></size>" +
                    "<size=16><color=#2AA1F6FF>\nDefense: " + ValueIntoString(p2stats[2], true) + "</color></size>" + "\n\n<size=12>Damage increase: " + ValueIntoString(p2stats[5], false) + "%" +
                    "\nCrit Chance: " + p2stats[6] + "%" + "\nCrit Damage: " + p2stats[7] + "%" + "\nHealth Regen: " + ValueIntoString(p2stats[8], false) + "/s" +
                    "\nAmour increase: " + ValueIntoString(p2stats[9], false) + "%";
                if (p2stats[10] > 75)
                {
                    statString += "\nElemental Resistance: 75%</size>";
                }
                else
                {
                    statString += "\nElemental Resistance: " + p2stats[10] + "%</size>";
                }
                break;
            case 3:
                statString += "<size=16><color=#FF0000FF>Damage: " + ValueIntoString(p3stats[1], true) + "</color></size>" +
                    "<size=16><color=#2AA1F6FF>\nDefense: " + ValueIntoString(p3stats[2], true) + "</color></size>" + "\n\n<size=12>Damage increase: " + ValueIntoString(p3stats[5], false) + "%" +
                    "\nCrit Chance: " + p3stats[6] + "%" + "\nCrit Damage: " + p3stats[7] + "%" + "\nHealth Regen: " + ValueIntoString(p3stats[8], false) + "/s" +
                    "\nAmour increase: " + ValueIntoString(p3stats[9], false) + "%";
                if (p3stats[10] > 75)
                {
                    statString += "\nElemental Resistance: 75%</size>";
                }
                else
                {
                    statString += "\nElemental Resistance: " + p3stats[10] + "%</size>";
                }
                break;
            case 4:
                statString += "<size=16><color=#FF0000FF>Damage: " + ValueIntoString(p4stats[1], true) + "</color></size>" +
                    "<size=16><color=#2AA1F6FF>\nDefense: " + ValueIntoString(p4stats[2], true) + "</color></size>" + "\n\n<size=12>Damage increase: " + ValueIntoString(p4stats[5], false) + "%" +
                    "\nCrit Chance: " + p4stats[6] + "%" + "\nCrit Damage: " + p4stats[7] + "%" + "\nHealth Regen: " + ValueIntoString(p4stats[8], false) + "/s" +
                    "\nAmour increase: " + ValueIntoString(p4stats[9], false) + "%";
                if (p4stats[10] > 75)
                {
                    statString += "\nElemental Resistance: 75%</size>";
                }
                else
                {
                    statString += "\nElemental Resistance: " + p4stats[10] + "%</size>";
                }
                break;
        }
        return statString;
    }

    public void addStats(Item item, int player)
    {
        switch(player)
        {
            case 1:
                p1stats[3] += item.Power;
                p1stats[4] += item.Armour;
                p1stats[5] += item.DamageMulti;
                p1stats[6] += item.CritChance;
                p1stats[7] += item.CritDamage;
                p1stats[8] += item.Regen;
                p1stats[9] += item.ArmourMulti;
                p1stats[10] += item.EleResist;
                p1stats[1] = (p1stats[3] * (1 + (p1stats[5] / 100))) * (1 + ((p1stats[6] / 100) * ((p1stats[7] / 100) - 1)));
                p1stats[2] = (p1stats[4] * (1 + (p1stats[9] / 100)));
                p1statString = updateString(1);
                player1Stats.text = p1statString;
                break;
            case 2:
                p2stats[3] += item.Power;
                p2stats[4] += item.Armour;
                p2stats[5] += item.DamageMulti;
                p2stats[6] += item.CritChance;
                p2stats[7] += item.CritDamage;
                p2stats[8] += item.Regen;
                p2stats[9] += item.ArmourMulti;
                p2stats[10] += item.EleResist;
                p2stats[1] = (p2stats[3] * (1 + (p2stats[5] / 100))) * (1 + ((p2stats[6] / 100) * ((p2stats[7] / 100) - 1)));
                p2stats[2] = (p2stats[4] * (1 + (p2stats[9] / 100)));
                p2statString = updateString(2);
                player2Stats.text = p2statString;
                break;
            case 3:
                p3stats[3] += item.Power;
                p3stats[4] += item.Armour;
                p3stats[5] += item.DamageMulti;
                p3stats[6] += item.CritChance;
                p3stats[7] += item.CritDamage;
                p3stats[8] += item.Regen;
                p3stats[9] += item.ArmourMulti;
                p3stats[10] += item.EleResist;
                p3stats[1] = (p3stats[3] * (1 + (p3stats[5] / 100))) * (1 + ((p3stats[6] / 100) * ((p3stats[7] / 100) - 1)));
                p3stats[2] = (p3stats[4] * (1 + (p3stats[9] / 100)));
                p3statString = updateString(3);
                player3Stats.text = p3statString;
                break;
            case 4:
                p4stats[3] += item.Power;
                p4stats[4] += item.Armour;
                p4stats[5] += item.DamageMulti;
                p4stats[6] += item.CritChance;
                p4stats[7] += item.CritDamage;
                p4stats[8] += item.Regen;
                p4stats[9] += item.ArmourMulti;
                p4stats[10] += item.EleResist;
                p4stats[1] = (p4stats[3] * (1 + (p4stats[5] / 100))) * (1 + ((p4stats[6] / 100) * ((p4stats[7] / 100) - 1)));
                p4stats[2] = (p4stats[4] * (1 + (p4stats[9] / 100)));
                p4statString = updateString(4);
                player4Stats.text = p4statString;
                break;
        }
    }

    public void removeStats(Item item, int player)
    {
        switch (player)
        {
            case 1:
                p1stats[3] -= item.Power;
                p1stats[4] -= item.Armour;
                p1stats[5] -= item.DamageMulti;
                p1stats[6] -= item.CritChance;
                p1stats[7] -= item.CritDamage;
                p1stats[8] -= item.Regen;
                p1stats[9] -= item.ArmourMulti;
                p1stats[10] -= item.EleResist;
                p1stats[1] = (p1stats[3] * (1 + (p1stats[5] / 100))) * (1 + ((p1stats[6] / 100) * ((p1stats[7] / 100) - 1)));
                p1stats[2] = (p1stats[4] * (1 + (p1stats[9] / 100)));
                p1statString = updateString(1);
                player1Stats.text = p1statString;
                break;
            case 2:
                p2stats[3] -= item.Power;
                p2stats[4] -= item.Armour;
                p2stats[5] -= item.DamageMulti;
                p2stats[6] -= item.CritChance;
                p2stats[7] -= item.CritDamage;
                p2stats[8] -= item.Regen;
                p2stats[9] -= item.ArmourMulti;
                p2stats[10] -= item.EleResist;
                p2stats[1] = (p2stats[3] * (1 + (p2stats[5] / 100))) * (1 + ((p2stats[6] / 100) * ((p2stats[7] / 100) - 1)));
                p2stats[2] = (p2stats[4] * (1 + (p2stats[9] / 100)));
                p2statString = updateString(2);
                player2Stats.text = p2statString;
                break;
            case 3:
                p3stats[3] -= item.Power;
                p3stats[4] -= item.Armour;
                p3stats[5] -= item.DamageMulti;
                p3stats[6] -= item.CritChance;
                p3stats[7] -= item.CritDamage;
                p3stats[8] -= item.Regen;
                p3stats[9] -= item.ArmourMulti;
                p3stats[10] -= item.EleResist;
                p3stats[1] = (p3stats[3] * (1 + (p3stats[5] / 100))) * (1 + ((p3stats[6] / 100) * ((p3stats[7] / 100) - 1)));
                p3stats[2] = (p3stats[4] * (1 + (p3stats[9] / 100)));
                p3statString = updateString(3);
                player3Stats.text = p3statString;
                break;
            case 4:
                p4stats[3] -= item.Power;
                p4stats[4] -= item.Armour;
                p4stats[5] -= item.DamageMulti;
                p4stats[6] -= item.CritChance;
                p4stats[7] -= item.CritDamage;
                p4stats[8] -= item.Regen;
                p4stats[9] -= item.ArmourMulti;
                p4stats[10] -= item.EleResist;
                p4stats[1] = (p4stats[3] * (1 + (p4stats[5] / 100))) * (1 + ((p4stats[6] / 100) * ((p4stats[7] / 100) - 1)));
                p4stats[2] = (p4stats[4] * (1 + (p4stats[9] / 100)));
                p4statString = updateString(4);
                player4Stats.text = p4statString;
                break;
        }
    }

    public void levelUp()
    {
        p1stats[0] = 100 * (Mathf.Pow(1.2f, glblstats.playerLevel - 1));
        p1stats[11] = p1stats[0];

        p2stats[0] = 100 * (Mathf.Pow(1.2f, glblstats.playerLevel - 1));
        p2stats[11] = p2stats[0];

        p3stats[0] = 100 * (Mathf.Pow(1.2f, glblstats.playerLevel - 1));
        p3stats[11] = p3stats[0];

        p4stats[0] = 100 * (Mathf.Pow(1.2f, glblstats.playerLevel - 1));
        p4stats[11] = p4stats[0];
    }

    public string ItemComparison(Item equippedItem, Item itemToEquip, int player)
    {
        string comparisonString = "";
        double newDamage;
        double newDefense;

        switch(player)
        {
            case 1:
                


                newDamage = (((p1stats[3] - equippedItem.Power) + itemToEquip.Power) * (1 + (((p1stats[5] - equippedItem.DamageMulti) + itemToEquip.DamageMulti)/100))) * 
                    (1 + ((((p1stats[6] - equippedItem.CritChance) + itemToEquip.CritChance) / 100) * ((((p1stats[7] - equippedItem.CritDamage) + itemToEquip.CritDamage) / 100) - 1)));
                if (newDamage > p1stats[1])
                {
                    comparisonString += "<color=#2AA1F6FF>Damage </color><color=#00FF41FF>+ " + ValueIntoString(Mathf.Abs((float)newDamage - (float)p1stats[1]), true) + "</color>\n";
                }
                else if(newDamage < p1stats[1])
                {
                    comparisonString += "<color=#2AA1F6FF>Damage </color><color=#FF0000FF>- " + ValueIntoString(Mathf.Abs((float)newDamage - (float)p1stats[1]), true) + "</color>\n";
                }

                newDefense = (((p1stats[4] - equippedItem.Armour) + itemToEquip.Armour) * (1 + (((p1stats[9] - equippedItem.ArmourMulti) + itemToEquip.ArmourMulti) / 100)));
                if(newDefense > p1stats[2])
                {
                    comparisonString += "<color=#2AA1F6FF>Defense </color><color=#00FF41FF>+ " + ValueIntoString(Mathf.Abs((float)newDefense - (float)p1stats[2]), true) + "</color>\n";
                }
                else if(newDefense < p1stats[2])
                {
                    comparisonString += "<color=#2AA1F6FF>Defense </color><color=#FF0000FF>- " + ValueIntoString(Mathf.Abs((float)newDefense - (float)p1stats[2]), true) + "</color>\n";
                }

                if(itemToEquip.Regen > equippedItem.Regen)
                {
                    comparisonString += "<color=#2AA1F6FF>Health Regen </color><color=#00FF41FF>+ " + ValueIntoString(Mathf.Abs((float)itemToEquip.Regen - (float)equippedItem.Regen), false) + "</color>\n";
                }
                else if(itemToEquip.Regen < equippedItem.Regen)
                {
                    comparisonString += "<color=#2AA1F6FF>Health Regen </color><color=#FF0000FF>- " + ValueIntoString(Mathf.Abs((float)itemToEquip.Regen - (float)equippedItem.Regen), false) + "</color>\n";
                }

                if(itemToEquip.EleResist > equippedItem.EleResist)
                {
                    comparisonString += "<color=#2AA1F6FF>Elemental Resistance </color><color=#00FF41FF>+ " + ValueIntoString(Mathf.Abs((float)itemToEquip.EleResist - (float)equippedItem.EleResist), false) + "</color>\n";
                }
                else if(itemToEquip.EleResist < equippedItem.EleResist)
                {
                    comparisonString += "<color=#2AA1F6FF>Elemental Resistance </color><color=#FF0000FF>- " + ValueIntoString(Mathf.Abs((float)itemToEquip.EleResist - (float)equippedItem.EleResist), false) + "</color>\n";
                }
                break;
            case 2:
                newDamage = (((p2stats[3] - equippedItem.Power) + itemToEquip.Power) * (1 + (((p2stats[5] - equippedItem.DamageMulti) + itemToEquip.DamageMulti) / 100))) *
                   (1 + ((((p2stats[6] - equippedItem.CritChance) + itemToEquip.CritChance) / 100) * ((((p2stats[7] - equippedItem.CritDamage) + itemToEquip.CritDamage) / 100) - 1)));
                if (newDamage > p2stats[1])
                {
                    comparisonString += "<color=#2AA1F6FF>Damage </color><color=#00FF41FF>+ " + ValueIntoString(Mathf.Abs((float)newDamage - (float)p2stats[1]), true) + "</color>\n";
                }
                else if (newDamage < p2stats[1])
                {
                    comparisonString += "<color=#2AA1F6FF>Damage </color><color=#FF0000FF>- " + ValueIntoString(Mathf.Abs((float)newDamage - (float)p2stats[1]), true) + "</color>\n";
                }

                newDefense = (((p2stats[4] - equippedItem.Armour) + itemToEquip.Armour) * (1 + (((p2stats[9] - equippedItem.ArmourMulti) + itemToEquip.ArmourMulti) / 100)));
                if (newDefense > p2stats[2])
                {
                    comparisonString += "<color=#2AA1F6FF>Defense </color><color=#00FF41FF>+ " + ValueIntoString(Mathf.Abs((float)newDefense - (float)p2stats[2]), true) + "</color>\n";
                }
                else if (newDefense < p2stats[2])
                {
                    comparisonString += "<color=#2AA1F6FF>Defense </color><color=#FF0000FF>- " + ValueIntoString(Mathf.Abs((float)newDefense - (float)p2stats[2]), true) + "</color>\n";
                }

                if (itemToEquip.Regen > equippedItem.Regen)
                {
                    comparisonString += "<color=#2AA1F6FF>Health Regen </color><color=#00FF41FF>+ " + ValueIntoString(Mathf.Abs((float)itemToEquip.Regen - (float)equippedItem.Regen), false) + "</color>\n";
                }
                else if (itemToEquip.Regen < equippedItem.Regen)
                {
                    comparisonString += "<color=#2AA1F6FF>Health Regen </color><color=#FF0000FF>- " + ValueIntoString(Mathf.Abs((float)itemToEquip.Regen - (float)equippedItem.Regen), false) + "</color>\n";
                }

                if (itemToEquip.EleResist > equippedItem.EleResist)
                {
                    comparisonString += "<color=#2AA1F6FF>Elemental Resistance </color><color=#00FF41FF>+ " + ValueIntoString(Mathf.Abs((float)itemToEquip.EleResist - (float)equippedItem.EleResist), false) + "</color>\n";
                }
                else if (itemToEquip.EleResist < equippedItem.EleResist)
                {
                    comparisonString += "<color=#2AA1F6FF>Elemental Resistance </color><color=#FF0000FF>- " + ValueIntoString(Mathf.Abs((float)itemToEquip.EleResist - (float)equippedItem.EleResist), false) + "</color>\n";
                }
                break;
            case 3:
                newDamage = (((p3stats[3] - equippedItem.Power) + itemToEquip.Power) * (1 + (((p3stats[5] - equippedItem.DamageMulti) + itemToEquip.DamageMulti) / 100))) *
                   (1 + ((((p3stats[6] - equippedItem.CritChance) + itemToEquip.CritChance) / 100) * ((((p3stats[7] - equippedItem.CritDamage) + itemToEquip.CritDamage) / 100) - 1)));
                if (newDamage > p3stats[1])
                {
                    comparisonString += "<color=#2AA1F6FF>Damage </color><color=#00FF41FF>+ " + ValueIntoString(Mathf.Abs((float)newDamage - (float)p3stats[1]), true) + "</color>\n";
                }
                else if (newDamage < p3stats[1])
                {
                    comparisonString += "<color=#2AA1F6FF>Damage </color><color=#FF0000FF>- " + ValueIntoString(Mathf.Abs((float)newDamage - (float)p3stats[1]), true) + "</color>\n";
                }

                newDefense = (((p3stats[4] - equippedItem.Armour) + itemToEquip.Armour) * (1 + (((p3stats[9] - equippedItem.ArmourMulti) + itemToEquip.ArmourMulti) / 100)));
                if (newDefense > p3stats[2])
                {
                    comparisonString += "<color=#2AA1F6FF>Defense </color><color=#00FF41FF>+ " + ValueIntoString(Mathf.Abs((float)newDefense - (float)p3stats[2]), true) + "</color>\n";
                }
                else if (newDefense < p3stats[2])
                {
                    comparisonString += "<color=#2AA1F6FF>Defense </color><color=#FF0000FF>- " + ValueIntoString(Mathf.Abs((float)newDefense - (float)p3stats[2]), true) + "</color>\n";
                }

                if (itemToEquip.Regen > equippedItem.Regen)
                {
                    comparisonString += "<color=#2AA1F6FF>Health Regen </color><color=#00FF41FF>+ " + ValueIntoString(Mathf.Abs((float)itemToEquip.Regen - (float)equippedItem.Regen), false) + "</color>\n";
                }
                else if (itemToEquip.Regen < equippedItem.Regen)
                {
                    comparisonString += "<color=#2AA1F6FF>Health Regen </color><color=#FF0000FF>- " + ValueIntoString(Mathf.Abs((float)itemToEquip.Regen - (float)equippedItem.Regen), false) + "</color>\n";
                }

                if (itemToEquip.EleResist > equippedItem.EleResist)
                {
                    comparisonString += "<color=#2AA1F6FF>Elemental Resistance </color><color=#00FF41FF>+ " + ValueIntoString(Mathf.Abs((float)itemToEquip.EleResist - (float)equippedItem.EleResist), false) + "</color>\n";
                }
                else if (itemToEquip.EleResist < equippedItem.EleResist)
                {
                    comparisonString += "<color=#2AA1F6FF>Elemental Resistance </color><color=#FF0000FF>- " + ValueIntoString(Mathf.Abs((float)itemToEquip.EleResist - (float)equippedItem.EleResist), false) + "</color>\n";
                }
                break;
            case 4:
                newDamage = (((p4stats[3] - equippedItem.Power) + itemToEquip.Power) * (1 + (((p4stats[5] - equippedItem.DamageMulti) + itemToEquip.DamageMulti) / 100))) *
                   (1 + ((((p4stats[6] - equippedItem.CritChance) + itemToEquip.CritChance) / 100) * ((((p4stats[7] - equippedItem.CritDamage) + itemToEquip.CritDamage) / 100) - 1)));
                if (newDamage > p4stats[1])
                {
                    comparisonString += "<color=#2AA1F6FF>Damage </color><color=#00FF41FF>+ " + ValueIntoString(Mathf.Abs((float)newDamage - (float)p4stats[1]), true) + "</color>\n";
                }
                else if (newDamage < p4stats[1])
                {
                    comparisonString += "<color=#2AA1F6FF>Damage </color><color=#FF0000FF>- " + ValueIntoString(Mathf.Abs((float)newDamage - (float)p4stats[1]), true) + "</color>\n";
                }

                newDefense = (((p4stats[4] - equippedItem.Armour) + itemToEquip.Armour) * (1 + (((p4stats[9] - equippedItem.ArmourMulti) + itemToEquip.ArmourMulti) / 100)));
                if (newDefense > p4stats[2])
                {
                    comparisonString += "<color=#2AA1F6FF>Defense </color><color=#00FF41FF>+ " + ValueIntoString(Mathf.Abs((float)newDefense - (float)p4stats[2]), true) + "</color>\n";
                }
                else if (newDefense < p4stats[2])
                {
                    comparisonString += "<color=#2AA1F6FF>Defense </color><color=#FF0000FF>- " + ValueIntoString(Mathf.Abs((float)newDefense - (float)p4stats[2]), true) + "</color>\n";
                }

                if (itemToEquip.Regen > equippedItem.Regen)
                {
                    comparisonString += "<color=#2AA1F6FF>Health Regen </color><color=#00FF41FF>+ " + ValueIntoString(Mathf.Abs((float)itemToEquip.Regen - (float)equippedItem.Regen), false) + "</color>\n";
                }
                else if (itemToEquip.Regen < equippedItem.Regen)
                {
                    comparisonString += "<color=#2AA1F6FF>Health Regen </color><color=#FF0000FF>- " + ValueIntoString(Mathf.Abs((float)itemToEquip.Regen - (float)equippedItem.Regen), false) + "</color>\n";
                }

                if (itemToEquip.EleResist > equippedItem.EleResist)
                {
                    comparisonString += "<color=#2AA1F6FF>Elemental Resistance </color><color=#00FF41FF>+ " + ValueIntoString(Mathf.Abs((float)itemToEquip.EleResist - (float)equippedItem.EleResist), false) + "</color>\n";
                }
                else if (itemToEquip.EleResist < equippedItem.EleResist)
                {
                    comparisonString += "<color=#2AA1F6FF>Elemental Resistance </color><color=#FF0000FF>- " + ValueIntoString(Mathf.Abs((float)itemToEquip.EleResist - (float)equippedItem.EleResist), false) + "</color>\n";
                }
                break;
        }


        return comparisonString;
    }
    public string ValueIntoString(double valueToConvert, bool comparison)
    {
        string converted;
        
        if (valueToConvert >= Mathf.Pow(10, 42))
        {
            converted = (valueToConvert / Mathf.Pow(10, 42)).ToString("F3") + "Sp";
        }
        else if (valueToConvert >= Mathf.Pow(10, 36))
        {
            converted = (valueToConvert / Mathf.Pow(10, 36)).ToString("F3") + "Sx";
        }
        else if (valueToConvert >= 1000000000000000000)
        {
            converted = (valueToConvert / 1000000000000000000).ToString("F3") + "Qi";
        }
        else if (valueToConvert >= 1000000000000000)
        {
            converted = (valueToConvert / 1000000000000000).ToString("F3") + "Qa";
        }
        else if(valueToConvert >= 1000000000000)
        {
            converted = (valueToConvert / 1000000000000).ToString("F3") + "T";
        }
        else if(valueToConvert >= 1000000000)
        {
            converted = (valueToConvert / 1000000000).ToString("F3") + "B";
        }
        else if(valueToConvert >= 1000000)
        {
            converted = (valueToConvert / 1000000).ToString("F3") + "M";
        }
        else if(valueToConvert >= 1000)
        {
            converted = (valueToConvert / 1000).ToString("F3") + "K";
        }
        else if(comparison == true)
        {
            converted = "" + valueToConvert.ToString("F3");
        }
        else
        {
            converted = "" + valueToConvert.ToString("F0");
        }

        return converted;
    }
}
