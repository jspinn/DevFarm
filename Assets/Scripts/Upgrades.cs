using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
