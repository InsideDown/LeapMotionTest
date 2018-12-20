using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{

    protected EventManager() { }

    public delegate void StringMessageAction(string txtString);
    public static event StringMessageAction OnLogEvent;

    public delegate void SubmitAnswerAction();
    public static event SubmitAnswerAction OnSubmitAnswerEvent;


    public void LogEvent(string txtString)
    {
        if (OnLogEvent != null)
            OnLogEvent(txtString);
    }

    public void SubmitAnswer()
    {
        if (OnSubmitAnswerEvent != null)
            OnSubmitAnswerEvent();
    }
}