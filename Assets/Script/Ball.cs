using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Random.Range�Ἥ -60~60�� �������ְ� ����
    // ���� ������ ���� ����ؼ� ƨ�ܳ����°� ��������

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.velocity = Vector3.forward * 10f;
    }
}
