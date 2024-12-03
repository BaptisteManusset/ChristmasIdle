using UnityEngine;

public abstract class State : MonoBehaviour
{
    public abstract void OnEnter();

    public abstract void UpdateState();

    public abstract void OnExit();
}