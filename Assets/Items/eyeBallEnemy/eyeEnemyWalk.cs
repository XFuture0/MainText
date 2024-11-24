using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeEnemyWalk : State
{
    public override void OnEnter(eyeBallEnemy nowEnemy)
    {
        nowEnemy.anim.SetBool("Walk", true);
    }
    public override void LogicUpdate(eyeBallEnemy nowEnemy)
    {
        if (nowEnemy.Time_Count <= 0)
        {
            nowEnemy.SwitchState(StateType.Rush);
        }
        if(nowEnemy.Time_Count <= 0.5)
        {
            nowEnemy.eyeSign.SetActive(true);
        }
    }
    public override void PhysicsUpdate(eyeBallEnemy nowEnemy)
    {
        nowEnemy.FindPlayerEvent.RaiseEvent();
    }
    public override void OnExit(eyeBallEnemy nowEnemy)
    {
        nowEnemy.anim.SetBool("Walk", false);
        nowEnemy.eyeSign.SetActive(false);
    }
}
