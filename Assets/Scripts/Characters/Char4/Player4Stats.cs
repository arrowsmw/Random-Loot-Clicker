using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player4Stats : MonoBehaviour
{

    public UnityEngine.UI.Text stats;
    private GlobalStats glblstats;
    public int power;
    public int agility;
    public int defense;
    public int vitality;
    public bool active;
    public bool created;

    void Start()
    {
        created = false;
        active = false;
        glblstats = GameObject.Find("StatsController").GetComponent<GlobalStats>();
    }
}
