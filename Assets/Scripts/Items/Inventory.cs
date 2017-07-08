using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    
    GameObject inventoryPanel;
    GameObject slotPanel;
    public GameObject inventorySlot;
    public GameObject inventoryItem;

    int slotAmount;
    public int capacity;
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    void Start()
    {

        slotAmount = 96;
        inventoryPanel = GameObject.Find("InventoryPanel");
        slotPanel = inventoryPanel.transform.FindChild("SlotPanel").gameObject;
        for(int i=0; i< slotAmount; i++)
        {
            items.Add(new Item());
            slots.Add(Instantiate(inventorySlot));
            slots[i].GetComponent<Slot>().id = i;
            slots[i].transform.SetParent(slotPanel.transform);
        }

        

    }

    public void AddItem(Item itemToAdd)
    {
        if(capacity <= 95)
            capacity += 1;

        //Item itemToAdd = database.FetchItemById(id);
        if (itemToAdd.Stackable && CheckIfItemExists(itemToAdd))
        {
            //for(int i=0; i<items.Count; i++)
            //{
            //    if(items[i].ID == id)
            //    {
            //        ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
            //        data.amount += 1;
            //        data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
            //        break;
            //    }
            //}
        }
        else
        {
            
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == -1)
                {
                    items[i] = itemToAdd;
                    GameObject itemObject = Instantiate(inventoryItem);
                    itemObject.GetComponent<ItemData>().item = itemToAdd;
                    itemObject.GetComponent<ItemData>().slot = i;
                    itemObject.transform.SetParent(slots[i].transform);
                    itemObject.transform.position = slots[i].transform.position;
                    itemObject.transform.GetChild(1).GetComponent<Image>().sprite = itemToAdd.Sprite;
                    switch (itemToAdd.Rarity)
                    {
                        case 1:
                            itemObject.transform.GetChild(0).GetComponent<Image>().color = new Color32(59, 234, 96, 255);
                            break;
                        case 2:
                            itemObject.transform.GetChild(0).GetComponent<Image>().color = new Color32(50, 36, 231, 255);
                            break;
                        case 3:
                            itemObject.transform.GetChild(0).GetComponent<Image>().color = new Color32(147, 0, 156, 255);
                            break;
                        case 4:
                            itemObject.transform.GetChild(0).GetComponent<Image>().color = new Color32(255, 133, 2, 255);
                            break;
                    }
                    itemObject.transform.GetChild(2).GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                    //itemObject.GetComponent<Image>().sprite = itemToAdd.Sprite;
                    itemObject.name = itemToAdd.Title;
                    ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount = 1;
                    break;
                }
            }
        } 
    }

    bool CheckIfItemExists(Item item)
    {
        for(int i=0; i<items.Count; i++)
        {
            if (items[i].ID == item.ID)
            return true;
        }
        return false;
    }
}
