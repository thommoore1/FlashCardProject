using UnityEngine;

public static class StateManager
{
    public static States currentState = States.Menu;

    public static void NewGameState(States newState)
    {
        OnMyStateExit(currentState);
        currentState = newState;
        OnMyStateEnter(currentState);
    }

    private static void OnMyStateEnter(States states)
    {
        Debug.Log("Entering state: " + states.ToString());
    }

    private static void OnMyStateExit(States states)
    {
        Debug.Log("Exiting state: " + states.ToString());
    }
}
