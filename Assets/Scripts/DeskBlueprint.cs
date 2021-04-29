using UnityEngine;
using System;

[System.Serializable]
public class DeskBlueprint
{

    public static string[] deskTypes = {"StandardDesk",
                                        "PrettyDesk",
                                        "EfficientDesk"};

    
    public GameObject[] prefabs = new GameObject[deskTypes.Length];
    public int[] costs =  new int[deskTypes.Length];

    public float[] timeToMakeMoney = new float[deskTypes.Length];

    public int getDeskTypeIndex(GameObject desk) {
        if (desk == null) {
            return -1;
        }
        return Array.FindIndex(DeskBlueprint.deskTypes, d => d == desk.tag);
    }

}
