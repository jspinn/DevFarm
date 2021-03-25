using UnityEngine;

public class DeskNode : MonoBehaviour
{
   void OnMouseEnter() {
       Debug.Log("Mouse Enter");
   }

   void OnMouseExit() {
       Debug.Log("Mouse Exit");
   }

   void OnMouseDown() {
       Debug.Log("Mouse Click");
   }
}
