using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject battleCamera;
    [SerializeField] RPGM.Gameplay.CharacterController2D playerController;

    AIController aiController;

    void Start()
    {
        mainCamera.SetActive(true);
        battleCamera.SetActive(false);
    }

    public void ToBattle(AIController aic)
    {
        aiController = aic;
        mainCamera.SetActive(false);
        battleCamera.SetActive(true);

        playerController.transform.position = new Vector2(27.5f, 0.25f);
        aiController.transform.position = new Vector2(34.0f, 0.25f);

        playerController.ToBattle(aiController.transform);
    }
}
