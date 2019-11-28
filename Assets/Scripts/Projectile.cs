using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float timeToLive;
    [SerializeField] int damage;
    public Transform target;

    void Start()
    {
        Destroy(gameObject, timeToLive);
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.Normalize(target.position - transform.position) * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var a = other.transform.GetComponent<AIController>();
        var b = other.transform.GetComponent<RPGM.Gameplay.CharacterController2D>();

        if (a != null)
            a.TakeHit(damage);
        else if (b != null)
            b.TakeHit(damage);    
        else    
            return;

        print("HIT");
        Destroy(gameObject);
    }
}
