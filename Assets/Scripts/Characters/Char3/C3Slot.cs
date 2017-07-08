using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class C3Slot : MonoBehaviour, IDropHandler
{

    public int id;
    private C3Inventory inv3;
    private Inventory inv;
    private Player3Stats p3stats;
    private PlayerController pControl;

    void Start()
    {
        inv3 = GameObject.Find("C3Inventory").GetComponent<C3Inventory>();
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        p3stats = GameObject.Find("P3Stats").GetComponent<Player3Stats>();
        pControl = GameObject.Find("StatsController").GetComponent<PlayerController>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
            if (inv3.items[id].ID == -1 && droppedItem.item.ID == id)
            {
                inv.items[droppedItem.slot] = new Item();
                inv3.items[id] = droppedItem.item;
                droppedItem.slot = id;
                inv.capacity -= 1;
                if (droppedItem.item.Equipped == false)
                {
                    pControl.addStats(droppedItem.item, 3);
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
                    pControl.removeStats(inv.items[droppedItem.slot], 3);

                    inv3.items[id] = droppedItem.item;
                    droppedItem.slot = id;
                    droppedItem.item.Equipped = true;
                    pControl.addStats(droppedItem.item, 3);
                }
                else
                {
                    Transform item = this.transform.GetChild(0);
                    item.GetComponent<ItemData>().slot = droppedItem.slot;
                    item.transform.SetParent(inv3.slots[droppedItem.slot].transform);
                    item.transform.position = inv3.slots[droppedItem.slot].transform.position;

                    inv3.items[droppedItem.slot] = item.GetComponent<ItemData>().item;
                    inv3.items[id] = droppedItem.item;
                    droppedItem.slot = id;
                }
            }
        }
    }


}
