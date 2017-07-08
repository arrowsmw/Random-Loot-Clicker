using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPanelController : MonoBehaviour {

    private GameObject panel1;
    private GameObject panel2;
    private GameObject panel3;
    private GameObject panel4;
    private GameObject c1invpanel;
    private GameObject c2invpanel;
    private GameObject c3invpanel;
    private GameObject c4invpanel;
    private Player1Stats p1stats;
    private Player2Stats p2stats;
    private Player3Stats p3stats;
    private Player4Stats p4stats;
    private GlobalStats glblstats;

	void Start ()
    {
        panel1 = GameObject.Find("CharacterPanel1");
        panel2 = GameObject.Find("CharacterPanel2");
        panel3 = GameObject.Find("CharacterPanel3");
        panel4 = GameObject.Find("CharacterPanel4");
        c1invpanel = GameObject.Find("C1InvPanel");
        c2invpanel = GameObject.Find("C2InvPanel");
        c3invpanel = GameObject.Find("C3InvPanel");
        c4invpanel = GameObject.Find("C4InvPanel");
        glblstats = GameObject.Find("StatsController").GetComponent<GlobalStats>();
        p1stats = GameObject.Find("P1Stats").GetComponent<Player1Stats>();
        p2stats = GameObject.Find("P2Stats").GetComponent<Player2Stats>();
        p3stats = GameObject.Find("P3Stats").GetComponent<Player3Stats>();
        p4stats = GameObject.Find("P4Stats").GetComponent<Player4Stats>();

        panel2.transform.localScale = new Vector3(0, 0, 0);
        panel3.transform.localScale = new Vector3(0, 0, 0);
        panel4.transform.localScale = new Vector3(0, 0, 0);

        c1invpanel.transform.localScale = new Vector3(0, 0, 0);
        c2invpanel.transform.localScale = new Vector3(0, 0, 0);
        c3invpanel.transform.localScale = new Vector3(0, 0, 0);
        c4invpanel.transform.localScale = new Vector3(0, 0, 0);
        //panel2.SetActive(false);
        //panel3.SetActive(false);
        //panel4.SetActive(false);
    }

    public void OnPanel1Clicked()
    {
        panel1.transform.localScale = new Vector3(1, 1, 1);
        panel2.transform.localScale = new Vector3(0, 0, 0);
        panel3.transform.localScale = new Vector3(0, 0, 0);
        panel4.transform.localScale = new Vector3(0, 0, 0);
        p1stats.active = true;
        p2stats.active = false;
        p3stats.active = false;
        p4stats.active = false;
    }

    public void OnPanel2Clicked()
    {
        panel1.transform.localScale = new Vector3(0, 0, 0);
        panel2.transform.localScale = new Vector3(1, 1, 1);
        panel3.transform.localScale = new Vector3(0, 0, 0);
        panel4.transform.localScale = new Vector3(0, 0, 0);
        p1stats.active = false;
        p2stats.active = true;
        p3stats.active = false;
        p4stats.active = false;
    }

    public void OnPanel3Clicked()
    {
        panel1.transform.localScale = new Vector3(0, 0, 0);
        panel2.transform.localScale = new Vector3(0, 0, 0);
        panel3.transform.localScale = new Vector3(1, 1, 1);
        panel4.transform.localScale = new Vector3(0, 0, 0);
        p1stats.active = false;
        p2stats.active = false;
        p3stats.active = true;
        p4stats.active = false;
    }

    public void OnPanel4Clicked()
    {
        panel1.transform.localScale = new Vector3(0, 0, 0);
        panel2.transform.localScale = new Vector3(0, 0, 0);
        panel3.transform.localScale = new Vector3(0, 0, 0);
        panel4.transform.localScale = new Vector3(1, 1, 1);
        p1stats.active = false;
        p2stats.active = false;
        p3stats.active = false;
        p4stats.active = true;
    }

    public void OnCreateCharacter1Clicked()
    {
        c1invpanel.transform.localScale = new Vector3(1, 1, 1);
        p1stats.active = true;
        p1stats.created = true;
        AddItemButton btn = GameObject.Find("AddItem").GetComponent<AddItemButton>();
        btn.createStarterItem();
    }

    public void OnCreateCharacter2Clicked()
    {
        if(glblstats.playerLevel >= 20)
        {
            c2invpanel.transform.localScale = new Vector3(1, 1, 1);
            p2stats.active = true;
            p2stats.created = true;
        }
    }

    public void OnCreateCharacter3Clicked()
    {
        if(glblstats.playerLevel >= 40)
        {
            c3invpanel.transform.localScale = new Vector3(1, 1, 1);
            p3stats.active = true;
            p3stats.created = true;
        }
    }

    public void OnCreateCharacter4Clicked()
    {
        if(glblstats.playerLevel >= 60)
        {
            c4invpanel.transform.localScale = new Vector3(1, 1, 1);
            p4stats.active = true;
            p4stats.created = true;

        }
    }


}
