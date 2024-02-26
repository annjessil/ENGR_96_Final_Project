using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { FreeRoam, Dialog}
public class SceneController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;

    GameState state;

    private void Update()
    {
        if (state == GameState.FreeRoam)
        {
            playerController.Update();

        } else if (state == GameState.Dialog)
        {

        }
    }

}
