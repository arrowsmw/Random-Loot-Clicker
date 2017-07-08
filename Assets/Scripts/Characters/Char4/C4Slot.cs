using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class C4Slot : MonoBehaviour, IDropHandler
{

    public int id;
    private C4Inventory inv4;
    private Inventory inv;
    private PlayerController pControl;

    void Start()
    {
        inv4 = GameObject.Find("C4Inventory").GetComponent<C4Inventory>();
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        pControl = GameObject.Find("StatsController").GetComponent<PlayerController>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
            if (inv4.items[id].ID == -1 && droppedItem.item.ID == id)
            {
                inv.items[droppedItem.slot] = new Item();
                inv4.items[id] = droppedItem.item;
                droppedItem.slot = id;
                inv.capacity -= 1;
                if (droppedItem.item.Equipped == false)
                {
                    pControl.addStats(droppedItem.item, 4);
                }
                droppedItem.item.Equipped = true;
            }
            else if (droppedItem.item.ID == id)
            {
                if (droppedItem.item.Equipped == false)
                {
                    Transform item = this.transform.GetChild(0);
                    item.GetComponent<ItemData>().slot = droppedItem.slot;
                    item.transform.SetParent(inv.slots[droppedItem.slot].transform);
                    item.transform.position = inv.slots[droppedItem.slot].transform.position;
                    inv.items[droppedItem.slot] = item.GetComponent<ItemData>().item;
                    inv.items[droppedItem.slot].Equipped = false;
                    pControl.removeStats(inv.items[droppedItem.slot], 4);

                    inv4.items[id] = droppedItem.item;
                    droppedItem.slot = id;
                    droppedItem.item.Equipped = true;
                    pControl.addStats(droppedItem.item, 4);
                }
                else
                {
                    Transform item = this.transform.GetChild(0);
                    item.GetComponent<ItemData>().slot = droppedItem.slot;
                    item.transform.SetParent(inv4.slots[droppedItem.slot].transform);
                    item.transform.position = inv4.slots[droppedItem.slot].transform.position;

                    inv4.items[droppedItem.slot] = item.GetComponent<ItemData>().item;
                    inv4.items[id] = droppedItem.item;
                    droppedItem.slot = id;
                }
            }
        }
    }


}
