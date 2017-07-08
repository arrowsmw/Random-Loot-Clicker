using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalStats : MonoBehaviour
{
    public int playerLevel;
    public double gold;
    public int diamonds;
    public int commons;
    public int rares;
    public int epics;
    public int legendaries;
    public int total;
    public int activeChar;
    public int curXp;
    public int maxXp;
    public UnityEngine.UI.Text goldText;
    public UnityEngine.UI.Text diamondText;
    public UnityEngine.UI.Text statsText;
    public UnityEngine.UI.Text xpText;
    public UnityEngine.UI.Text levelText;
    public UnityEngine.UI.Slider xpSlider;
    private PlayerController pControl;

    void Start()
    {
        pControl = GameObject.Find("StatsController").GetComponent<PlayerController>();
        maxXp = 100;
    }
    void Update()
    {
        goldText.text = pControl.ValueIntoString(gold, false);
        diamondText.text = pControl.ValueIntoString(diamonds, false);
        total = commons + legendaries + rares + epics;
        statsText.text = "Commons: " + commons + "\nRares: " + rares + "\nEpics:  " + epics + "\nLegendaries: " + legendaries + "\nTotal: " + total;
        xpSlider.value = ((float)curXp / (float)maxXp) * 100;
        if(curXp >= maxXp)
        {
            playerLevel += 1;
            levelText.text = "Level: " + playerLevel;
            if (playerLevel == 100)
            {
                xpSlider.transform.localScale = new Vector3(0, 0, 0);
                xpText.transform.localScale = new Vector3(0, 0, 0);
                
            }
            else
            {
                curXp = curXp - maxXp;
                maxXp = (playerLevel * playerLevel) * 100;
                pControl.levelUp();
            }
        }
        xpText.text = "" + curXp + "/" + maxXp;
        
    }
}