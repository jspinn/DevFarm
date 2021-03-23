using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    private void Start() { 
        DeskButton(desks.GetSprite(desks.DeskType.standardDesk), "Standard Desk", desks.deskCost(desks.deskCost.standardDesk), 0);
        DeskButton(desks.GetSprite(desks.DeskType.efficientDesk), "Efficient Desk", desks.deskCost(desks.deskCost.efficientDesk), 0);
        DeskButton(desks.GetSprite(desks.DeskType.prettyDesk), "Pretty Desk", desks.deskCost(desks.deskCost.prettyDesk), 0);
   }


    private void DeskButton(Sprite deskSprite, string DeskType, int deskCost, int positionIndex) {
        
        Transform upgradesTransform = Instantiate(deskTemplate, desks);
        RectTransform upgradesRectTransform = upgradesTransform.GetComponent<RectTransform>();

        float upgradesHeight = 30f;
        upgradesRectTransform.anchoredPosition = new Vector2(0, -upgradesHeight * positionIndex);

       upgradesTransform.Find("DeskType").GetComponent<TextMeshProUGUI>().SetText(DeskType);
       upgradesTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(deskCost.ToString());
        upgradesTransform.Find("deskImage").GetComponent<Image>().sprite = deskSprite;

    }

}
