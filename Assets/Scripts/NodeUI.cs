using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NodeUI : MonoBehaviour
{

    [SerializeField] private GameObject deskCanvas;
    [SerializeField] private GameObject devCanvas;
    private BuildManager buildManager;
    private DeskNode target;

    [SerializeField] private TextMeshProUGUI buildButtonText;
    [SerializeField] private TextMeshProUGUI buildCostText;
    [SerializeField] private Button buildButton;

    [SerializeField] private TextMeshProUGUI hireDevCostText;

    [SerializeField] private Button hireButton;

    void Start() {
        buildManager = BuildManager.instance;
    }


    public void SetTarget (DeskNode t) {

        target = t;
        transform.position = target.GetBuildPosition();
        deskCanvas.SetActive(true);
        devCanvas.SetActive(false);

        int currDeskTypeIndex = buildManager.deskBlueprint.getDeskTypeIndex(target.desk);

        // Max desk upgrades already bought
        if (currDeskTypeIndex + 1 >= DeskBlueprint.deskTypes.Length) {
            buildButtonText.SetText("MAX");
            buildCostText.SetText("UPGRADE");
            buildButton.interactable = false;
        }
        else {
            // Get build cost from BuildManager cost field
            int buildCost = buildManager.deskBlueprint.costs[currDeskTypeIndex + 1];
            if (buildCost <= buildManager.playerStats.coins) {
                buildButton.interactable = true;
            }
            else {
                buildButton.interactable = false;
            }

            // No desk built yet
            if (currDeskTypeIndex < 0) {
                buildButtonText.SetText("Build");
            }
            // Desk already built
            else {
                buildButtonText.SetText("Upgrade");
            }

            buildCostText.SetText("$" + buildCost);
        }


        // Hire Button
        if (t.dev == null && t.desk != null) {
            devCanvas.SetActive(true);
            hireDevCostText.SetText("$" + buildManager.devHireCost);

            if (buildManager.devHireCost <= buildManager.playerStats.coins) {
                hireButton.interactable = true;
            }
            else {
                hireButton.interactable = false;
            }
        }
        
    }

    public void Hide() {
        target = null;
        deskCanvas.SetActive(false);
        devCanvas.SetActive(false);
    }

    public void Build() {
        target.BuildDesk();
        buildManager.SelectNode(target);
    }

    public void Hire() {
        target.HireDev();
        devCanvas.SetActive(false);
        buildManager.SelectNode(target);
    }


}
