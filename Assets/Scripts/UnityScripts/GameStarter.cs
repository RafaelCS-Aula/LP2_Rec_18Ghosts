using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using lp2_rec_ghosts.Model.BridgeClasses;

/// <summary>
/// Monobehaviour in charge of starting the game after initializing the 
/// implementation scripts.
/// </summary>
public class GameStarter : MonoBehaviour
{
    /// <summary>
    /// The implementation scripts stored in prefabs.
    /// </summary>
    [SerializeField]
    private GameObject RenderControlPrefab, InputControlPrefab;

    // Start is called before the first frame update
    void Awake()
    {

        RenderControlPrefab.GetComponent<VisualController>().Initialize();
        InputControlPrefab.GetComponent<InputController>().Initialize();
        GameController.SetupGame();

    }

    
}
