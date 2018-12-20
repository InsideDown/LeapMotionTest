using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Question : MonoBehaviour {

    public TextMeshPro TextMeshProObj;
    public GameObject CheckboxOff;
    public GameObject CheckboxOn;
    public GameObject GraphicContainer;

    private Vector3 _StartPos;
    private Vector3 _EndPos;
    private bool _IsChecked = false;
    private Color _StartColor;
    private float _TweenSpeed = 0.4f;
    private Vector3 _CurScale;

    private void Awake()
    {
        _EndPos = GraphicContainer.gameObject.transform.localPosition;
        _StartPos = new Vector3(_EndPos.x, _EndPos.y - 1, _EndPos.z);
        _StartColor = TextMeshProObj.color;
        _StartColor.a = 0;
        _CurScale = this.gameObject.transform.localScale;
        Hide();
    }

    public void SetAnswer(string answer, float delay)
    {
        Hide();
        TextMeshProObj.text = answer;
        StartCoroutine(AnimIn(delay));
    }

    private IEnumerator AnimIn(float delay = 0)
    {
        yield return new WaitForSeconds(delay);
        this.gameObject.transform.localScale = _CurScale;
        TextMeshProObj.DOFade(1, _TweenSpeed).SetDelay(delay);
        GraphicContainer.transform.DOLocalMoveY(_EndPos.y, _TweenSpeed).SetEase(Ease.OutQuad);
    }

    private void Hide()
    {
        _IsChecked = false;
        TextMeshProObj.color = _StartColor;
        this.gameObject.transform.localScale = Vector3.zero;
        GraphicContainer.transform.localPosition = _StartPos;
        SetChecked();

    }

    public void ToggleChecked()
    {
        Debug.Log("toggle checked");
        _IsChecked = !_IsChecked;
        SetChecked();
    }

    private void SetChecked()
    {
        CheckboxOff.SetActive(!_IsChecked);
        CheckboxOn.SetActive(_IsChecked);
    }
}
