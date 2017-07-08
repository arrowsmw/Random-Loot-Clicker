using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler {
    public int id;
    private Inventory inv;
    private CInventory inv1;
    private CInventory inv2;
    private CInventory inv3;
    private CInventory inv4;
    private PlayerController pControl;

    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        inv1 = GameObject.Find("C1Inventory").GetComponent<CInventory>();
        inv2 = GameObject.Find("C2Inventory").GetComponent<CInventory>();
        inv3 = GameObject.Find("C3Inventory").GetComponent<CInventory>();
        inv4 = GameObject.Find("C4Inventory").GetComponent<CInventory>();
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
                if (droppedItem.item.Equipped == true && pControl.playerActive[1] == true)
                {
                    inv1.items[droppedItem.slot] = new Item();
                    inv.items[id] = droppedItem.item;
                    droppedItem.slot = id;
                    droppedItem.item.Equipped = false;
                    pControl.removeStats(droppedItem.item, 1);
                }
                else if(droppedItem.item.Equipped == true && pControl.playerActive[2] == true)
                {
                    inv2.items[droppedItem.slot] = new Item();
                    inv.items[id] = droppedItem.item;
                    droppedItem.slot = id;
                    droppedItem.item.Equipped = false;
                    pControl.removeStats(droppedItem.item, 2);
                }
                else if (droppedItem.item.Equipped == true && pControl.playerActive[3] == true)
                {
                    inv3.items[droppedItem.slot] = new Item();
                    inv.items[id] = droppedItem.item;
                    droppedItem.slot = id;
                    droppedItem.item.Equipped = false;
                    pControl.removeStats(droppedItem.item, 3);
                }
                else if (droppedItem.item.Equipped == true && pControl.playerActive[4] == true)
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
                else if(pControl.playerActive[1] == true)
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
                else if(pControl.playerActive[2] == true)
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
                else if (pControl.playerActive[3] == true)
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
                else if (pControl.playerActive[4] == true)
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
