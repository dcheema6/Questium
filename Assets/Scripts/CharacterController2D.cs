using System;
using System.Collections;
using System.Collections.Generic;
using RPGM.Gameplay;
using UnityEngine;
using UnityEngine.U2D;

namespace RPGM.Gameplay
{
    public class CharacterController2D : MonoBehaviour
    {
        public float speed = 1;
        public float acceleration = 2;
        public Vector3 nextMoveCommand;
        public Animator animator;
        public bool flipX = false;
        [SerializeField] int health;
        [SerializeField] Projectile mainWeapon;
        [SerializeField] Projectile conditionalWeapon;
        public Transform target;

        new Rigidbody2D rigidbody2D;
        SpriteRenderer spriteRenderer;
        PixelPerfectCamera pixelPerfectCamera;

        enum State
        {
            Idle, Moving, Battle
        }
        bool turn;

        State state = State.Idle;
        Vector3 start, end;
        Vector2 currentVelocity;
        float startTime;
        float distance;
        float velocity;

        void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            pixelPerfectCamera = GameObject.FindObjectOfType<PixelPerfectCamera>();
        }

        void Update()
        {
            if (state == State.Battle)
            {
                BattleState();
            }
            else if (target != null)
            {
                Vector3 distanceV = target.position - transform.position;
                
                if (Math.Abs(distanceV.magnitude) > 1.0f)
                {
                    if (Math.Abs(distanceV.x) > Math.Abs(distanceV.y))
                    {
                        nextMoveCommand = new Vector3(distanceV.x, 0.0f) * acceleration;
                    }
                    else
                    {
                        nextMoveCommand = new Vector3(0.0f, distanceV.y) * acceleration;
                    }
                }
                else
                {
                    nextMoveCommand = Vector3.zero;
                }
            }

            switch (state)
            {
                case State.Idle:
                    IdleState();
                    break;
                case State.Moving:
                    MoveState();
                    break;
            }
        }

        void LateUpdate()
        {
            if (pixelPerfectCamera != null)
            {
                transform.position = pixelPerfectCamera.RoundToPixel(transform.position);
            }
        }

        public void TakeHit(int damage)
        {
            health -= damage;
        }

        public void ToBattle(Transform t)
        {
            state = State.Battle;
            mainWeapon.target = t;
            conditionalWeapon.target = t;
        }

        public void FirePrimary()
        {
            if (state == State.Battle)
                Instantiate(mainWeapon, transform.position + new Vector3(1.0f, 0.0f), transform.rotation);
        }

        public void FireConditional()
        {
            if (state == State.Battle)
                Instantiate(conditionalWeapon, transform.position + new Vector3(1.0f, 0.0f), transform.rotation);
        }

        public void SetTurn(bool t)
        {
            turn = t;
        }

        void BattleState()
        {
            nextMoveCommand = Vector3.zero;
            UpdateAnimator(nextMoveCommand);
        }

        void IdleState()
        {
            if (nextMoveCommand != Vector3.zero)
            {
                start = transform.position;
                end = start + nextMoveCommand;
                distance = (end - start).magnitude;
                velocity = 0;
                UpdateAnimator(nextMoveCommand);
                nextMoveCommand = Vector3.zero;
                state = State.Moving;
            }
        }

        void MoveState()
        {
            velocity = Mathf.Clamp01(velocity + Time.deltaTime * acceleration);
            UpdateAnimator(nextMoveCommand);
            rigidbody2D.velocity = Vector2.SmoothDamp(rigidbody2D.velocity,
                nextMoveCommand * speed, ref currentVelocity, acceleration, speed);
            spriteRenderer.flipX = rigidbody2D.velocity.x >= 0 ? true : false;
        }

        void UpdateAnimator(Vector3 direction)
        {
            if (animator)
            {
                animator.SetInteger("WalkX", direction.x < 0 ? -1 : direction.x > 0 ? 1 : 0);
                animator.SetInteger("WalkY", direction.y < 0 ? 1 : direction.y > 0 ? -1 : 0);
            }
        }
    }
}
