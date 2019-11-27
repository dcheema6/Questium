using RPGM.Core;
using RPGM.Gameplay;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AIController : MonoBehaviour
{
    [SerializeField] GameControl gc;

    bool battleMode;

    void Start()
    {
        battleMode = false;
    } 

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (battleMode)
        {

        }
        else
        {
            gc.ToBattle(this);
            battleMode = true;
        }
    }
}
