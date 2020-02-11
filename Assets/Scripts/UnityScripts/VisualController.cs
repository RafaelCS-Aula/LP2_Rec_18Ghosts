using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using lp2_rec_ghosts.Model.BridgeClasses;
using lp2_rec_ghosts.Model.Interfaces;
using lp2_rec_ghosts.Model.GameTypes;
using lp2_rec_ghosts.Model.Ghosts;
using lp2_rec_ghosts.Model.Enums;

public class VisualController : MonoBehaviour, IRenderer, IModelConnector
{

    [SerializeField]
    private GameObject GhostHolder;

    [SerializeField]
    private GameObject Player1GhostVisuals;


    [SerializeField]
    private GameObject Player2GhostVisuals;

    [SerializeField]
    private Color RedColor, BlueColor, YellowColor;

    [Tooltip("1 - RED, 2 - BLUE, 3- YELLOW")]
    [SerializeField]
    private GameObject[] Portals;

    [SerializeField]
    private Text MessagePrompt;

    [SerializeField]
    private Text DungeonList;

    [SerializeField]
    private Text GhostList;

    private List<GameObject> ghostsOnBoard = new List<GameObject>();


    public void Initialize()
    {

        RenderInfo.OutsideRenderer = this;

    }
    // Start is called before the first frame update
    void Start()
    {

        


    }


    public void DrawBoard(Dictionary<Vector, IBoardObject[]> board)
    {
        GhostObject currentGhost;
        GameObject spawnedGhost;
        Color spawnedGhostColor;
        IBoardObject[] tileSpace;
        GameObject ghostVisuals;
        Vector3 spawnPoint = new Vector3(0,0,0);

        for(int x = 1; x < 6; x++)
        {
            for(int y = 1; y < 6; y++ )
            {
                board.TryGetValue(new Vector(x,y), out tileSpace);
                currentGhost = tileSpace[1] as GhostObject;
                    // Give it the place to spawn
                    spawnPoint.x = x;
                    spawnPoint.y = y;

                // There's a ghost on that place on the board
                if(currentGhost != null)
                {
                    if(currentGhost.Owner.playerNumber == 1)
                        ghostVisuals = Player1GhostVisuals;
                    else
                        ghostVisuals = Player2GhostVisuals;

                    // Spawn him and put him in the scene.
                    spawnedGhost = Instantiate(
                        ghostVisuals, 
                        spawnPoint, 
                        transform.rotation, 
                        GhostHolder.transform );

                    // Get the color of the ghost
                    spawnedGhostColor = 
                        spawnedGhost.GetComponent<SpriteRenderer>().color;

                    // Apply it to the sprites
                    switch(currentGhost.MyColor)
                    {
                        case(Colors.RED):
                            spawnedGhostColor = RedColor;
                            break;
                        case(Colors.BLUE):
                            spawnedGhostColor = BlueColor;
                            break;
                        case(Colors.YELLOW):
                            spawnedGhostColor = YellowColor;
                            break;
                        default:
                            break;
                    }

                    ghostsOnBoard.Add(spawnedGhost);

                }
                else if(currentGhost == null)
                {
                    // There is no ghost there.
                    
                    // Check the board to see if there is a ghost sprite there
                    foreach(GameObject g in ghostsOnBoard)
                    {
                         // Get it out of there.
                        if(spawnPoint == g.transform.position)
                        {

                        ghostsOnBoard.Remove(g);
                        Destroy(g);

                        }

                    }
                }
                
            }


        }


    }

    public void DrawGhostList(GhostObject[][] ghostList)
    {
        // Dungeon List;
        string dungeonText = "";
        for(int i = 0; i < ghostList[3].Length; i++)
        {
            if(ghostList[3][i] != null)
                dungeonText += $"[{i}] {ghostList[3][i]}\n";
            else
                dungeonText += $"[{i}] ---- \n";

        }
        DungeonList.text = dungeonText;

        // Player inventory list
        string listText = "";
        for(int i = 0; i < 3; i++)
        {
            for(int x = 0; x < ghostList[i].Length; x++ )
            {
                if(ghostList[i][x] != null)
                    listText += $"[{i},{x}] {ghostList[i][x]}\n";
                else    
                    listText += $"[{i},{x}] ---- \n";
            }


        }
        GhostList.text = listText;

    }

    public void DrawMessage(string message)
    {
        MessagePrompt.text = message;
    }



}
