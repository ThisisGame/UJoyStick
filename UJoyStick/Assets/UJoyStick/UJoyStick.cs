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

    //Rotate Callback
    public Action<Quaternion> OnRotate = null;



    Vector2 startPosition;

    //Move Speed
    //移动速度
    public float speed = 0.1f;

    //cacheSize,if joystick move more ,call OnMove,default size=joystick size/2
    //摇杆缓冲区，摇杆移动大于这个距离，才会触发移动,默认设置为摇杆的一半大小
    public float cacheSize = 0f;


    void Awake()
    {
        joyStickOutSide = transform;

        RectTransform joyStickInsideRect = joyStickInside.GetComponent<RectTransform>();
        cacheSize= joyStickInsideRect.sizeDelta.x/2;
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
    }

    void OnDrag(Vector2 position)
    {
        //Debug.Log("OnDrag position=" + position);

        Vector2 endPosition = position;
        Vector2 offset = endPosition - startPosition;

        //Debug.Log("OnDrag offset=" + offset);

        joyStickInside.localPosition += new Vector3(offset.x, offset.y, 0f);

        //Debug.Log("OnDrag joyStickInside.localPosition=" + joyStickInside.localPosition);


        //摇杆移动一定距离才生效;
        if (OnMove2D != null)
        {
            OnMove2D(offset*speed);
        }
        if (OnMove3D != null)
        {
            OnMove3D(new Vector3(offset.x,0f,offset.y)*speed);
        }

        startPosition = position;
    }


    
    void OnGUI()
    {
        //GUILayout.Label("Mouse:"+ Input.mousePosition.ToString());
        //GUILayout.Label("JoyStick:" + joyStickInside.localPosition);
    }
}
