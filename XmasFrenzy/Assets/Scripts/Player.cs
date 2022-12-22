using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Public
    public float speed;
    public CustomUtilities utilities;
    [HideInInspector] public float health = 100;

    //Private
    private Rigidbody rigid;
    [SerializeField] private CursorBehaviour cursor;


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
            rigid.velocity = this.transform.forward * speed;
        }

        else
        {
            rigid.velocity = Vector3.zero;
        }
    }
}
