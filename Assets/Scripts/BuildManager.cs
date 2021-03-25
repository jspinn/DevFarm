using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake() {
        if (instance != null) {
            Debug.LogError("More than one BuildManager in scene.");
        }

        instance = this;
    }


    [SerializeField] GameObject standardDeskPrefab;

    private GameObject deskToBuild;

    void Start() {
        deskToBuild = standardDeskPrefab;
    }

    public GameObject GetDeskToBuild() {
        return deskToBuild;
    }

    public void BuildDesk(DeskNode node) {
        GameObject desk = (GameObject)Instantiate(deskToBuild, node.GetBuildPosition(), transform.rotation);
        node.desk = desk;
    }

    
}
