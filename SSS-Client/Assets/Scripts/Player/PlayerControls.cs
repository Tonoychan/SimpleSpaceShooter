using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class PlayerControls : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 offset;

    private float maxLeft;
    private float maxRight;
    private float maxTop;
    private float maxBottom;
    
    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    void Start()
    {
        mainCamera = Camera.main;
        StartCoroutine(SetBoundary());
    }
    
    void Update()
    {
        if (Touch.activeTouches.Count > 0)
        {
            Touch touch = Touch.activeTouches[0];
            Vector3 touchPos = touch.screenPosition;
            touchPos = mainCamera.ScreenToWorldPoint(touchPos);

            if (Touch.activeTouches[0].phase == TouchPhase.Began)
            {
                offset = touchPos - transform.position;
            }

            if (Touch.activeTouches[0].phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(touchPos.x - offset.x, touchPos.y - offset.y, 0);
            }

            if (Touch.activeTouches[0].phase == TouchPhase.Stationary)
            {
                transform.position = new Vector3(touchPos.x - offset.x, touchPos.y - offset.y, 0);
            }

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, maxLeft, maxRight),
                Mathf.Clamp(transform.position.y, maxBottom, maxTop),0f);

        }
    }

    private IEnumerator SetBoundary()
    {
        yield return new WaitForEndOfFrame();
        
        maxLeft = mainCamera.ViewportToWorldPoint(new Vector2(0.15f, 0f)).x;
        maxRight = mainCamera.ViewportToWorldPoint(new Vector2(0.85f, 0f)).x;
        
        maxBottom = mainCamera.ViewportToWorldPoint(new Vector2(0f, 0.05f)).y;
        maxTop = mainCamera.ViewportToWorldPoint(new Vector2(0f, 0.9f)).y;
    }
}
