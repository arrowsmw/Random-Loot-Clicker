using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPanelController : MonoBehaviour {

    private GameObject inventory;
    private GameObject crafting;
    private GameObject skillpoints;
    private GameObject map;
    private GameObject stats;
    private GameObject options;
	
	void Start ()
    {

        inventory = GameObject.Find("InventoryPanel");
        crafting = GameObject.Find("CraftingPanel");
        skillpoints = GameObject.Find("SkillPointsPanel");
        map = GameObject.Find("MapsPanel");
        stats = GameObject.Find("StatsPanel");
        options = GameObject.Find("OptionsPanel");

        crafting.SetActive(false);
        skillpoints.SetActive(false);
        map.SetActive(false);
        stats.SetActive(false);
        options.SetActive(false);


    }
	
    public void OnInventoryPanelClicked()
    {
        inventory.SetActive(true);
        crafting.SetActive(false);
        skillpoints.SetActive(false);
        map.SetActive(false);
        stats.SetActive(false);
        options.SetActive(false);

    }

    public void OnCharacterPanelClicked()
    {
        inventory.SetActive(false);
        crafting.SetActive(true);
        skillpoints.SetActive(false);
        map.SetActive(false);
        stats.SetActive(false);
        options.SetActive(false);
    }

    public void OnSkillPanelClicked()
    {
        inventory.SetActive(false);
        crafting.SetActive(false);
        skillpoints.SetActive(true);
        map.SetActive(false);
        stats.SetActive(false);
        options.SetActive(false);
    }

    public void OnMapPanelClicked()
    {
        inventory.SetActive(false);
        crafting.SetActive(false);
        skillpoints.SetActive(false);
        map.SetActive(true);
        stats.SetActive(false);
        options.SetActive(false);
    }

    public void OnStatsPanelClicked()
    {
        inventory.SetActive(false);
        crafting.SetActive(false);
        skillpoints.SetActive(false);
        map.SetActive(false);
        stats.SetActive(true);
        options.SetActive(false);
    }

    public void OnOptionsPanelClicked()
    {
        inventory.SetActive(false);
        crafting.SetActive(false);
        skillpoints.SetActive(false);
        map.SetActive(false);
        stats.SetActive(false);
        options.SetActive(true);
    }
}
