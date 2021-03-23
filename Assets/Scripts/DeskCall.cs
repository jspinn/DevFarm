using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskCall : MonoBehaviour
{
   private static DeskCall _i;

   public static DeskCall Instance {
       get{
           if(_i == null) _i = (Instantiate(Resources.Load("DeskCall")) as GameObject).GetComponent<DeskCall>();
           return _i;
       }
   }

   public Sprite standardDesk;
   public Sprite efficientDesk;
   public Sprite prettyDesk;
}
