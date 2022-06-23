using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM03<T> where T : Enum
{
    public T currentState;
    private Dictionary<T, State03> States;
    public FSM03(T initState)
    {
        States = new Dictionary<T, State03>();
        foreach (T e in Enum.GetValues(typeof(T)))
        {
            States.Add(e, new State03());
        }
        currentState = initState;
    }
    public void Update()
    {
        States[currentState].OnStay?.Invoke();
    }
    public void ChangeState(T newState)
    {
        States[currentState].OnExit?.Invoke();
        States[newState].OnEnter?.Invoke();
        currentState = newState;
    }
    public void SetOnStay(T state, Action f)
    {
        States[state].OnStay = f;
    }
    public void SetOnEnter(T state, Action f)
    {
        States[state].OnEnter = f;
    }
    public void SetOnExit(T state, Action f)
    {
        States[state].OnExit = f;
    }
}