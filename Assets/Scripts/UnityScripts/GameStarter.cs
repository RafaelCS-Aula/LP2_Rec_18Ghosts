using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using lp2_rec_ghosts.Model.BridgeClasses;

public class GameStarter : MonoBehaviour
{

    [SerializeField]
    private GameObject RenderControlPrefab, InputControlPrefab;

    // Start is called before the first frame update
    void Awake()
    {
        /*RenderControlPrefab.SetActive(false);
        InputControlPrefab.SetActive(false);
        RenderControlPrefab.SetActive(true);
        InputControlPrefab.SetActive(true);*/

        RenderControlPrefab.GetComponent<VisualController>().Initialize();
        InputControlPrefab.GetComponent<InputController>().Initialize();
        GameController.SetupGame();

    }

    
}
