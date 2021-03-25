using UnityEngine;

public class DeskNode : MonoBehaviour
{

    [SerializeField] private Color hoverColor;
    [SerializeField] private Color clickColor;
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private GameObject buildMenu;

    // which desk is on this node
    public GameObject desk;

    private SpriteRenderer render;
    private Color defaultColor;
    private BuildManager buildManager;

    void Start() {
        render = GetComponent<SpriteRenderer>();
        defaultColor = render.color;
        buildManager = BuildManager.instance;
        
    }
    

   void OnMouseEnter() {
        Debug.Log("Mouse Enter");
        render.color = hoverColor;
   }

   void OnMouseExit() {
        Debug.Log("Mouse Exit");
        render.color = defaultColor;
   }

   void OnMouseDown() {
        render.color = clickColor;

        if (desk != null) {
            // upgrade
        }
        else {
            buildManager.BuildDesk(this);
        }
   }

   void OnMouseUp() {
       render.color = hoverColor;
   }

   public Vector3 GetBuildPosition() {
       return transform.position + positionOffset;
   }
}
