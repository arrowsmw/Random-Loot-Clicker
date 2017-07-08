using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class C1Slot : MonoBehaviour, IDropHandler {
    public int id;
    private C1Inventory inv1;
    private Inventory inv;
    private Player1Stats p1stats;
    private PlayerController pControl;

    void Start ()
    {
        inv1 = GameObject.Find("C1Inventory").GetComponent<C1Inventory>();
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        p1stats = GameObject.Find("P1Stats").GetComponent<Player1Stats>();
        pControl = GameObject.Find("StatsController").GetComponent<PlayerController>();
	}

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
            if (inv1.items[id].ID == -1 && droppedItem.item.ID == id)
            {
                inv.items[droppedItem.slot] = new Item();
                inv1.items[id] = droppedItem.item;
                droppedItem.slot = id;
                inv.capacity -= 1;
                if(droppedItem.item.Equipped == false)
                {
                    pControl.addStats(droppedItem.item, 1);
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
                    pControl.removeStats(inv.items[droppedItem.slot], 1);

                    inv1.items[id] = droppedItem.item;
                    droppedItem.slot = id;
                    droppedItem.item.Equipped = true;
                    pControl.addStats(droppedItem.item, 1);
                }
                else
                {
                    Transform item = this.transform.GetChild(0);
                    item.GetComponent<ItemData>().slot = droppedItem.slot;
                    item.transform.SetParent(inv1.slots[droppedItem.slot].transform);
                    item.transform.position = inv1.slots[droppedItem.slot].transform.position;

                    inv1.items[droppedItem.slot] = item.GetComponent<ItemData>().item;
                    inv1.items[id] = droppedItem.item;
                    droppedItem.slot = id;
                }
            }
        }
    }
}
