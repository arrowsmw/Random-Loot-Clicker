using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class C2Slot : MonoBehaviour, IDropHandler {

    public int id;
    private C2Inventory inv2;
    private Inventory inv;
    private PlayerController pControl;

	void Start ()
    {
        inv2 = GameObject.Find("C2Inventory").GetComponent<C2Inventory>();
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        pControl = GameObject.Find("StatsController").GetComponent<PlayerController>();
	}

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
            if(inv2.items[id].ID == -1 && droppedItem.item.ID == id)
            {
                inv.items[droppedItem.slot] = new Item();
                inv2.items[id] = droppedItem.item;
                droppedItem.slot = id;
                inv.capacity -= 1;
                if (droppedItem.item.Equipped == false)
                {
                    pControl.addStats(droppedItem.item, 2);
                }
                droppedItem.item.Equipped = true;
            }
            else if(droppedItem.item.ID == id)
            {
                if(droppedItem.item.Equipped == false)
                {
                    Transform item = this.transform.GetChild(0);
                    item.GetComponent<ItemData>().slot = droppedItem.slot;
                    item.transform.SetParent(inv.slots[droppedItem.slot].transform);
                    item.transform.position = inv.slots[droppedItem.slot].transform.position;
                    inv.items[droppedItem.slot] = item.GetComponent<ItemData>().item;
                    inv.items[droppedItem.slot].Equipped = false;
                    pControl.removeStats(inv.items[droppedItem.slot], 2);

                    inv2.items[id] = droppedItem.item;
                    droppedItem.slot = id;
                    droppedItem.item.Equipped = true;
                    pControl.addStats(droppedItem.item, 2);
                }
                else
                {
                    Transform item = this.transform.GetChild(0);
                    item.GetComponent<ItemData>().slot = droppedItem.slot;
                    item.transform.SetParent(inv2.slots[droppedItem.slot].transform);
                    item.transform.position = inv2.slots[droppedItem.slot].transform.position;

                    inv2.items[droppedItem.slot] = item.GetComponent<ItemData>().item;
                    inv2.items[id] = droppedItem.item;
                    droppedItem.slot = id;
                }
            }
        }
    }
	

}
