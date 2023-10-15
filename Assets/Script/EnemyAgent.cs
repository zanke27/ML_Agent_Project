using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class EnemyAgent : Agent
{
    [SerializeField] private Ball ball;
    private Rigidbody rb;
    [SerializeField] private float speed = 15;

    public override void Initialize()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void OnEpisodeBegin()
    {
        transform.localPosition = new Vector3(0, 0.75f, 10);
        ball.transform.localPosition = new Vector3(0, 0.75f, -5);
        ball.rb.velocity = Vector3.zero;

        ball.transform.rotation = Quaternion.Euler(0, Random.Range(-60f, 60f), 0);
        ball.rb.velocity = ball.transform.forward * speed;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(ball.transform.position);
        sensor.AddObservation(ball.transform.forward);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float leftRightAmount = 0f;
        leftRightAmount = actions.DiscreteActions[0];

        if (actions.DiscreteActions[0] == 1f)
        {
            leftRightAmount = -1;
        }
        else if (actions.DiscreteActions[0] == 2f)
        {
            leftRightAmount = 1;
        }

        rb.velocity = new Vector3(leftRightAmount, 0, 0) * speed;

        if (MaxStep > 0) AddReward(-1f / MaxStep);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        int leftRightAction = 0;

        if (Input.GetKey(KeyCode.A))
        {
            leftRightAction = 1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            leftRightAction = 2;
        }

        actionsOut.DiscreteActions.Array[0] = leftRightAction;
    }
}
