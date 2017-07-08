using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CSlot : MonoBehaviour, IDropHandler
{
    public int id;
    private CInventory inv1;
    private CInventory inv2;
    private CInventory inv3;
    private CInventory inv4;
    private Inventory inv;
    private PlayerController pControl;

    void Start()
    {
        inv1 = GameObject.Find("C1Inventory").GetComponent<CInventory>();
        inv2 = GameObject.Find("C2Inventory").GetComponent<CInventory>();
        inv3 = GameObject.Find("C3Inventory").GetComponent<CInventory>();
        inv4 = GameObject.Find("C4Inventory").GetComponent<CInventory>();

        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        pControl = GameObject.Find("StatsController").GetComponent<PlayerController>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (pControl.playerActive[1] == true)
            {
                ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
                if (inv1.items[id].ID == -1 && droppedItem.item.ID == id)
                {
                    inv.items[droppedItem.slot] = new Item();
                    inv1.items[id] = droppedItem.item;
                    droppedItem.slot = id;
                    inv.capacity -= 1;
                    if (droppedItem.item.Equipped == false)
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

            else if (pControl.playerActive[2] == true)
            {
                ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
                if (inv2.items[id].ID == -1 && droppedItem.item.ID == id)
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

            else if (pControl.playerActive[3] == true)
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

            else if (pControl.playerActive[4])
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
}
