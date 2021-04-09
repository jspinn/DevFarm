using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private BuildManager buildManager;
    [SerializeField] private List<DeskNode> deskNodes;

    void Start() {
        buildManager = BuildManager.instance;
    }

    public void SaveGame() {
        SaveSystem.SaveData(deskNodes);

        Debug.Log("Game saved");
    }

    public void LoadData() {
        GameData data = SaveSystem.LoadData();

        for (int i = 0; i < deskNodes.Count; i++) {
            deskNodes[i].LoadDesk(data.deskNodeDeskTypes[i]);
            deskNodes[i].LoadDev(data.devs[i]);
        }

        Debug.Log("Game loaded");
    }
}
