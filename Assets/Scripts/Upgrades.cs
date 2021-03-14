using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//create the menu (desk template) for each desk 
public class Upgrades : MonoBehaviour
{
   private Transform desks;
   private Transform deskTemplate;

   private void Fun()
   {
       desks = transform.Find("desks");
       deskTemplate = desks.Find("deskTemplate");
       deskTemplate.gameObject.SetActive(false);
   }

    private void DeskButton(Sprite deskSprite, string DeskType, int deskCost){
        
    }

}
