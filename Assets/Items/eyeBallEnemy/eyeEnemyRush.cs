using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeEnemyRush : State
{
    public override void OnEnter(eyeBallEnemy nowEnemy)
    {
        nowEnemy.HitSth.enabled = true;
        nowEnemy.anim.SetBool("Rush", true);
    }
    public override void LogicUpdate(eyeBallEnemy nowEnemy)
    {
        if(nowEnemy.Time_Count <= 0)
        {
            nowEnemy.SwitchState(StateType.Walk);
        }
        nowEnemy.RushPlayer();
    }
    public override void PhysicsUpdate(eyeBallEnemy nowEnemy)
    {
        
    }
    public override void OnExit(eyeBallEnemy nowEnemy)
    {
        nowEnemy.CaremaImpulseEvent.RaiseEvent();
        nowEnemy.anim.SetBool("Rush", false);
        nowEnemy.HitSth.enabled = false;
    }
}
