using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitState : State
{
    public override void OnEnter(eyeBallEnemy nowEnemy)
    {
        nowEnemy.rb.velocity = Vector3.zero;
    }
    public override void LogicUpdate(eyeBallEnemy nowEnemy)
    {

    }
    public override void PhysicsUpdate(eyeBallEnemy nowEnemy)
    {

    }
    public override void OnExit(eyeBallEnemy nowEnemy)
    {
        
    }
}
