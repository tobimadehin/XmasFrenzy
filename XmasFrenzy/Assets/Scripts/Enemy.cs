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
    [HideInInspector] public float health ;

    //Private
    [SerializeField] private Player player;
    private Rigidbody rigid;
    private CustomUtilities utilities;
    private bool isProximityClose;
    private float timer, lastTimeUpdate;

    //Protected
    protected EnemyState enemyState = EnemyState.Idle;
    protected float damage = 5;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        utilities = player.utilities;
    }

    void Start()
    {
        
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
                timer++;
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
