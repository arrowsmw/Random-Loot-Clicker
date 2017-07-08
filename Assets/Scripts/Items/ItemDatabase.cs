using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LitJson;
using System;
using UnityEngine.UI;

public class ItemDatabase : MonoBehaviour {
    private List<Item> database = new List<Item>();
    public JsonData itemData;
    private GlobalStats stats;

    void Start()
    {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        stats = GameObject.Find("StatsController").GetComponent<GlobalStats>();

    }

    public Item FetchItemById(int id)
    {
        for(int i=0; i< database.Count; i++)
            if(database[i].ID == id)
                return database[i];
        return null;
    }

}



public class Item
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Stackable { get; set; }
    public string Slug { get; set; }
    public Sprite Sprite { get; set; }
    public int Rarity { get; set; }
    public int Power { get; set; }
    public int Level { get; set; }
    public double Value { get; set; }
    public bool Equipped { get; set; }
    public bool Locked { get; set; }
    public double Armour { get; set; }
    public double Regen { get; set; }
    public double CritChance { get; set; }
    public double CritDamage { get; set; }
    public double DamageMulti { get; set; }
    public double ArmourMulti { get; set; }
    public double EleResist { get; set; }
    public string TooltipDesc { get; set; }


    public Item(int type, int level)
    {
        ItemDatabase database = GameObject.Find("Inventory").GetComponent<ItemDatabase>();
        this.ID = type;//(int)database.itemData[type]["id"];
        this.Title = database.itemData[type]["title"].ToString();
        this.Description = database.itemData[type]["description"].ToString();
        this.Stackable = (bool)database.itemData[type]["stackable"];
        this.Slug = database.itemData[type]["slug"].ToString();
        this.Sprite = Resources.Load<Sprite>("Items/" + Slug);
        this.Level = level;
        this.Equipped = false;
        this.Locked = false;
        this.TooltipDesc = "empty";

        int rng = UnityEngine.Random.Range(1, 101);
        if(type == 9)
        {
            this.Power = ((15 * level) - 5);
        }
        else if(type >= 0 && type <= 5)
        {
            this.Armour = ((15 * level) - 5);
        }
        if(rng <= 60)
        {
            createCommonItem(level);
        }
        else if(rng > 60 && rng <= 85)
        {
            createRareItem(level);
        }
        else if(rng > 85 && rng <= 95)
        {
            createEpicItem(level);
        }
        else
        {
            createLegendaryItem(level);
        }
    }

    private void createLegendaryItem(int level)
    {
        this.Rarity = 4;
        
        AddFirstPrefix();
        AddFirstSuffix();
        AddNextPrefix();
        AddNextSuffix();
        this.Value = this.Value * (double)(this.Level * Mathf.Pow(1.2f, this.Level - 1));
    }

    private void createEpicItem(int level)
    {
        this.Rarity = 3;
        
        AddFirstPrefix();
        AddFirstSuffix();
        switch(UnityEngine.Random.Range(1, 3))
        {
            case 1:
                AddNextPrefix();
                break;
            case 2:
                AddNextSuffix();
                break;
        }
        this.Value = this.Value * (double)(this.Level * Mathf.Pow(1.2f, this.Level - 1));
    }

    private void createRareItem(int level)
    {
        this.Rarity = 2;
        

        AddFirstPrefix();
        AddFirstSuffix();
        this.Value = this.Value * (double)(this.Level * Mathf.Pow(1.2f, this.Level - 1));
    }

    private void createCommonItem(int level)
    {
        this.Rarity = 1;

        switch(UnityEngine.Random.Range(1, 3))
        {
            case 1:
                AddFirstPrefix();
                break;
            case 2:
                AddFirstSuffix();
                break;
        }
        this.Value = this.Value * (double)(this.Level * Mathf.Pow(1.2f, this.Level - 1));
    }

    private void AddFirstPrefix()
    {
        switch(UnityEngine.Random.Range(1, 4))
        {
            case 1:
                this.Title = "Sharp " + this.Title;
                this.DamageMulti = Mathf.Floor((UnityEngine.Random.Range(5 * Mathf.Pow(1.2f, this.Level-1), 11 * Mathf.Pow(1.2f, this.Level-1))));
                this.Value += (int)((this.Rarity * 25) * ((float)this.DamageMulti / (11 * Mathf.Pow(1.2f, this.Level - 1))));
                break;
            case 2:
                this.Title = "Glinting " + this.Title;
                this.CritChance = (float)UnityEngine.Random.Range(2, 11) / 2;
                this.Value += (int)((this.Rarity * 25) * ((float)this.CritChance / 5));
                break;
            case 3:
                this.Title = "Heavy " + this.Title;
                this.CritDamage = ((UnityEngine.Random.Range(2, 11) / 2) * 10);
                this.Value += (int)((this.Rarity * 25) * ((float)this.CritDamage / 50));
                break;
        }
    }

    private void AddFirstSuffix()
    {
        switch(UnityEngine.Random.Range(1, 4))
        {
            case 1:
                this.Title = this.Title += " of Stamina";
                this.Regen = Mathf.Floor((UnityEngine.Random.Range(1 * Mathf.Pow(1.2f, this.Level - 1), 3 * Mathf.Pow(1.2f, this.Level - 1))));
                this.Value += (int)((this.Rarity * 25) * (this.Regen / (3 * Mathf.Pow(1.2f, this.Level - 1))));
                break;
            case 2:
                this.Title = this.Title += " of Fortitude";
                this.ArmourMulti = Mathf.Floor((UnityEngine.Random.Range(5 * Mathf.Pow(1.2f, this.Level - 1), 11 * Mathf.Pow(1.2f, this.Level - 1))));
                this.Value += (int)(((this.Rarity * 25) * ((float)this.ArmourMulti / (11 * Mathf.Pow(1.2f, this.Level - 1)))));
                break;
            case 3:
                this.Title = this.Title += " of Warding"; 
                this.EleResist = UnityEngine.Random.Range(5, 16);
                this.Value += (int)((this.Rarity * 25) * ((float)this.EleResist / 15));
                break;
        }
    }

    private void AddNextPrefix()
    {
        if(this.DamageMulti > 0)
        {
            switch(UnityEngine.Random.Range(1, 3))
            {
                case 1:
                    this.CritChance = (UnityEngine.Random.Range(2, 11) / 2);
                    this.Value += (int)((this.Rarity * 25) * ((float)this.CritChance / 5));
                    break;
                case 2:
                    this.CritDamage = ((UnityEngine.Random.Range(2, 11) / 2) * 10);
                    this.Value += (int)((this.Rarity * 25) * ((float)this.CritDamage / 50));
                    break;
            }
        }
        else if (this.CritChance > 0)
        {
            switch (UnityEngine.Random.Range(1, 3))
            {
                case 1:
                    this.DamageMulti = Mathf.Floor((UnityEngine.Random.Range(5 * Mathf.Pow(1.2f, this.Level - 1), 11 * Mathf.Pow(1.2f, this.Level - 1))));
                    this.Value += (int)((this.Rarity * 25) * ((float)this.DamageMulti / (11 * Mathf.Pow(1.2f, this.Level - 1))));
                    break;
                case 2:
                    this.CritDamage = ((UnityEngine.Random.Range(2, 11) / 2) * 10);
                    this.Value += (int)((this.Rarity * 25) * ((float)this.CritDamage / 50));
                    break;
            }
        }
        else if (this.CritDamage > 0)
        {
            switch (UnityEngine.Random.Range(1, 3))
            {
                case 1:
                    this.DamageMulti = Mathf.Floor((UnityEngine.Random.Range(5 * Mathf.Pow(1.2f, this.Level - 1), 11 * Mathf.Pow(1.2f, this.Level - 1))));
                    this.Value += (int)((this.Rarity * 25) * ((float)this.DamageMulti / (11 * Mathf.Pow(1.2f, this.Level - 1))));
                    break;
                case 2:
                    this.CritChance = (UnityEngine.Random.Range(2, 11) / 2);
                    this.Value += (int)((this.Rarity * 25) * ((float)this.CritChance / 5));
                    break;
            }
        }
    }

    private void AddNextSuffix()
    {
        if (this.Regen > 0)
        {
            switch (UnityEngine.Random.Range(1, 3))
            {
                case 1:
                    this.ArmourMulti = Mathf.Floor((UnityEngine.Random.Range(5 * Mathf.Pow(1.2f, this.Level - 1), 11 * Mathf.Pow(1.2f, this.Level - 1))));
                    this.Value += (int)(((this.Rarity * 25) * ((float)this.ArmourMulti / (11 * Mathf.Pow(1.2f, this.Level - 1)))));
                    break;
                case 2:
                    this.EleResist = UnityEngine.Random.Range(5, 16);
                    this.Value += (int)((this.Rarity * 25) * ((float)this.EleResist / 15));
                    break;
            }
        }
        else if (this.ArmourMulti > 0)
        {
            switch (UnityEngine.Random.Range(1, 3))
            {
                case 1:
                    this.Regen = Mathf.Floor((UnityEngine.Random.Range(1 * Mathf.Pow(1.2f, this.Level - 1), 3 * Mathf.Pow(1.2f, this.Level - 1))));
                    this.Value += (int)((this.Rarity * 25) * ((float)this.Regen / (3 * Mathf.Pow(1.2f, this.Level - 1))));
                    break;
                case 2:
                    this.EleResist = UnityEngine.Random.Range(5, 16);
                    this.Value += (int)((this.Rarity * 25) * ((float)this.EleResist / 15));
                    break;
            }
        }
        else if (this.EleResist > 0)
        {
            switch (UnityEngine.Random.Range(1, 3))
            {
                case 1:
                    this.Regen = Mathf.Floor((UnityEngine.Random.Range(1 * Mathf.Pow(1.2f, this.Level - 1), 3 * Mathf.Pow(1.2f, this.Level - 1))));
                    this.Value += (int)((this.Rarity * 25) * ((float)this.Regen / (3 * Mathf.Pow(1.2f, this.Level - 1))));
                    break;
                case 2:
                    this.ArmourMulti = Mathf.Floor((UnityEngine.Random.Range(5 * Mathf.Pow(1.2f, this.Level - 1), 11 * Mathf.Pow(1.2f, this.Level - 1))));
                    this.Value += (int)(((this.Rarity * 25) * ((float)this.ArmourMulti / (11 * Mathf.Pow(1.2f, this.Level - 1)))));
                    break;
            }
        }
    }

    public Item()
    {
        this.ID = -1;
        this.Rarity = -1;
        this.Power = -1;
        this.Armour = -1;
        this.DamageMulti = -1;
        this.CritDamage = -1;
        this.CritChance = -1;
        this.ArmourMulti = -1;
        this.Regen = -1;
        this.EleResist = -1;
        this.Value = -1;
    }
}