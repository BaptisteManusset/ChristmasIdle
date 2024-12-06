using UnityEngine;

public abstract class StateController : Singleton<StateController>
{
    private GameState m_currentState;

    public GameState Current => m_currentState;

    protected virtual void Update()
    {
        if (m_currentState) m_currentState.UpdateState();
    }

    public virtual void ChangeState(GameState a_newState)
    {
        Debug.Log("new state: " + a_newState.State);
        if (m_currentState) m_currentState.OnExit();
        m_currentState = a_newState;
        if (m_currentState) m_currentState.OnEnter();
    }
}