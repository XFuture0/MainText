using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    
    protected eyeBallEnemy currentEnemy;
    public abstract void OnEnter(eyeBallEnemy nowEnemy);
    public abstract void LogicUpdate(eyeBallEnemy nowEnemy);
    public abstract void PhysicsUpdate(eyeBallEnemy nowEnemy);
    public abstract void OnExit(eyeBallEnemy nowEnemy);
}
