using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

    private GameObject enemyPanel;
    public List<Enemy> enemies = new List<Enemy>();
    public List<GameObject> enemyObjects = new List<GameObject>();
    public int enemyCount;
    public GameObject enemy;
    private GlobalStats glblstats;
    private PlayerController pControl;
    private Inventory inv;
    private MapController mapController;

	void Start ()
    {
        enemyPanel = GameObject.Find("EnemyPanel");
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        glblstats = GameObject.Find("StatsController").GetComponent<GlobalStats>();
        pControl = GameObject.Find("StatsController").GetComponent<PlayerController>();
        mapController = GameObject.Find("EnemyPanel").GetComponent<MapController>();
        spawnEnemy();
        StartCoroutine(Autotick());
	}
	

	void Update ()
    {
		if(enemyCount == 0)
        {
            switch(Random.Range(1, 6))
            {
                case 5:
                    spawnEnemy();
                    spawnEnemy();
                    spawnEnemy();
                    spawnEnemy();
                    spawnEnemy();
                    for(int i=0; i<5; i++)
                    {
                        enemies[i].maxHealth = enemies[i].maxHealth / 5;
                        enemies[i].curHealth = enemies[i].curHealth / 5;
                        enemies[i].damage = enemies[i].damage / 5;
                        enemyObjects[i].transform.position = new Vector3((i*50)+ 50, 400, 0);
                        enemyObjects[i].GetComponentInChildren<Slider>().transform.localScale = new Vector3(1, 1, 1);
                        enemyObjects[i].transform.GetChild(0).GetComponent<Text>().text = "Lvl " + enemies[i].level + " " + enemies[i].name;
                        enemyObjects[i].transform.GetChild(1).GetComponent<Text>().text = pControl.ValueIntoString(enemies[i].curHealth, false) + " /\n" + pControl.ValueIntoString(enemies[i].maxHealth, false);
                    }
                    break;
                case 4:
                    spawnEnemy();
                    spawnEnemy();
                    spawnEnemy();
                    spawnEnemy();
                    for (int i = 0; i < 4; i++)
                    {
                        enemies[i].maxHealth = enemies[i].maxHealth / 4;
                        enemies[i].curHealth = enemies[i].curHealth / 4;
                        enemies[i].damage = enemies[i].damage / 4;
                        enemyObjects[i].transform.position = new Vector3((i * 60) + 60, 400, 0);
                        enemyObjects[i].GetComponentInChildren<Slider>().transform.localScale = new Vector3(2, 1, 1);
                        enemyObjects[i].transform.GetChild(0).GetComponent<Text>().text = "Lvl " + enemies[i].level + " " + enemies[i].name;
                        enemyObjects[i].transform.GetChild(1).GetComponent<Text>().text = pControl.ValueIntoString(enemies[i].curHealth, false) + " /\n" + pControl.ValueIntoString(enemies[i].maxHealth, false);
                    }
                    break;
                case 3:
                    spawnEnemy();
                    spawnEnemy();
                    spawnEnemy();
                    for (int i = 0; i < 3; i++)
                    {
                        enemies[i].maxHealth = enemies[i].maxHealth / 3;
                        enemies[i].curHealth = enemies[i].curHealth / 3;
                        enemies[i].damage = enemies[i].damage / 3;
                        enemyObjects[i].transform.position = new Vector3((i * 75) + 75, 400, 0);
                        enemyObjects[i].GetComponentInChildren<Slider>().transform.localScale = new Vector3(3, 1, 1);
                        enemyObjects[i].transform.GetChild(0).GetComponent<Text>().text = "Lvl " + enemies[i].level + " " + enemies[i].name;
                        enemyObjects[i].transform.GetChild(1).GetComponent<Text>().text = pControl.ValueIntoString(enemies[i].curHealth, false) + " /\n" + pControl.ValueIntoString(enemies[i].maxHealth, false);
                    }
                    break;
                case 2:
                    spawnEnemy();
                    spawnEnemy();
                    for (int i = 0; i < 2; i++)
                    {
                        enemies[i].maxHealth = enemies[i].maxHealth / 2;
                        enemies[i].curHealth = enemies[i].curHealth / 2;
                        enemies[i].damage = enemies[i].damage / 2;
                        enemyObjects[i].transform.position = new Vector3((i * 100) + 100, 400, 0);
                        enemyObjects[i].GetComponentInChildren<Slider>().transform.localScale = new Vector3(4, 1, 1);
                        enemyObjects[i].transform.GetChild(0).GetComponent<Text>().text = "Lvl " + enemies[i].level + " " + enemies[i].name;
                        enemyObjects[i].transform.GetChild(1).GetComponent<Text>().text = pControl.ValueIntoString(enemies[i].curHealth, false) + " /\n" + pControl.ValueIntoString(enemies[i].maxHealth, false);
                    }
                    break;
                case 1:
                    spawnEnemy();
                    enemyObjects[0].transform.position = new Vector3(150, 400, 0);
                    enemyObjects[0].GetComponentInChildren<Slider>().transform.localScale = new Vector3(5, 1, 1);
                    enemyObjects[0].transform.GetChild(0).GetComponent<Text>().text = "Lvl " + enemies[0].level + " " + enemies[0].name;
                    enemyObjects[0].transform.GetChild(1).GetComponent<Text>().text = pControl.ValueIntoString(enemies[0].curHealth, false) + " /\n" + pControl.ValueIntoString(enemies[0].maxHealth, false);
                    break;
            }
        }
	}

    public void spawnEnemy()
    {
        enemies.Add(new Enemy());
        enemyCount += 1;
        GameObject enemyObject = Instantiate(enemy);
        enemyObject.transform.SetParent(enemyPanel.transform);
        enemyObject.GetComponentInChildren<Slider>().value = Mathf.Abs(((float)enemies[enemyCount - 1].curHealth / (float)enemies[enemyCount - 1].maxHealth) * 100);
        enemyObject.GetComponentInChildren<Slider>().transform.localScale = new Vector3(5, 1, 1);
        enemyObject.transform.position = new Vector3(150, 400, 0);
        
        enemyObjects.Add(enemyObject);
        enemyObjects[0].transform.GetChild(0).GetComponent<Text>().text = "Lvl " + enemies[enemyCount - 1].level + " " + enemies[enemyCount - 1].name;
        enemyObjects[0].transform.GetChild(1).GetComponent<Text>().text = pControl.ValueIntoString(enemies[enemyCount - 1].curHealth, false) + " /\n" + pControl.ValueIntoString(enemies[enemyCount - 1].maxHealth, false);
    }

    public void killEnemy(int enemyNum)
    {
        mapController.curKills += 1;
        enemyCount -= 1;
        glblstats.totalKills += 1;
        glblstats.totalXp += (int)Mathf.Floor((2 * enemies[enemyNum].level) + ((enemies[enemyNum].level * enemies[enemyNum].level) / 2));
        glblstats.gold += Mathf.Floor(((float)enemies[enemyNum].maxHealth) / 5);
        glblstats.curXp += (int)Mathf.Floor((2 * enemies[enemyNum].level) + ((enemies[enemyNum].level * enemies[enemyNum].level) / 2));
        if (Random.Range(1, 4) == 1)
        {
            Item itemToAdd = new Item(Random.Range(0, 10), enemies[enemyNum].level);
            switch(itemToAdd.Rarity)
            {
                case 1:
                    glblstats.commons += 1;
                    break;
                case 2:
                    glblstats.rares += 1;
                    break;
                case 3:
                    glblstats.epics += 1;
                    break;
                case 4:
                    glblstats.legendaries += 1;
                    break;
            }
            inv.AddItem(itemToAdd);
           
        }
        enemies.RemoveAt(enemyNum);
        Destroy(enemyObjects[enemyNum]);
        enemyObjects.RemoveAt(enemyNum);
        switch (enemyCount)
        {
            case 5:
                for (int i = 0; i < 5; i++)
                {
                    enemyObjects[i].transform.position = new Vector3((i * 50) + 50, 400, 0);
                    enemyObjects[i].GetComponentInChildren<Slider>().transform.localScale = new Vector3(1, 1, 1);
                    enemyObjects[i].transform.GetChild(0).GetComponent<Text>().text = "Lvl " + enemies[i].level + " " + enemies[i].name;
                    enemyObjects[i].transform.GetChild(1).GetComponent<Text>().text = pControl.ValueIntoString(enemies[i].curHealth, false) + " /\n" + pControl.ValueIntoString(enemies[i].maxHealth, false);
                }
                break;
            case 4:
                for (int i = 0; i < 4; i++)
                {
                    enemyObjects[i].transform.position = new Vector3((i * 60) + 60, 400, 0);
                    enemyObjects[i].transform.GetChild(0).GetComponent<Text>().text = "Lvl " + enemies[i].level + " " + enemies[i].name;
                    enemyObjects[i].transform.GetChild(1).GetComponent<Text>().text = pControl.ValueIntoString(enemies[i].curHealth, false) + " /\n" + pControl.ValueIntoString(enemies[i].maxHealth, false);
                }
                break;
            case 3:
                for (int i = 0; i < 3; i++)
                {
                    enemyObjects[i].transform.position = new Vector3((i * 75) + 75, 400, 0);
                    enemyObjects[i].GetComponentInChildren<Slider>().transform.localScale = new Vector3(3, 1, 1);
                    enemyObjects[i].transform.GetChild(0).GetComponent<Text>().text = "Lvl " + enemies[i].level + " " + enemies[i].name;
                    enemyObjects[i].transform.GetChild(1).GetComponent<Text>().text = pControl.ValueIntoString(enemies[i].curHealth, false) + " /\n" + pControl.ValueIntoString(enemies[i].maxHealth, false);
                }
                break;
            case 2:
                for (int i = 0; i < 2; i++)
                {
                    enemyObjects[i].transform.position = new Vector3((i * 100) + 100, 400, 0);
                    enemyObjects[i].GetComponentInChildren<Slider>().transform.localScale = new Vector3(4, 1, 1);
                    enemyObjects[i].transform.GetChild(0).GetComponent<Text>().text = "Lvl " + enemies[i].level + " " + enemies[i].name;
                    enemyObjects[i].transform.GetChild(1).GetComponent<Text>().text = pControl.ValueIntoString(enemies[i].curHealth, false) + " /\n" + pControl.ValueIntoString(enemies[i].maxHealth, false);
                }
                break;
            case 1:
                enemyObjects[0].transform.position = new Vector3(150, 400, 0);
                enemyObjects[0].GetComponentInChildren<Slider>().transform.localScale = new Vector3(5, 1, 1);
                enemyObjects[0].transform.GetChild(0).GetComponent<Text>().text = "Lvl " + enemies[0].level + " " + enemies[0].name;
                enemyObjects[0].transform.GetChild(1).GetComponent<Text>().text = pControl.ValueIntoString(enemies[0].curHealth, false) + " /\n" + pControl.ValueIntoString(enemies[0].maxHealth, false);
                break;
        }
    }

    public void DamagePerSec()
    {
        if (pControl.playerCreated[1] == true && pControl.p1stats[1] != 0)
        {
            enemies[0].curHealth -= pControl.p1stats[1] / 10;
            enemyObjects[0].transform.GetChild(1).GetComponent<Text>().text = pControl.ValueIntoString(enemies[0].curHealth, false) + " /\n" + pControl.ValueIntoString(enemies[0].maxHealth, false);
            enemyObjects[0].GetComponentInChildren<Slider>().value = Mathf.Floor((((float)enemies[0].curHealth / (float)enemies[0].maxHealth)) * 100);
            
        }
        if (pControl.playerCreated[2] && pControl.p2stats[1] != 0)
        {
            enemies[0].curHealth -= pControl.p2stats[1] / 10;
            enemyObjects[0].transform.GetChild(1).GetComponent<Text>().text = pControl.ValueIntoString(enemies[0].curHealth, false) + " /\n" + pControl.ValueIntoString(enemies[0].maxHealth, false);
            enemyObjects[0].GetComponentInChildren<Slider>().value = Mathf.Floor((((float)enemies[0].curHealth / (float)enemies[0].maxHealth)) * 100);
            
        }
        if (pControl.playerCreated[3] && pControl.p3stats[1] != 0)
        {
            enemies[0].curHealth -= pControl.p3stats[1] / 10;
            enemyObjects[0].transform.GetChild(1).GetComponent<Text>().text = pControl.ValueIntoString(enemies[0].curHealth, false) + " /\n" + pControl.ValueIntoString(enemies[0].maxHealth, false);
            enemyObjects[0].GetComponentInChildren<Slider>().value = Mathf.Abs(((float)enemies[0].curHealth / (float)enemies[0].maxHealth) * 100);
            
        }
        if (pControl.playerCreated[4] && pControl.p4stats[1] != 0)
        {
            enemies[0].curHealth -= pControl.p4stats[1] / 10;
            enemyObjects[0].transform.GetChild(1).GetComponent<Text>().text = pControl.ValueIntoString(enemies[0].curHealth, false) + " /\n" + pControl.ValueIntoString(enemies[0].maxHealth, false);
            enemyObjects[0].GetComponentInChildren<Slider>().value = Mathf.Abs(((float)enemies[0].curHealth / (float)enemies[0].maxHealth) * 100);
            
        }
        if (enemies[0].curHealth <= 0)
        {
            killEnemy(0);
        }
    }

    IEnumerator Autotick()
    {
        while (true)
        {
            DamagePerSec();
            yield return new WaitForSeconds(0.1f);
        }
    }

}


public class Enemy
{
    public int level { get; set; }
    public double maxHealth { get; set; }
    public double curHealth { get; set; }
    public int damage { get; set; }
    public string name { get; set; }

    public Enemy()
    {
        GlobalStats glblstats = GameObject.Find("StatsController").GetComponent<GlobalStats>();
        MapController mapController = GameObject.Find("EnemyPanel").GetComponent<MapController>();
        this.level = ((mapController.curMap * 10) + mapController.mapLevel);
        this.maxHealth = (100 * Mathf.Pow(1.3f, this.level-1));
        this.curHealth = maxHealth;
        this.damage = (int)(((15 * this.level)-5) * Mathf.Pow(1.2f, this.level-1));

        switch(Random.Range(1, 6))
        {
            case 1:
                this.name = "Orc";
                break;
            case 2:
                this.name = "Goblin";
                break;
            case 3:
                this.name = "Elf";
                break;
            case 4:
                this.name = "Wolf";
                break;
            case 5:
                this.name = "Slime";
                break;
        }
    }
}
