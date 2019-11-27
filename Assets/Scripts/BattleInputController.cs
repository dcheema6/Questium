using RPGM.Core;
using RPGM.Gameplay;
using UnityEngine;

public class BattleInputController : MonoBehaviour
{
    public float stepSize = 0.1f;
    GameModel model = Schedule.GetModel<GameModel>();

    void Update()
    {
        CharacterControl();
    }

    void CharacterControl()
    {
        
    }
}
