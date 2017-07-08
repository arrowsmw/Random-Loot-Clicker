using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SortButtons : MonoBehaviour {

    private Inventory inventory;
    public UnityEngine.UI.Dropdown selection;

	void Start ()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        
	}

    public void InsertionSort(List<Item> inv)
    {
        for(int index=1; index<inv.Count; index++)
        {
            int p = index;
            switch (selection.value)
            {
                case 0:
                    while (p != 0 && inv[p].Rarity > inv[p - 1].Rarity)
                    {
                        Swap(inv, p);
                        p -= 1;
                    }
                    break;
                case 1:
                    while (p != 0 && inv[p].ID > inv[p - 1].ID)
                    {
                        Swap(inv, p);
                        p -= 1;
                    }
                    break;
                case 2:
                    while (p != 0 && inv[p].Level > inv[p - 1].Level)
                    {
                        Swap(inv, p);
                        p -= 1;
                    }
                    break;
                case 3:
                    while (p != 0 && inv[p].Armour > inv[p - 1].Armour)
                    {
                        Swap(inv, p);
                        p -= 1;
                    }
                    break;
                case 4:
                    while (p != 0 && inv[p].Power > inv[p - 1].Power)
                    {
                        Swap(inv, p);
                        p -= 1;
                    }
                    break;
                case 5:
                    while (p != 0 && inv[p].DamageMulti > inv[p - 1].DamageMulti)
                    {
                        Swap(inv, p);
                        p -= 1;
                    }
                    break;
                case 6:
                    while (p != 0 && inv[p].CritChance > inv[p - 1].CritChance)
                    {
                        Swap(inv, p);
                        p -= 1;
                    }
                    break;
                case 7:
                    while (p != 0 && inv[p].CritDamage > inv[p - 1].CritDamage)
                    {
                        Swap(inv, p);
                        p -= 1;
                    }
                    break;
                case 8:
                    while (p != 0 && inv[p].Regen > inv[p - 1].Regen)
                    {
                        Swap(inv, p);
                        p -= 1;
                    }
                    break;
                case 9:
                    while (p != 0 && inv[p].EleResist > inv[p - 1].EleResist)
                    {
                        Swap(inv, p);
                        p -= 1;
                    }
                    break;
                case 10:
                    while (p != 0 && inv[p].ArmourMulti > inv[p - 1].ArmourMulti)
                    {
                        Swap(inv, p);
                        p -= 1;
                    }
                    break;
                case 11:
                    while (p != 0 && inv[p].Value > inv[p - 1].Value)
                    {
                        Swap(inv, p);
                        p -= 1;
                    }
                    break;
            }
        }
    }

    public void Swap(List<Item> inv, int position)
    {
        Item temp = inv[position];
        if (inv[position].ID != -1 && inv[position-1].ID != -1)
        {

            Transform item2 = inventory.slots[position-1].transform.GetChild(0);
            Transform item1 = inventory.slots[position].transform.GetChild(0);
            item1.GetComponent<ItemData>().slot = position-1;
            item1.transform.SetParent(inventory.slots[position-1].transform);
            item1.transform.position = inventory.slots[position-1].transform.position;
            item2.GetComponent<ItemData>().slot = position;
            item2.transform.SetParent(inventory.slots[position].transform);
            item2.transform.position = inventory.slots[position].transform.position;
            inv[position] = inv[position-1];
            inv[position-1] = temp;
        }
        else if (inv[position].ID == -1 && inv[position-1].ID != -1)
        {
            Transform item2 = inventory.slots[position-1].transform.GetChild(0);
            item2.GetComponent<ItemData>().slot = position;
            item2.transform.SetParent(inventory.slots[position].transform);
            item2.transform.position = inventory.slots[position].transform.position;
            inv[position] = inv[position-1];
            inv[position-1] = new Item();
        }
        else if (inv[position].ID != -1 && inv[position-1].ID == -1)
        {
            Transform item1 = inventory.slots[position].transform.GetChild(0);
            item1.GetComponent<ItemData>().slot = position-1;
            item1.transform.SetParent(inventory.slots[position-1].transform);
            item1.transform.position = inventory.slots[position-1].transform.position;
            inv[position] = new Item();
            inv[position-1] = temp;
        }
    }

    public void OnRarityClicked()
    {
        InsertionSort(inventory.items);
    }

}
