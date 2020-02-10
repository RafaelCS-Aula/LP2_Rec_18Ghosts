using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using lp2_rec_ghosts.Model.BridgeClasses;
using lp2_rec_ghosts.Model.Interfaces;
using lp2_rec_ghosts.Model.GameTypes;
using lp2_rec_ghosts.Model.Ghosts;

public class VisualController : MonoBehaviour, IRenderer
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void DrawBoard(Dictionary<Vector, IBoardObject[]> board)
    {
        throw new System.NotImplementedException();
    }

    public void DrawGhostList(GhostObject[][] ghostList)
    {
        throw new System.NotImplementedException();
    }

    public void DrawMessage(string message)
    {
        throw new System.NotImplementedException();
    }



}
