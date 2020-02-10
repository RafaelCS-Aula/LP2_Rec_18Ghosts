using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using lp2_rec_ghosts.Model.BridgeClasses;
using lp2_rec_ghosts.Model.Interfaces;
using lp2_rec_ghosts.Model.GameTypes;
using lp2_rec_ghosts.Model.Ghosts;

public class VisualController : MonoBehaviour, IRenderer
{

    [SerializeField]
    private GameObject GhostHolder;

    [SerializeField]
    private GameObject Player1GhostVisuals;


    [SerializeField]
    private GameObject Player2GhostVisuals;

    [SerializeField]
    private Color[] VisualColor = new Color[3];

    [Tooltip("1 - RED, 2 - BLUE, 3- YELLOW")]
    [SerializeField]
    private GameObject[] Portals;

    [SerializeField]
    private Text MessagePrompt;

    [SerializeField]
    private Text DungeonList;

    [SerializeField]
    private Text GhostList;

    // Start is called before the first frame update
    void Awake()
    {

        RenderInfo.OutsideRenderer = this;

    }


    public void DrawBoard(Dictionary<Vector, IBoardObject[]> board)
    {



    }

    public void DrawGhostList(GhostObject[][] ghostList)
    {
        // Dungeon List;
        string dungeonText = "";
        for(int i = 0; i < ghostList.GetLength(3); i++)
        {
            if(ghostList[3][i] != null)
                dungeonText += $"[{i}] {ghostList[3][i]}";
            else
                dungeonText += $"[{i}] ---- ";

        }
        DungeonList.text = dungeonText;


        string listText = "";
        for(int i = 0; i < 3; i++)
        {
            for(int x = 0; x < ghostList.GetLength(i); x++ )
            {
                if(ghostList[i][x] != null)
                    listText += $"[{i},{x}] {ghostList[i][x]}";
                else    
                    listText += $"[{i},{x}] ---- ";
            }


        }
        GhostList.text = listText;

    }

    public void DrawMessage(string message)
    {
        MessagePrompt.text = message;
    }



}
