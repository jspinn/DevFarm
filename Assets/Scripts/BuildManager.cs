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
        if (node.desk == null) {
            return deskBlueprint.prefabs[0];
        }

        else {
            int deskTypeIndex = Array.FindIndex(DeskBlueprint.deskTypes, d => d == node.desk.tag);
            if (deskTypeIndex + 1 >= DeskBlueprint.deskTypes.Length) {
                return null;
            }
            return deskBlueprint.prefabs[deskTypeIndex + 1];
        }

    }

    public void BuildDesk(DeskNode node) {
        GameObject deskToBuild = GetDeskToBuild(node);

        if (deskToBuild == null) {
            Debug.LogError("Max upgrade already bought.");
            return;
        }

        if (node.desk != null) {
            Destroy(node.desk);
        }
        GameObject desk = (GameObject)Instantiate(GetDeskToBuild(node), node.GetBuildPosition(), transform.rotation);
        node.desk = desk;
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
