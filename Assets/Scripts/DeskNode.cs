﻿using UnityEngine;


public class DeskNode : MonoBehaviour
{

    [SerializeField] private Color hoverColor;
    [SerializeField] private Color clickColor;
    [SerializeField] private Vector3 positionOffset;

    // which desk is on this node
    public GameObject desk;
    // Which dev is on this node
    public GameObject dev;

    private SpriteRenderer render;
    private Color defaultColor;
    private BuildManager buildManager;

    private bool mouseHover;

    void Start() {
        render = GetComponent<SpriteRenderer>();
        defaultColor = render.color;
        buildManager = BuildManager.instance;
        
    }

    void Awake() {
        buildManager = BuildManager.instance;
    }
    

   void OnMouseEnter() {
        FindObjectOfType<AudioManager>().Play("menu_click");
        render.color = hoverColor;
        buildManager.mouseHover = true;

   }

   void OnMouseExit() {
        render.color = defaultColor;

        buildManager.mouseHover = false;
   }

   void OnMouseDown() {
        render.color = clickColor;
        buildManager.SelectNode(this);
        
   }

   void OnMouseUp() {
       render.color = hoverColor;
   }

   public Vector3 GetBuildPosition() {
       return transform.position + positionOffset;
   }

   public void BuildDesk() {
        FindObjectOfType<AudioManager>().Play("money");
        GameObject deskToBuild = buildManager.GetDeskToBuild(this);

        if (deskToBuild == null) {
            Debug.LogError("Max upgrade already bought.");
            return;
        }

        int deskCost = buildManager.deskBlueprint.costs[buildManager.deskBlueprint.getDeskTypeIndex(deskToBuild)];

        if (buildManager.playerStats.coins < deskCost) {
            Debug.LogError("Insufficient money to build");
            return;
        }

        if (desk != null) {
            Destroy(desk);
        }
        GameObject newDesk = (GameObject)Instantiate(buildManager.GetDeskToBuild(this), GetBuildPosition(), transform.rotation);
        desk = newDesk;
        buildManager.playerStats.RemoveCoins(deskCost);
   }

   public void LoadDesk(int deskTypeIndex) {
        if (deskTypeIndex != -1) {
            GameObject newDesk = (GameObject)Instantiate(buildManager.GetDeskToLoad(deskTypeIndex), GetBuildPosition(), transform.rotation);
            desk = newDesk;
        }
   }

   public void HireDev() {
        if (dev != null) {
            Debug.LogError("Dev already hired.");
        }

        if (desk == null) {
            Debug.LogError("Desk needed to hire Dev.");
        }

        if (buildManager.playerStats.coins < buildManager.devHireCost) {
            Debug.LogError("Insufficient money to hire");
        }
        FindObjectOfType<AudioManager>().Play("money");
        buildManager.playerStats.RemoveCoins(buildManager.devHireCost);

        GameObject newDev = (GameObject)Instantiate(buildManager.GetDevToHire(), GetBuildPosition(), transform.rotation);
        dev = newDev;
        MoneySpawner spawner = dev.GetComponent<MoneySpawner>();
        spawner.SetDelay(buildManager.deskBlueprint.timeToMakeMoney[getDeskTypeIndex()]);
   }

   public void LoadDev(int devTypeIndex) {
        if (devTypeIndex != -1) {
            GameObject newDev = (GameObject)Instantiate(buildManager.GetDevToHire(), GetBuildPosition(), transform.rotation);
            dev = newDev;
            MoneySpawner spawner = dev.GetComponent<MoneySpawner>();
            spawner.SetDelay(buildManager.deskBlueprint.timeToMakeMoney[getDeskTypeIndex()]);
       }

   }

   public int getDeskTypeIndex () {
       return buildManager.deskBlueprint.getDeskTypeIndex(desk);
   }
}
