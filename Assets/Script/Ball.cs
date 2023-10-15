using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Random.Range�Ἥ -60~60�� �������ְ� ����
    // ���� ������ ���� ����ؼ� ƨ�ܳ����°� ��������

    public Rigidbody rb;

    [SerializeField] private PlayerAgent playerAgent;
    [SerializeField] private EnemyAgent enemyAgent;

    [SerializeField]
    private float speed = 5;

    private int playerScore = 0;
    private int enemyScore = 0;

    [SerializeField] private TextMeshProUGUI playerText;
    [SerializeField] private TextMeshProUGUI enemyText;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0, Random.Range(-60f, 60f), 0);
        rb.velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("EnemyMoveWall"))
        {
            enemyAgent.AddReward(0.1f);
        }
        else if (collision.collider.CompareTag("PlayerMoveWall"))
        {
            //playerAgent.AddReward(0.1f);
        }
        else if (collision.collider.CompareTag("PlayerDeadWall"))
        {
            enemyAgent.AddReward(1f);
            //playerAgent.AddReward(-1f);
            enemyScore++;
            enemyText.SetText("Enemy: " + enemyScore.ToString());

            enemyAgent.EndEpisode();

        }
        else if (collision.collider.CompareTag("EnemyDeadWall"))
        {
            enemyAgent.AddReward(-1f);
            //playerAgent.AddReward(1f);
            playerScore++;
            playerText.SetText("Player: " + playerScore.ToString());

            enemyAgent.EndEpisode();
        }
    }
}
