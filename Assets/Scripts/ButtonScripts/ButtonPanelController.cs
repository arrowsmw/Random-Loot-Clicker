using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPanelController : MonoBehaviour {

    private GameObject inventory;
    private GameObject character;
    private GameObject skillpoints;
    private GameObject map;
    private GameObject options;
	
	void Start ()
    {

        inventory = GameObject.Find("InventoryPanel");
        character = GameObject.Find("CharacterPanel");
        skillpoints = GameObject.Find("SkillPointsPanel");
        map = GameObject.Find("MapsPanel");
        options = GameObject.Find("OptionsPanel");

        character.SetActive(false);
        skillpoints.SetActive(false);
        map.SetActive(false);
        options.SetActive(false);


    }
	
    public void OnInventoryPanelClicked()
    {
        inventory.SetActive(true);
        character.SetActive(false);
        skillpoints.SetActive(false);
        map.SetActive(false);
        options.SetActive(false);

    }

    public void OnCharacterPanelClicked()
    {
        inventory.SetActive(false);
        character.SetActive(true);
        skillpoints.SetActive(false);
        map.SetActive(false);
        options.SetActive(false);
    }

    public void OnSkillPanelClicked()
    {
        inventory.SetActive(false);
        character.SetActive(false);
        skillpoints.SetActive(true);
        map.SetActive(false);
        options.SetActive(false);
    }

    public void OnMapPanelClicked()
    {
        inventory.SetActive(false);
        character.SetActive(false);
        skillpoints.SetActive(false);
        map.SetActive(true);
        options.SetActive(false);
    }

    public void OnOptionsPanelClicked()
    {
        inventory.SetActive(false);
        character.SetActive(false);
        skillpoints.SetActive(false);
        map.SetActive(false);
        options.SetActive(true);
    }
}
