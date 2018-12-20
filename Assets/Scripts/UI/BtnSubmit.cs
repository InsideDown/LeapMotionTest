using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSubmit : MonoBehaviour {

    public GameObject BtnOff;
    public GameObject BtnOn;

    private bool _IsActive = false;

    private void Awake()
    {
        SubmitOff();
    }

    public void SubmitOn()
    {
        if (!_IsActive)
        {
            BtnOff.SetActive(false);
            BtnOn.SetActive(true);
            _IsActive = true;
            StartCoroutine(SubmitAnswer());
        }
    }

    IEnumerator SubmitAnswer()
    {
        EventManager.Instance.SubmitAnswer();
        yield return new WaitForSeconds(2.0f);
        _IsActive = false;
    }

    public void SubmitOff()
    { 
        BtnOff.SetActive(true);
        BtnOn.SetActive(false);
    }

}
