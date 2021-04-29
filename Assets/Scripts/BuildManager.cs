using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public bool mouseHover;

    private DeskNode selectedNode;
    public DeskBlueprint deskBlueprint;
    [SerializeField] private NodeUI nodeUI;

    [SerializeField] private GameObject devPrefab;

    public int devHireCost;

    [SerializeField] private GameObject player;
    public PlayerStats playerStats;

    void Awake() {
        if (instance != null) {
            Debug.LogError("More than one BuildManager in scene.");
        }

        instance = this;
    }

    void Start() {
        playerStats = player.GetComponent<PlayerStats>();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0) && !mouseHover && !EventSystem.current.IsPointerOverGameObject()) {
            DeselectNode();
        }
    }

    public GameObject GetDeskToBuild(DeskNode node) {

        int deskTypeIndex = deskBlueprint.getDeskTypeIndex(node.desk);

        if (deskTypeIndex + 1 >= DeskBlueprint.deskTypes.Length) {
            return null;
        }

        return deskBlueprint.prefabs[deskTypeIndex + 1];
    }

    public GameObject GetDeskToLoad(int deskTypeIndex) {
        if (deskTypeIndex > -1) {
            return deskBlueprint.prefabs[deskTypeIndex];
        }
        
        Debug.LogError("Desk Type to load not found");
        return null;
    }

    public GameObject GetDevToHire() {
        // Can replace this to implement dev upgrades (just like desk upgrades)
        return devPrefab;
    }

    
    public void SelectNode(DeskNode node) {
        selectedNode = node;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode() {

        selectedNode = null;
        
        nodeUI.Hide();
    }

    
}
