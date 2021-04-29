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

    [SerializeField] private int startingMoney;

    void Start() {
        buildManager = BuildManager.instance;
        playerStats = player.GetComponent<PlayerStats>();
        if (GlobalControl.Instance.loadGame) {
            LoadGame();
        }
        else {
            // Starting money for new game
            player.GetComponent<PlayerStats>().AddCoins(startingMoney);
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

}
