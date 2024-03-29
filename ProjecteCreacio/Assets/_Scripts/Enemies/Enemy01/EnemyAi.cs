﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    // Start is called before the first frame update
    enum EState
    {
        Idle, Wander, Attack
    }

    EState currentState;
    float currentTime;
    Dictionary<EState, State> States;
    FSM01<EState> brain;
    void Start()
    {
        States = new Dictionary<EState, State>();

        States[EState.Idle].OnStay = IdleUpdate;
        States[EState.Wander].OnStay = WanderUpdate;
        States[EState.Attack].OnStay = AttackUpdate;

        States[EState.Idle].OnEnter = () => currentTime = 0.0f;

        States[EState.Wander].OnEnter = () =>
        {

        };

        States[EState.Attack].OnEnter = () =>
        {

        };
    }
    
    // Update is called once per frame
    private void Update()
    {
        States[currentState].OnStay?.Invoke();
        States[currentState].OnEnter?.Invoke();
        States[currentState].OnExit?.Invoke();
    }
    void IdleUpdate()
    { }
    void WanderUpdate()
    { }
    void AttackUpdate()
    { }

    void ChangeState (EState newState)
    {
        switch (currentState)
        {
            case EState.Idle:
                break;
            case EState.Wander:
                break;
            case EState.Attack:
                break;
        }

        switch (newState)
        {
            case EState.Idle:
                break;
            case EState.Wander:
                break;
            case EState.Attack:
                break;
        }
    }
}
