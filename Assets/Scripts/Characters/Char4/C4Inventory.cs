using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C4Inventory : MonoBehaviour
{

    GameObject inventoryPanel;
    GameObject slotPanel;
    public GameObject inventorySlot;
    public GameObject inventoryItem;

    int slotAmount;
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    void Start()
    {
        slotAmount = 10;
        inventoryPanel = GameObject.Find("C4InvPanel");
        slotPanel = inventoryPanel.transform.FindChild("C4SlotPanel").gameObject;
        for (int i = 0; i < slotAmount; i++)
        {
            items.Add(new Item());
            slots.Add(Instantiate(inventorySlot));
            slots[i].GetComponent<C4Slot>().id = i;
            slots[i].transform.SetParent(slotPanel.transform);
            switch (i)
            {
                case 0:
                    slots[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/golden_helmet_background");
                    break;
                case 1:
                    slots[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/golden_shoulder_background");
                    break;
                case 2:
                    slots[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/golden_chest_background");
                    break;
                case 3:
                    slots[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/golden_leggings_background");
                    break;
                case 4:
                    slots[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/golden_boot_background");
                    break;
                case 5:
                    slots[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/golden_gloves_background");
                    break;
                case 6:
                    slots[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Belt_background");
                    break;
                case 7:
                    slots[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/silver_ring_background");
                    break;
                case 8:
                    slots[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/ruby_amulet_background");
                    break;
                case 9:
                    slots[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/iron_sword_background");
                    break;
            }
        }
    }
}
