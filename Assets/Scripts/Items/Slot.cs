using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler {
    public int id;
    private Inventory inv;
    private C1Inventory inv1;
    private C2Inventory inv2;
    private C3Inventory inv3;
    private C4Inventory inv4;
    private Player1Stats p1stats;
    private Player2Stats p2stats;
    private Player3Stats p3stats;
    private Player4Stats p4stats;
    private PlayerController pControl;

    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        inv1 = GameObject.Find("C1Inventory").GetComponent<C1Inventory>();
        inv2 = GameObject.Find("C2Inventory").GetComponent<C2Inventory>();
        inv3 = GameObject.Find("C3Inventory").GetComponent<C3Inventory>();
        inv4 = GameObject.Find("C4Inventory").GetComponent<C4Inventory>();
        p1stats = GameObject.Find("P1Stats").GetComponent<Player1Stats>();
        p2stats = GameObject.Find("P2Stats").GetComponent<Player2Stats>();
        p3stats = GameObject.Find("P3Stats").GetComponent<Player3Stats>();
        p4stats = GameObject.Find("P4Stats").GetComponent<Player4Stats>();
        pControl = GameObject.Find("StatsController").GetComponent<PlayerController>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
            if(id == droppedItem.currentSlot && droppedItem.item.Equipped == false)
            {

            }
            else if (inv.items[id].ID == -1)
            {
                inv.capacity += 1;
                if (droppedItem.item.Equipped == true && p1stats.active == true)
                {
                    inv1.items[droppedItem.slot] = new Item();
                    inv.items[id] = droppedItem.item;
                    droppedItem.slot = id;
                    droppedItem.item.Equipped = false;
                    pControl.removeStats(droppedItem.item, 1);
                }
                else if(droppedItem.item.Equipped == true && p2stats.active == true)
                {
                    inv2.items[droppedItem.slot] = new Item();
                    inv.items[id] = droppedItem.item;
                    droppedItem.slot = id;
                    droppedItem.item.Equipped = false;
                    pControl.removeStats(droppedItem.item, 2);
                }
                else if (droppedItem.item.Equipped == true && p3stats.active == true)
                {
                    inv3.items[droppedItem.slot] = new Item();
                    inv.items[id] = droppedItem.item;
                    droppedItem.slot = id;
                    droppedItem.item.Equipped = false;
                    pControl.removeStats(droppedItem.item, 3);
                }
                else if (droppedItem.item.Equipped == true && p4stats.active == true)
                {
                    inv4.items[droppedItem.slot] = new Item();
                    inv.items[id] = droppedItem.item;
                    droppedItem.slot = id;
                    droppedItem.item.Equipped = false;
                    pControl.removeStats(droppedItem.item, 4);
                }
                else
                {
                    inv.items[droppedItem.slot] = new Item();
                    inv.items[id] = droppedItem.item;
                    droppedItem.slot = id;
                }

            }
            else
            {
                if (droppedItem.item.Equipped == false)
                {
                    Transform item = this.transform.GetChild(0);
                    item.GetComponent<ItemData>().slot = droppedItem.slot;
                    item.transform.SetParent(inv.slots[droppedItem.slot].transform);
                    item.transform.position = inv.slots[droppedItem.slot].transform.position;

                    inv.items[droppedItem.slot] = item.GetComponent<ItemData>().item;
                    inv.items[id] = droppedItem.item;
                    droppedItem.slot = id;
                }
                else if(p1stats.active == true)
                {
                    Transform item = this.transform.GetChild(0);
                    if (item.GetComponent<ItemData>().item.ID == droppedItem.item.ID)
                    {
                        item.GetComponent<ItemData>().slot = droppedItem.slot;
                        item.transform.SetParent(inv1.slots[droppedItem.slot].transform);
                        item.transform.position = inv1.slots[droppedItem.slot].transform.position;
                        inv1.items[droppedItem.slot] = item.GetComponent<ItemData>().item;
                        inv1.items[droppedItem.slot].Equipped = true;
                        pControl.addStats(inv1.items[droppedItem.slot], 1);

                        inv.items[id] = droppedItem.item;
                        droppedItem.slot = id;
                        droppedItem.item.Equipped = false;
                        pControl.removeStats(droppedItem.item, 1);
                    }

                }
                else if(p2stats.active == true)
                {
                    Transform item = this.transform.GetChild(0);
                    if (item.GetComponent<ItemData>().item.ID == droppedItem.item.ID)
                    {
                        item.GetComponent<ItemData>().slot = droppedItem.slot;
                        item.transform.SetParent(inv2.slots[droppedItem.slot].transform);
                        item.transform.position = inv2.slots[droppedItem.slot].transform.position;
                        inv2.items[droppedItem.slot] = item.GetComponent<ItemData>().item;
                        inv2.items[droppedItem.slot].Equipped = true;
                        pControl.addStats(inv2.items[droppedItem.slot], 2);

                        inv.items[id] = droppedItem.item;
                        droppedItem.slot = id;
                        droppedItem.item.Equipped = false;
                        pControl.removeStats(droppedItem.item, 2);
                    }
                }
                else if (p3stats.active == true)
                {
                    Transform item = this.transform.GetChild(0);
                    if (item.GetComponent<ItemData>().item.ID == droppedItem.item.ID)
                    {
                        item.GetComponent<ItemData>().slot = droppedItem.slot;
                        item.transform.SetParent(inv3.slots[droppedItem.slot].transform);
                        item.transform.position = inv3.slots[droppedItem.slot].transform.position;
                        inv3.items[droppedItem.slot] = item.GetComponent<ItemData>().item;
                        inv3.items[droppedItem.slot].Equipped = true;
                        pControl.addStats(inv3.items[droppedItem.slot], 3);

                        inv.items[id] = droppedItem.item;
                        droppedItem.slot = id;
                        droppedItem.item.Equipped = false;
                        pControl.removeStats(droppedItem.item, 3);
                    }
                }
                else if (p4stats.active == true)
                {
                    Transform item = this.transform.GetChild(0);
                    if (item.GetComponent<ItemData>().item.ID == droppedItem.item.ID)
                    {
                        item.GetComponent<ItemData>().slot = droppedItem.slot;
                        item.transform.SetParent(inv4.slots[droppedItem.slot].transform);
                        item.transform.position = inv4.slots[droppedItem.slot].transform.position;
                        inv4.items[droppedItem.slot] = item.GetComponent<ItemData>().item;
                        inv4.items[droppedItem.slot].Equipped = true;
                        pControl.addStats(inv4.items[droppedItem.slot], 4);

                        inv.items[id] = droppedItem.item;
                        droppedItem.slot = id;
                        droppedItem.item.Equipped = false;
                        pControl.removeStats(droppedItem.item, 4);
                    }
                }

            }
        }
    }

    
}
