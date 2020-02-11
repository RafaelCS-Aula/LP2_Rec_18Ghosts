using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using lp2_rec_ghosts.Model.BridgeClasses;

public class GameStarter : MonoBehaviour
{

    [SerializeField]
    private GameObject RenderControlPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GameController.SetupGame();
        RenderControlPrefab.SetActive(true);
    }

    
}
