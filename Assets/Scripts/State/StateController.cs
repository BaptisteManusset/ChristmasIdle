using UnityEngine;

public abstract class StateController : Singleton<StateController>
{
    State m_currentState;

    public State Current => m_currentState;

    protected virtual void Update()
    {
        if (m_currentState) m_currentState.UpdateState();
    }

    public void ChangeState(State a_newState)
    {
        if (m_currentState) m_currentState.OnExit();
        m_currentState = a_newState;
        if (m_currentState) m_currentState.OnEnter();
    }
}