using System;
using System.Collections;
using System.Collections.Generic;
using RPGM.Gameplay;
using UnityEngine;
using UnityEngine.U2D;

public class CharacterBattleControl : MonoBehaviour
{
    public float speed = 1;
    public float acceleration = 2;
    public Vector3 nextMoveCommand;
    public Animator animator;
    public bool flipX = false;

    new Rigidbody2D rigidbody2D;
    SpriteRenderer spriteRenderer;

    Vector3 start, end;
    Vector2 currentVelocity;
    float startTime;
    float distance;
    float velocity;

    void IdleState()
    {

    }

    void UpdateAnimator(Vector3 direction)
    {
        if (animator)
        {
            animator.SetInteger("WalkX", direction.x < 0 ? -1 : direction.x > 0 ? 1 : 0);
            animator.SetInteger("WalkY", direction.y < 0 ? 1 : direction.y > 0 ? -1 : 0);
        }
    }

    void Update()
    {
        IdleState();
    }

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
