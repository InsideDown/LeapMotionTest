using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionAnim : MonoBehaviour {

    private Vector3 _StartPos;
    private Vector3 _EndPos;
    private float _MoveBy = 0.02f;
    private TextMeshPro _TextMeshPro;
    private Color _EndColor;
    private Color _StartColor;
    private float _TweenSpeed = 0.4f;

    private void Awake()
    {
        _EndPos = this.gameObject.transform.localPosition;
        _StartPos = new Vector3(_EndPos.x, _EndPos.y - _MoveBy, _EndPos.z);
        _TextMeshPro = this.gameObject.GetComponent<TextMeshPro>();
        _EndColor = _TextMeshPro.color;
        _StartColor = _EndColor;
        _StartColor.a = 0;
        Hide();
    }

    private void Hide()
    {
        _TextMeshPro.color = _StartColor;
        _TextMeshPro.gameObject.transform.localPosition = _StartPos;
    }

    public void AnimIn(float delay = 0)
    {
        Hide();
        _TextMeshPro.DOFade(1, _TweenSpeed).SetDelay(delay);
        _TextMeshPro.gameObject.transform.DOLocalMoveY(_EndPos.y, _TweenSpeed).SetDelay(delay).SetEase(Ease.OutQuad);
    }
}
