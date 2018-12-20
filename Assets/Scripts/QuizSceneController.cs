using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizSceneController : MonoBehaviour {

    [SerializeField]
    private QuizController QuizControllerObj;

    private int _CurQuestion = 0;

	// Use this for initialization
	void Start () {
        StartDrawing();
       // StartCoroutine(DelayQuiz(2.0f));
	}

    private void OnEnable()
    {
        EventManager.OnSubmitAnswerEvent += EventManager_OnSubmitAnswerEvent;
    }

    private void OnDisable()
    {
        EventManager.OnSubmitAnswerEvent += EventManager_OnSubmitAnswerEvent;
    }

    private void EventManager_OnSubmitAnswerEvent()
    {
        _CurQuestion += 1;
        if(_CurQuestion >= QuizControllerObj.Length)
        {
            StartDrawing();
        }else
        {
            StartCoroutine(DelayQuiz(1.0f));
        }
    }

    void StartDrawing()
    {
        Debug.Log("removing everything");
    }

    IEnumerator DelayQuiz(float delay = 0f)
    {
        yield return new WaitForSeconds(delay);
        InitQuiz();
    }

    void InitQuiz()
    {
        QuizControllerObj.SetQuestion(_CurQuestion);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
