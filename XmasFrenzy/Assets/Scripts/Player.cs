using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Public
    public CustomUtilities utilities;
    [HideInInspector] public float health = 100;
    public GameObject bullet;
    [HideInInspector] public float damage;

    //Private
    private Rigidbody rigid;
    private float nextFire;
    private float fireRate = 0.1f;
    [SerializeField] private CursorBehaviour cursor;
    [SerializeField] private Transform bulletSpawnPoint;


    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        FaceCursor();
        Attack();
        Speed();
        CursorDistnce();
    }

    private void FixedUpdate()
    {
        Locomotion();
    }

    private void FaceCursor()
    {
        if (cursor.isRotationProximity)
        {
            transform.LookAt(cursor.transform.position);
        }
    }

    private void Locomotion()
    {
        bool isProximityClose = cursor.isProximityClose;

        if (!isProximityClose)
        {
            rigid.velocity = this.transform.forward * Speed();
        }

        else
        {
            rigid.velocity = Vector3.zero;
        }
    }

    private float Speed()
    {
        float speed = CursorDistnce();
        float f = speed * (5 / 3);
        speed += (f - 1);

        return speed;
    }

    private float CursorDistnce()
    {
        float cursorDistance;

        cursorDistance = Vector3.Distance(cursor.transform.position, this.transform.position);
        cursorDistance = Mathf.Clamp(cursorDistance, 0, 3);

        return cursorDistance;
    }

    private void Attack()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
    }
}
