using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Random.Range�Ἥ -60~60�� �������ְ� ����
    // ���� ������ ���� ����ؼ� ƨ�ܳ����°� ��������

    Rigidbody rb;

    [SerializeField]
    private float speed = 5;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.AddForce(new Vector3(0, Random.Range(-60f, 60f), 0) * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("EnemyMoveWall"))
        {
            ReBounding(collision);
        }
        else if (collision.collider.CompareTag("PlayerMoveWall"))
        {
            ReBounding(collision);
        }
        else if (collision.collider.CompareTag("Wall"))
        {           
            ReBounding(collision);
        }
    }

    void ReBounding(Collision collision)
    {
        ContactPoint cp = collision.GetContact(0);
        Vector3 dir = transform.position - cp.point;

        rb.velocity = Vector3.zero;

        rb.AddForce((dir).normalized * speed);
    }
}
