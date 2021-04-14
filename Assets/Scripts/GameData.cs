using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    [SerializeField] private List<DeskNode> deskNodes;
    
    public List<int> deskNodeDeskTypes;
    public List<int> devs;

    public GameData (List<DeskNode> deskNodes)
    {
        deskNodeDeskTypes = new List<int>();
        devs = new List<int>();

        foreach (DeskNode node in deskNodes) {
            // Desk level type
            deskNodeDeskTypes.Add(node.getDeskTypeIndex());

            // Dev hired or not (Can be changed to dev type if dev upgrades added)
            if (node.dev != null) {
                devs.Add(0);
            }
            else {
                devs.Add(-1);
            }
        }
    }

}
