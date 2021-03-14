using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this cs file has a desk class that defines different desk types
//then a function to show the cost of each desk 
// to do: create a function to get the sprite of each desk 
public class desks
{
   public enum DeskType 
   {
       standardDesk, efficientDesk, prettyDesk
   }

    public static int deskCost(DeskType deskType)
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
