using RPGM.Core;
using RPGM.Gameplay;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AIController : MonoBehaviour
{
    [SerializeField] GameControl gc;
    public int health;
    public Projectile mainWeapon;
    public Projectile conditionalWeapon;

    bool battleMode;
    bool turn;

    void Start()
    {
        battleMode = false;
    }

    public void SetTurn(bool t)
    {
        turn = t;
    }

    public void TakeHit(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            print("You Won!");
        }
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
