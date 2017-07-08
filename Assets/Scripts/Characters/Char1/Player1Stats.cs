using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Stats : MonoBehaviour {

    public UnityEngine.UI.Text stats;
    private GlobalStats glblstats;
    public int power;
    public int agility;
    public int defense;
    public int vitality;
    public bool active;
    public bool created;
    public float critmulti;

	void Start ()
    {
        active = false;
        created = false;
        glblstats = GameObject.Find("StatsController").GetComponent<GlobalStats>();
	}
	
}

