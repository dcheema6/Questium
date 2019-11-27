using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    void onTriggerFight()
    {
        SceneManager.LoadScene(1);
    }
}
