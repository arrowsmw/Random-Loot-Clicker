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
    private GlobalStats glblstats;
    private PlayerController pControl;

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
        pControl = GameObject.Find("StatsController").GetComponent<PlayerController>();

        panel2.transform.localScale = new Vector3(0, 0, 0);
        panel3.transform.localScale = new Vector3(0, 0, 0);
        panel4.transform.localScale = new Vector3(0, 0, 0);

        c1invpanel.transform.localScale = new Vector3(0, 0, 0);
        c2invpanel.transform.localScale = new Vector3(0, 0, 0);
        c3invpanel.transform.localScale = new Vector3(0, 0, 0);
        c4invpanel.transform.localScale = new Vector3(0, 0, 0);

    }

    public void OnPanel1Clicked()
    {
        panel1.transform.localScale = new Vector3(1, 1, 1);
        panel2.transform.localScale = new Vector3(0, 0, 0);
        panel3.transform.localScale = new Vector3(0, 0, 0);
        panel4.transform.localScale = new Vector3(0, 0, 0);

        pControl.playerActive[1] = true;
        pControl.playerActive[2] = false;
        pControl.playerActive[3] = false;
        pControl.playerActive[4] = false;

    }

    public void OnPanel2Clicked()
    {
        panel1.transform.localScale = new Vector3(0, 0, 0);
        panel2.transform.localScale = new Vector3(1, 1, 1);
        panel3.transform.localScale = new Vector3(0, 0, 0);
        panel4.transform.localScale = new Vector3(0, 0, 0);

        pControl.playerActive[1] = false;
        pControl.playerActive[2] = true;
        pControl.playerActive[3] = false;
        pControl.playerActive[4] = false;

    }

    public void OnPanel3Clicked()
    {
        panel1.transform.localScale = new Vector3(0, 0, 0);
        panel2.transform.localScale = new Vector3(0, 0, 0);
        panel3.transform.localScale = new Vector3(1, 1, 1);
        panel4.transform.localScale = new Vector3(0, 0, 0);

        pControl.playerActive[1] = false;
        pControl.playerActive[2] = false;
        pControl.playerActive[3] = true;
        pControl.playerActive[4] = false;

    }

    public void OnPanel4Clicked()
    {
        panel1.transform.localScale = new Vector3(0, 0, 0);
        panel2.transform.localScale = new Vector3(0, 0, 0);
        panel3.transform.localScale = new Vector3(0, 0, 0);
        panel4.transform.localScale = new Vector3(1, 1, 1);

        pControl.playerActive[1] = false;
        pControl.playerActive[2] = false;
        pControl.playerActive[3] = false;
        pControl.playerActive[4] = true;

    }

    public void OnCreateCharacter1Clicked()
    {
        c1invpanel.transform.localScale = new Vector3(1, 1, 1);

        pControl.playerCreated[1] = true;
        pControl.playerActive[1] = true;

        AddItemButton btn = GameObject.Find("AddItem").GetComponent<AddItemButton>();
        btn.createStarterItem();
    }

    public void OnCreateCharacter2Clicked()
    {
        if(glblstats.playerLevel >= 20)
        {
            c2invpanel.transform.localScale = new Vector3(1, 1, 1);

            pControl.playerCreated[2] = true;
            pControl.playerActive[2] = true;

        }
    }

    public void OnCreateCharacter3Clicked()
    {
        if(glblstats.playerLevel >= 40)
        {
            c3invpanel.transform.localScale = new Vector3(1, 1, 1);

            pControl.playerCreated[3] = true;
            pControl.playerActive[3] = true;

        }
    }

    public void OnCreateCharacter4Clicked()
    {
        if(glblstats.playerLevel >= 60)
        {
            c4invpanel.transform.localScale = new Vector3(1, 1, 1);

            pControl.playerCreated[4] = true;
            pControl.playerActive[4] = true;

        }
    }


}
