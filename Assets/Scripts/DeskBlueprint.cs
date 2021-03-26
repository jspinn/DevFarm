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

}
