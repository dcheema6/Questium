using RPGM.Core;
using RPGM.Gameplay;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AIController : MonoBehaviour
{

    public void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(1);
    }
}