using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour {

    private EnemyController enemyController;
    private UnityEngine.UI.Button prevButton;
    public UnityEngine.UI.Text killsCounter;
    public UnityEngine.UI.Text mapName;
    public int curMap;
    public int mapLevel;
    public int curKills;
    


    void Start ()
    {
        enemyController = GameObject.Find("EnemyPanel").GetComponent<EnemyController>();
        prevButton = GameObject.Find("PrevButton").GetComponent<Button>();
        curKills = 0;
        killsCounter.text = curKills + "/10";
        curMap = 0;
        mapLevel = 1;
    }

    void Update ()
    {

        killsCounter.text = curKills + "/10";

        if (mapLevel <= 1 && curMap == 0)
        {
            prevButton.transform.localScale = new Vector3(0, 0, 0);
        }
        else if (mapLevel >= 2)
        {
            prevButton.transform.localScale = new Vector3(1, 1, 1);
        }

        if(curKills >= 10)
        {
            if(mapLevel < 10)
            {
                killsCounter.text = "Next";
            }
            else
            {
                killsCounter.text = "Complete";
            }
            
        }

        


    }


    public void OnPrevClicked()
    {

        
        curKills = 0;
        killsCounter.text = "Next";
        if(mapLevel == 1)
        {
            curMap -= 1;
            mapLevel = 10;

        }
        else
        {
            mapLevel -= 1;
        }
        updateMapName();

       
        
    }

    public void OnNextClicked()
    {
        if(mapLevel <= 9 && curKills >= 10)
        {
            curKills = 0;
            mapLevel += 1;
            updateMapName();
        }
        else if(mapLevel == 10 && curKills >= 10)
        {
            if(curMap < 9)
            {
                curMap += 1;
                mapLevel = 1;
                curKills = 0;
                updateMapName();

            }
        }

    }

    public void updateMapName()
    {

        int curLevel = (curMap * 10) + mapLevel;

        switch(curMap)
        {
            case 0:
                mapName.text = "Lvl " + curLevel + " Forest";
                break;
            case 1:
                mapName.text  = "Lvl " + curLevel + " Cove";
                break;
            case 2:
                mapName.text = "Lvl " + curLevel + " Valley";
                break;
            case 3:
                mapName.text = "Lvl " + curLevel + " Desert";
                break;
            case 4:
                mapName.text = "Lvl " + curLevel +  "Oasis";
                break;
            case 5:
                mapName.text = "Lvl " + curLevel +  "Scorching Plains";
                break;
            case 6:
                mapName.text = "Lvl " + curLevel + " Frozen Wastes";
                break;
            case 7:
                mapName.text = "Lvl " + curLevel + " Ebony Barracks";
                break;
            case 8:
                mapName.text = "Lvl " + curLevel + " Molten Citadel";
                break;
            case 9:
                mapName.text = "Lvl " + curLevel + " Pits of Hell";
                break;
        }
    }
}
