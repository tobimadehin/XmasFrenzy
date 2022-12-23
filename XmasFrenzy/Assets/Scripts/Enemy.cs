using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected enum EnemyState
    {
        Idle, Hunting, Attacking
    };

    //Public
    public float speed;
    [HideInInspector] public float health;
    [HideInInspector] public Player player;

    //Private
    private Rigidbody rigid;
    private CustomUtilities utilities;
    private bool isProximityClose;
    private float lastTimeUpdate;

    //Protected
    protected EnemyState enemyState = EnemyState.Idle;
    protected float damage = 5;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        rigid = GetComponent<Rigidbody>();
        utilities = player.utilities;
    }

    void Start()
    {
        utilities.enemies.Add(this);
    }

    void Update()
    {
        AttackPlayer();
        EnemyDirection();
    }

    private void FixedUpdate()
    {
        FollowPlayer();
    }

    private void EnemyDirection()
    {
        this.transform.LookAt(player.transform.position, Vector3.up);
        this.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
    }

    private void FollowPlayer()
    {
        if (!isProximityClose)
        {
            rigid.velocity = transform.forward * speed;
        }
    }

    private void AttackPlayer()
    {
        if (isProximityClose)
        {
            rigid.velocity = Vector3.zero;

            if (Time.time - lastTimeUpdate > 1)
            {
                player.health -= damage;
                print("Damage! " + player.health + " remaining");
                lastTimeUpdate = Time.time;
            }
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyProximity"))
        {
            isProximityClose = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyProximity"))
        {
            isProximityClose = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyProximity"))
        {
            isProximityClose = false;
        }
    }
}
