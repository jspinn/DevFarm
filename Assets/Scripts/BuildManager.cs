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

    void Awake() {
        if (instance != null) {
            Debug.LogError("More than one BuildManager in scene.");
        }

        instance = this;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0) && !mouseHover && !EventSystem.current.IsPointerOverGameObject()) {
            DeselectNode();
        }
    }

    void Start() {
    }

    public GameObject GetDeskToBuild(DeskNode node) {

        int deskTypeIndex = deskBlueprint.getDeskTypeIndex(node.desk);
        Debug.Log(deskTypeIndex);
        Debug.Log(DeskBlueprint.deskTypes.Length);


        if (deskTypeIndex + 1 >= DeskBlueprint.deskTypes.Length) {
            return null;
        }

        return deskBlueprint.prefabs[deskTypeIndex + 1];
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
