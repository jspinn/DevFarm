﻿using UnityEngine;


public class DeskNode : MonoBehaviour
{

    [SerializeField] private Color hoverColor;
    [SerializeField] private Color clickColor;
    [SerializeField] private Vector3 positionOffset;

    // which desk is on this node
    public GameObject desk;

    private SpriteRenderer render;
    private Color defaultColor;
    private BuildManager buildManager;

    private bool mouseHover;

    void Start() {
        render = GetComponent<SpriteRenderer>();
        defaultColor = render.color;
        buildManager = BuildManager.instance;
        
    }
    

   void OnMouseEnter() {
        render.color = hoverColor;
        buildManager.mouseHover = true;

   }

   void OnMouseExit() {
        render.color = defaultColor;

        buildManager.mouseHover = false;
   }

   void OnMouseDown() {
        render.color = clickColor;

        buildManager.SelectNode(this);
        buildManager.BuildDesk(this);
        
   }

   void OnMouseUp() {
       render.color = hoverColor;
   }

   public Vector3 GetBuildPosition() {
       return transform.position + positionOffset;
   }
}
