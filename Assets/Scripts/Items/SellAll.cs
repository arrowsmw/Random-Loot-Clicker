using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellAll : MonoBehaviour {

    private Inventory inv;
    private GlobalStats stats;
    public UnityEngine.UI.Toggle common;
    public UnityEngine.UI.Toggle rare;
    public UnityEngine.UI.Toggle epic;
    public UnityEngine.UI.Toggle legendary;


	void Start ()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        stats = GameObject.Find("StatsController").GetComponent<GlobalStats>();
	}

    public void OnClicked()
    {

        for (int i = 0; i < inv.items.Count; i++)
        {
            if (inv.items[i].ID != -1 && inv.items[i].Locked == false)
            {
                switch(inv.items[i].Rarity)
                {
                    case 1:
                        if(common.isOn)
                        {
                            inv.capacity -= 1;
                            stats.gold += inv.items[i].Value;
                            ItemData data = inv.slots[i].transform.GetChild(0).GetComponent<ItemData>();
                            Destroy(data.gameObject);
                            inv.items[i] = new Item();
                        }
                        break;
                    case 2:
                        if(rare.isOn)
                        {
                            inv.capacity -= 1;
                            stats.gold += inv.items[i].Value;
                            ItemData data = inv.slots[i].transform.GetChild(0).GetComponent<ItemData>();
                            Destroy(data.gameObject);
                            inv.items[i] = new Item();
                        }
                        break;
                    case 3:
                        if(epic.isOn)
                        {
                            inv.capacity -= 1;
                            stats.gold += inv.items[i].Value;
                            ItemData data = inv.slots[i].transform.GetChild(0).GetComponent<ItemData>();
                            Destroy(data.gameObject);
                            inv.items[i] = new Item();
                        }
                        break;
                    case 4:
                        if(legendary.isOn)
                        {
                            inv.capacity -= 1;
                            stats.gold += inv.items[i].Value;
                            ItemData data = inv.slots[i].transform.GetChild(0).GetComponent<ItemData>();
                            Destroy(data.gameObject);
                            inv.items[i] = new Item();
                        }
                        break;
                }
             
                
            }
        }
    }
	
}
