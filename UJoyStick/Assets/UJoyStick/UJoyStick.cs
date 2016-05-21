/*****************************************
*文件名:UJoyStick.cs
*创建日期:2016/05/15
*创建人:陈鹏
*Github:https://github.com/ThisisGame/UJoyStick
*****************************************/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

public class UJoyStick : MonoBehaviour
{
    [SerializeField]
    Transform joyStickInside;

    Transform joyStickOutSide;


    //Move Callback,3D,x=x y=z
    public Action<Vector3> OnMove3D = null;

    //Move Callback,2D,x=x y=y
    public Action<Vector2> OnMove2D = null;

    //Rotate Callback,3D,x=x y=z
    public Action<Vector3> OnRotate3D = null;

    //Rotate Callback,2D,x=x y=y
    public Action<Vector3> OnRotate2D = null;


    //Joystick movement is greater than the distance to trigger the move, the default setting is 0f
    //摇杆移动大于这个距离，才会触发移动,默认设置为0f
    public float minRadius = 0f;


    //Rocker can only move within a specified range maxRadius, the default is the radius of the big picture;
    //摇杆只能在maxRadius指定范围内移动,默认是大图的半径;
    public float maxRadius = 0f;


    //Record mouse start position;
    //记录 鼠标开始位置;
    Vector2 startPosition;




    void Awake()
    {
        joyStickOutSide = transform;

        RectTransform joyStickOutsideRect = joyStickOutSide.GetComponent<RectTransform>();
        maxRadius = joyStickOutsideRect.sizeDelta.x/2;

    }

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            OnPointerDown(new Vector2(Input.mousePosition.x,Input.mousePosition.y));
        }
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            OnPointerUp(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        }
        if(Input.GetKey(KeyCode.Mouse0))
        {
            OnDrag(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        }
	}


    void OnPointerDown(Vector2 position)
    {
        startPosition =  position;
        //Debug.Log("OnPointerDown startPosition=" + startPosition);
    }

    void OnPointerUp(Vector2 position)
    {
        //Debug.Log("OnPointerUp position=" + position);
        joyStickInside.localPosition = Vector3.zero;
    }

    void OnDrag(Vector2 position)
    {
        //Debug.Log("OnDrag position=" + position);

        Vector2 endPosition = position;
        Vector2 offset = endPosition - startPosition;

        startPosition = position;


        Vector3 targetPosition= joyStickInside.localPosition + new Vector3(offset.x, offset.y, 0f);


        //Joystick movement is greater than the distance to trigger the move, the default setting is half the size of the rocker
        //摇杆移动一定距离才生效;

        float distance = Vector2.Distance(Vector2.zero, targetPosition);

        

        Vector3 direction = targetPosition - Vector3.zero;




        //Move
        //位移;
        if (distance > maxRadius)
        {
            targetPosition = direction * maxRadius;
        }
        else
        {
            joyStickInside.localPosition = targetPosition;

            if (distance > minRadius)
            {
                //Debug.Log("OnMove");

                if (OnMove2D != null)
                {
                    Vector3 dir = direction.normalized;
                    OnMove2D(dir);
                }
                if (OnMove3D != null)
                {
                    Vector3 dir = new Vector3(direction.x, 0f, direction.y).normalized;
                    OnMove3D(dir);
                }
            }
        }


        //Rotate
        //旋转
        if (OnRotate2D != null)
        {
            float x = direction.x == 0.0f ? 0.000001f : direction.x;
            float y = direction.y == 0.0f ? 0.000001f : direction.y;

            Vector3 dir = new Vector3(x,y, 0.000001f).normalized;
            OnRotate2D(dir);
        }
        if (OnRotate3D != null)
        {
            float x = (direction.x == 0.0f ? 0.1f : direction.x);
            float z = (direction.y == 0.0f ? 0.1f : direction.y);

            Vector3 dir = new Vector3(x, 0.1f, z).normalized;

            Debug.Log("dir=" + dir);
            OnRotate3D(dir);
        }

    }
}
