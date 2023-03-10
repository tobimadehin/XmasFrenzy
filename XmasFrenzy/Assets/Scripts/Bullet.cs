using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rigid;
    private float timer = 2; 
    private float lastTimeUpdate;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Destroyer();
    }

    private void FixedUpdate()
    {
        ForwardMovement();
    }

    private void ForwardMovement()
    {
        rigid.AddForce(this.transform.forward * 50);
    }

    private void Destroyer()
    {
        if (timer > 0)
        {
            if (Time.time - lastTimeUpdate > 1)
            {
                timer--;
                lastTimeUpdate = Time.time;
            }
        }

        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage();
        }

        Destroy(this.gameObject);
    }
}
