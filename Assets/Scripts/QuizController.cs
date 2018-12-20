using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuizController : MonoBehaviour {

    [Serializable]
    public struct Answer
    {
        public string AnswerStr;
        public bool IsCorrectAnswer;
    }

    [Serializable]
    public struct QuestionStruct
    {
        public string QuestionStr;
        public List<Answer> AnswersList;
    }

    public TextMeshPro HeaderText;
    public TextMeshPro QuestionText;
    public List<Question> AnswerList = new List<Question>();

    public List<QuestionStruct> QuestionStructList = new List<QuestionStruct>();
    
    public int Length
    {
        get
        {
            return QuestionStructList.Count;
        }
    }

    private void Awake()
    {
        if (AnswerList == null)
            throw new System.Exception("A AnswerList must be defined");

        if (QuestionStructList == null)
            throw new System.Exception("A QuestionStructList must be defined");
    }


    public void SetQuestion(int questionInt)
    {
        if(questionInt != null)
        {
            if (questionInt >= 0 && questionInt < QuestionStructList.Count)
            {
                SetHeader(questionInt);
                SetAnswers(questionInt);
            }
        }
    }

    void SetAnswers(int questionInt)
    {
        List<Answer> answersList = QuestionStructList[questionInt].AnswersList;
        for(int i = 0; i < answersList.Count; i++)
        {
            string curAnswer = answersList[i].AnswerStr;
            Question curAnswerObj = AnswerList[i];
            curAnswerObj.SetAnswer(curAnswer, (i * 0.2f) + 0.4f);
            
        }
    }

    void SetHeader(int questionInt)
    {
        HeaderText.text = "Question " + (questionInt + 1);
        QuestionText.text = QuestionStructList[questionInt].QuestionStr;
        QuestionAnim headerAnim = HeaderText.GetComponent<QuestionAnim>();
        QuestionAnim questionAnim = QuestionText.GetComponent<QuestionAnim>();
        headerAnim.AnimIn();
        questionAnim.AnimIn(0.2f);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
