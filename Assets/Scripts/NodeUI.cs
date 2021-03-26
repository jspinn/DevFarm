using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NodeUI : MonoBehaviour
{

    [SerializeField] private GameObject uiCanvas;
    private BuildManager buildManager;
    private DeskNode target;

    [SerializeField] private TextMeshProUGUI buildButtonText;
    [SerializeField] private TextMeshProUGUI buildCostText;
    [SerializeField] private Button buildButton;

    void Start() {
        buildManager = BuildManager.instance;
    }


    public void SetTarget (DeskNode t) {

        target = t;
        transform.position = target.GetBuildPosition();
        uiCanvas.SetActive(true);

        int currDeskTypeIndex = buildManager.deskBlueprint.getDeskTypeIndex(target.desk);

        if (currDeskTypeIndex + 1 >= DeskBlueprint.deskTypes.Length) {
            buildButtonText.SetText("MAX");
            buildCostText.SetText("UPGRADE");
            buildButton.interactable = false;
            return;
        }

        int buildCost = buildManager.deskBlueprint.costs[currDeskTypeIndex + 1];
        buildButton.interactable = true;

        if (currDeskTypeIndex < 0) {
            buildButtonText.SetText("Build");
        }
        else {
            buildButtonText.SetText("Upgrade");
        }

        buildCostText.SetText("$" + buildCost);
        
    }

    public void Hide() {
        target = null;
        uiCanvas.SetActive(false);
    }

    public void Build() {
        target.BuildDesk();
        buildManager.SelectNode(target);
    }


}
