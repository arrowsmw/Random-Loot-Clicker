﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

    public Item item;
    public int amount;
    public int slot;

    private Inventory inv;
    private C1Inventory inv1;
    private C2Inventory inv2;
    private C3Inventory inv3;
    private C4Inventory inv4;
    private ToolTip tooltip;
    private Player1Stats p1stats;
    private Player2Stats p2stats;
    private Player3Stats p3stats;
    private Player4Stats p4stats;
    private GlobalStats glblstats;
    private PlayerController pControl;
    public int currentSlot;

    public GameObject canvas;
    public bool Sellable = false;
    public bool dragging = false;


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
        glblstats = GameObject.Find("StatsController").GetComponent<GlobalStats>();
        pControl = GameObject.Find("StatsController").GetComponent<PlayerController>();
        tooltip = inv.GetComponent<ToolTip>();
        canvas = GameObject.Find("Canvas");
    }

    void Update()
    {
        if (item.Equipped == false && Sellable == true && Input.GetKeyUp(KeyCode.S) && item.Locked == false)
        {
            glblstats.gold += item.Value;
            Destroy(this.gameObject);
            inv.capacity -= 1;
            inv.items[slot] = new Item();
            tooltip.Deactivate();
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (item.ID != -1)
            {
                this.transform.SetParent(canvas.transform);
                this.transform.position = eventData.position;
                GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            dragging = true;
            currentSlot = this.slot;
            this.transform.position = eventData.position;
            if (item.ID != -1)
            {
                if (item.Equipped == false)
                {
                    currentSlot = this.slot;
                    this.transform.position = eventData.position;
                    inv.items[slot] = new Item();
                }
                else
                {
                    currentSlot = this.slot;
                    this.transform.position = eventData.position;
                    if (p1stats.active == true)
                        inv1.items[slot] = new Item();
                    else if (p2stats.active == true)
                        inv2.items[slot] = new Item();
                    else if (p3stats.active == true)
                        inv3.items[slot] = new Item();
                    else if (p4stats.active == true)
                        inv4.items[slot] = new Item();
                }
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (dragging == true)
        {
            if (item.Equipped == false)
            {
                this.transform.SetParent(inv.slots[slot].transform);
                this.transform.position = inv.slots[slot].transform.position;
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                if (currentSlot == this.slot)
                {
                    inv.items[slot] = item;
                }
            }
            else if(p1stats.active == true)
            {
                this.transform.SetParent(inv1.slots[slot].transform);
                this.transform.position = inv1.slots[slot].transform.position;
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                if (currentSlot == this.slot)
                {
                    inv1.items[slot] = item;
                }
            }
            else if(p2stats.active == true)
            {
                this.transform.SetParent(inv2.slots[slot].transform);
                this.transform.position = inv2.slots[slot].transform.position;
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                if(currentSlot == this.slot)
                {
                    inv2.items[slot] = item;
                }
            }
            else if(p3stats.active == true)
            {
                this.transform.SetParent(inv3.slots[slot].transform);
                this.transform.position = inv3.slots[slot].transform.position;
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                if (currentSlot == this.slot)
                {
                    inv3.items[slot] = item;
                }
            }
            else if(p4stats.active == true)
            {
                this.transform.SetParent(inv4.slots[slot].transform);
                this.transform.position = inv4.slots[slot].transform.position;
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                if (currentSlot == this.slot)
                {
                    inv4.items[slot] = item;
                }
            }

            dragging = false;
        }
        
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(item.Equipped == false)
        {
            if(p1stats.active == true && inv1.items[item.ID].ID != -1)
            {
                tooltip.ActivateComparison(item);
                tooltip.Activate(inv1.items[item.ID]);
            }
            else if(p2stats.active == true && inv2.items[item.ID].ID != -1)
            {
                tooltip.ActivateComparison(item);
                tooltip.Activate(inv2.items[item.ID]);
            }
            else if(p3stats.active == true && inv3.items[item.ID].ID != -1)
            {
                tooltip.ActivateComparison(item);
                tooltip.Activate(inv3.items[item.ID]);
            }
            else if(p4stats.active == true && inv4.items[item.ID].ID != -1)
            {
                tooltip.ActivateComparison(item);
                tooltip.Activate(inv4.items[item.ID]);
            }
            else
            {
                tooltip.Activate(item);
            }

        }
        else
        {
            tooltip.Activate(item);
        }
        
        Sellable = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.Deactivate();
        Sellable = false;
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Middle)
        {
            if(item.Locked == false)
            {
                item.Locked = true;
                this.transform.GetChild(2).GetComponent<Image>().color = new Color32(255, 255, 255, 255);

            }
            else
            {
                item.Locked = false;
                this.transform.GetChild(2).GetComponent<Image>().color = new Color32(255, 255, 255, 0);
            }
        }
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            
            GameObject slotType = this.transform.parent.gameObject;
            if (slotType.name == "C1Slot(Clone)")
            {
                for (int i = 0; i < inv.items.Count; i++)
                {
                    if (inv.items[i].ID == -1)
                    {
                        this.transform.SetParent(inv.slots[i].transform);
                        this.transform.position = inv.slots[i].transform.position;
                        inv.items[i] = item;
                        inv1.items[slot] = new Item();
                        slot = i;
                        item.Equipped = false;

                        pControl.removeStats(item, 1);
                        tooltip.Deactivate();
                        inv.capacity += 1;
                        break;
                    }

                }

            }
            else if (slotType.name == "C2Slot(Clone)")
            {
                for (int i = 0; i < inv.items.Count; i++)
                {
                    if (inv.items[i].ID == -1)
                    {
                        this.transform.SetParent(inv.slots[i].transform);
                        this.transform.position = inv.slots[i].transform.position;
                        inv.items[i] = item;
                        inv2.items[slot] = new Item();
                        slot = i;
                        item.Equipped = false;
                        pControl.removeStats(item, 2);
                        tooltip.Deactivate();
                        inv.capacity += 1;
                        break;
                    }

                }
            }
            else if (slotType.name == "C3Slot(Clone)")
            {
                for(int i = 0; i < inv.items.Count; i++)
                {
                    if (inv.items[i].ID == -1)
                    {
                        this.transform.SetParent(inv.slots[i].transform);
                        this.transform.position = inv.slots[i].transform.position;
                        inv.items[i] = item;
                        inv3.items[slot] = new Item();
                        slot = i;
                        item.Equipped = false;
                        pControl.removeStats(item, 3);
                        tooltip.Deactivate();
                        inv.capacity += 1;
                        break;
                    }

                }
            }
            else if (slotType.name == "C4Slot(Clone)")
            {
                for (int i = 0; i < inv.items.Count; i++)
                {
                    if (inv.items[i].ID == -1)
                    {
                        this.transform.SetParent(inv.slots[i].transform);
                        this.transform.position = inv.slots[i].transform.position;
                        inv.items[i] = item;
                        inv4.items[slot] = new Item();
                        slot = i;
                        item.Equipped = false;
                        pControl.removeStats(item, 4);
                        tooltip.Deactivate();
                        inv.capacity += 1;
                        break;
                    }

                }
            }
            else if (slotType.name == "Slot(Clone)")
            {
                if (p1stats.active == true && p1stats.created == true)
                {
                    if (inv1.items[item.ID].ID == -1)
                    {
                        this.transform.SetParent(inv1.slots[item.ID].transform);
                        this.transform.position = inv1.slots[item.ID].transform.position;
                        inv1.items[item.ID] = item;
                        inv.items[slot] = new Item();
                        slot = item.ID;
                        item.Equipped = true;
                        pControl.addStats(item, 1);
                        inv.capacity -= 1;

                    }
                    else
                    {
                        Transform item2 = inv1.slots[item.ID].transform.GetChild(0);
                        item2.GetComponent<ItemData>().slot = slot;
                        item2.transform.SetParent(inv.slots[slot].transform);
                        item2.transform.position = inv.slots[slot].transform.position;


                        this.transform.SetParent(inv1.slots[item.ID].transform);
                        this.transform.position = inv1.slots[item.ID].transform.position;
                        inv.items[slot] = inv1.items[item.ID];
                        inv.items[slot].Equipped = false;
                        pControl.removeStats(inv.items[slot], 1);
                        inv1.items[item.ID] = item;
                        slot = item.ID;
                        item.Equipped = true;
                        pControl.addStats(item, 1);

                    }
                }
                else if (p2stats.active == true && p2stats.created == true)
                {
                    if (inv2.items[item.ID].ID == -1)
                    {
                        this.transform.SetParent(inv2.slots[item.ID].transform);
                        this.transform.position = inv2.slots[item.ID].transform.position;
                        inv2.items[item.ID] = item;
                        inv.items[slot] = new Item();
                        slot = item.ID;
                        item.Equipped = true;
                        pControl.addStats(item, 2);
                        inv.capacity -= 1;
                    }
                    else
                    {
                        Transform item2 = inv2.slots[item.ID].transform.GetChild(0);
                        item2.GetComponent<ItemData>().slot = slot;
                        item2.transform.SetParent(inv.slots[slot].transform);
                        item2.transform.position = inv.slots[slot].transform.position;


                        this.transform.SetParent(inv2.slots[item.ID].transform);
                        this.transform.position = inv2.slots[item.ID].transform.position;
                        inv.items[slot] = inv2.items[item.ID];
                        inv.items[slot].Equipped = false;
                        pControl.removeStats(inv.items[slot], 2);
                        inv2.items[item.ID] = item;
                        slot = item.ID;
                        item.Equipped = true;
                        pControl.addStats(item, 2);
                    }
                }
                else if (p3stats.active == true && p3stats.created == true)
                {
                    if (inv3.items[item.ID].ID == -1)
                    {
                        this.transform.SetParent(inv3.slots[item.ID].transform);
                        this.transform.position = inv3.slots[item.ID].transform.position;
                        inv3.items[item.ID] = item;
                        inv.items[slot] = new Item();
                        slot = item.ID;
                        item.Equipped = true;
                        pControl.addStats(item, 3);
                        inv.capacity -= 1;
                    }
                    else
                    {
                        Transform item2 = inv3.slots[item.ID].transform.GetChild(0);
                        item2.GetComponent<ItemData>().slot = slot;
                        item2.transform.SetParent(inv.slots[slot].transform);
                        item2.transform.position = inv.slots[slot].transform.position;


                        this.transform.SetParent(inv3.slots[item.ID].transform);
                        this.transform.position = inv3.slots[item.ID].transform.position;
                        inv.items[slot] = inv3.items[item.ID];
                        inv.items[slot].Equipped = false;
                        pControl.removeStats(inv.items[slot], 3);
                        inv3.items[item.ID] = item;
                        slot = item.ID;
                        item.Equipped = true;
                        pControl.addStats(item, 3);
                    }
                }
                else if (p4stats.active == true && p4stats.created == true)
                {
                    if (inv4.items[item.ID].ID == -1)
                    {
                        this.transform.SetParent(inv4.slots[item.ID].transform);
                        this.transform.position = inv4.slots[item.ID].transform.position;
                        inv4.items[item.ID] = item;
                        inv.items[slot] = new Item();
                        slot = item.ID;
                        item.Equipped = true;
                        pControl.addStats(item, 4);
                        inv.capacity -= 1;
                    }
                    else
                    {
                        Transform item2 = inv4.slots[item.ID].transform.GetChild(0);
                        item2.GetComponent<ItemData>().slot = slot;
                        item2.transform.SetParent(inv.slots[slot].transform);
                        item2.transform.position = inv.slots[slot].transform.position;


                        this.transform.SetParent(inv4.slots[item.ID].transform);
                        this.transform.position = inv4.slots[item.ID].transform.position;
                        inv.items[slot] = inv4.items[item.ID];
                        inv.items[slot].Equipped = false;
                        pControl.removeStats(inv.items[slot], 4);
                        inv4.items[item.ID] = item;
                        slot = item.ID;
                        item.Equipped = true;
                        pControl.addStats(item, 4);
                    }
                }


            }
            else
            {
                Debug.Log("You done fucked up");
            }
        }
    }

}