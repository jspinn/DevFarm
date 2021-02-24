using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desks
{
   public enum DeskType 
   {
       standardDesk, efficientDesk, prettyDesk
   }

    public static int Cost(DeskType deskType)
    {
        switch(deskType)
        {
            default: 
            case DeskType.standardDesk:  return 100;
            case DeskType.efficientDesk: return 500;
            case DeskType.prettyDesk: return 1000;
        }
    }

   

}
