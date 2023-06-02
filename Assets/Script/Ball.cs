using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Random.Range써서 -60~60도 설정해주고 날려
    // 벽에 닿으면 각도 계산해서 튕겨나가는거 만들어야함

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
