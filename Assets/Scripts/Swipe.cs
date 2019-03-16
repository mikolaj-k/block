using UnityEngine;

public class Swipe : MonoBehaviour
{
    public bool SwipeUp { get; set; }
    private bool _tap;
    private bool _isDragging;
    private Vector2 _startTouch;
    private Vector2 _swipeDelta;

    private void Update()
    {
        _tap = SwipeUp = false;


        if (Input.touchCount > 0)
        {
            var touch = Input.touches[0];

            if (touch.phase == TouchPhase.Began)
            {
                _tap = true;
                _isDragging = true;
                _startTouch = Input.touches[0].position;
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                Reset();
            }
        }

        _swipeDelta = Vector2.zero;
        if (_isDragging)
        {
            if (Input.touchCount > 0)
            {
                _swipeDelta = Input.touches[0].position - _startTouch;
            }
        }

        if (_swipeDelta.magnitude > 50)
        {
            var x = _swipeDelta.x;
            var y = _swipeDelta.y;

            if (Mathf.Abs(x) < Mathf.Abs(y) && y > 0)
            {
                SwipeUp = true;
            }
        }
    }

    private void Reset()
    {
        _isDragging = false;
        _tap = false;
        SwipeUp = false;
        _startTouch = _swipeDelta = Vector2.zero;
    }
}
