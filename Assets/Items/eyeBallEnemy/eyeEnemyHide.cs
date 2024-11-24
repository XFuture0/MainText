using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeEnemyHide : State
{
    public override void OnEnter(eyeBallEnemy nowEnemy)
    {
        nowEnemy.anim.SetBool("Hide", true);
    }
    public override void LogicUpdate(eyeBallEnemy nowEnemy)
    {

    }
    public override void PhysicsUpdate(eyeBallEnemy nowEnemy)
    {

    }
    public override void OnExit(eyeBallEnemy nowEnemy)
    {
        nowEnemy.anim.SetBool("Hide", false);
        nowEnemy.FindPlayer.enabled = false;
    }
}
