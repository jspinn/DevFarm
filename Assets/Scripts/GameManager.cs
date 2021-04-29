using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private BuildManager buildManager;
    [SerializeField] private List<DeskNode> deskNodes;
    [SerializeField] private GameObject player;

    private PlayerStats playerStats;

    void Start() {
        buildManager = BuildManager.instance;
        playerStats = player.GetComponent<PlayerStats>();
        if (GlobalControl.Instance.loadGame) {
            LoadGame();
        }
    }

    public void SaveGame() {
        SaveSystem.SaveData(deskNodes, playerStats);

        Debug.Log("Game saved");
    }

    public void LoadGame() {
        GameData data = SaveSystem.LoadData();

        for (int i = 0; i < deskNodes.Count; i++) {
            deskNodes[i].LoadDesk(data.deskNodeDeskTypes[i]);
            deskNodes[i].LoadDev(data.devs[i]);
        }

        playerStats.AddCoins(data.coins);

        Debug.Log("Game loaded");
    }

    public void ChangeToScene(string SceneToChangeTo)
    {
        SceneManager.LoadScene(SceneToChangeTo);
    }

    public void LoadSaveScene(string SceneToChangeTo) {
        SceneManager.LoadScene(SceneToChangeTo);
        LoadGame();
    }
}
