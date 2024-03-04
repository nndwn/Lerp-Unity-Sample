using System;
using UnityEngine;

public class LerpSample : MonoBehaviour
{

    private readonly string[] _nameGameObject =
    {
        "linear",
        "easeIn",
        "easeOut",
        "expo",
        "smoothStep",
        "smootherStep"
    };
    
    private RectTransform _getParent;
    private RectTransform _self;
    private float _yPos;
    private float _lerpTime;
    private readonly float _time = 1;
    private Vector2 _initial;
    private Vector2 _target;
    private readonly float _tolerance = 0.01f; 
    
    
    private void Start()
    {
        _getParent = transform.parent.GetComponent<RectTransform>();
        _self = GetComponent<RectTransform>();
        _yPos = _self.anchoredPosition.y;
        _initial = new Vector2(_self.rect.width, _yPos);
        _target = new Vector2(_getParent.rect.width, _yPos);
    }
    
    private void Update()
    {
        _lerpTime += Time.deltaTime;
        if (_lerpTime > _time) {
            _lerpTime = _time;
          
        }

        LinearMove();
        EaseInMove();
        EaseOutMove();
        ExpoMove();
        SmoothStep();
        SmootherStep();
    }

    private void LinearMove()
    {
        var t = _lerpTime;
        Motion(0, t);
    }
    private void EaseInMove()
    {
        var t = _lerpTime;
        t = 1f - Mathf.Cos(t * Mathf.PI * 0.5f);
        Motion(1, t);
      
    }

    private void EaseOutMove()
    {
        var t = _lerpTime;
         t =    Mathf.Sin(t * Mathf.PI * 0.5f);
         Motion(2, t);
    }

    private void ExpoMove()
    { 
        var t = _lerpTime;
        t = t * t;
        Motion(3, t);
    }

    private void SmoothStep()
    {
        var t = _lerpTime;
        t = t * t * (3f - 2f * t);
        Motion(4, t);
    }

    private void SmootherStep()
    {
        var t = _lerpTime;
        t = t * t * t * (t * (6f * t - 15f) + 10f);
        Motion(5, t);
    }


    private void Motion(int index , float t)
    {
        GoLeft(index, t, f => t = 0);
        GoRight(index, t, f => t = 0 );
    }
    
    private void GoLeft(int index , float time, Action<float> action)
    {
        if (gameObject.name == _nameGameObject[index])
        {
            if (_self.pivot.x.Equals(1))
            {
                var t = time;
                _self.anchoredPosition = Vector2.Lerp(_initial, _target, time );
                if (Mathf.Abs(_self.anchoredPosition.x - _target.x ) < _tolerance)
                {
                    _self.pivot = new Vector2(0, 0.5f);
                    action.Invoke(time);
                    _lerpTime = 0;
                }

             
            }
        }
    }
    
    private void GoRight(int index, float time, Action<float> action)
    {
        if (gameObject.name == _nameGameObject[index])
        {
            if (_self.pivot.x.Equals(0))
            {
                var t = time;
                _self.anchoredPosition = Vector2.Lerp(_target, _initial, time);
                if (Mathf.Abs(_self.anchoredPosition.x - _initial.x ) < _tolerance)
                {
                    _self.pivot = new Vector2(1, 0.5f);
                    action.Invoke(time);
                    _lerpTime = 0;
                }
            }
        }
    }
}
