
using UnityEngine;

public class NodeUI : MonoBehaviour
{

    [SerializeField] private GameObject uiCanvas;
    private DeskNode target;

    public void SetTarget (DeskNode t) {

        target = t;
        transform.position = target.GetBuildPosition();
        uiCanvas.SetActive(true);

        if (target.desk != null) {

            switch (target.desk.tag) {
                case "StandardDesk":
                Debug.Log("StandardDesk Selected");
                // Change button text to upgrade, set price
                break;

                case "PrettyDesk":
                Debug.Log("PrettyDesk Selected");
                // Set upgrade cost
                break;

                case "EfficientDesk":
                Debug.Log("EfficientDesk Selected");
                // Set button to say "MAX"
                break;
            }

        }

    }

    public void Hide() {
        target = null;
        uiCanvas.SetActive(false);
    }


}
