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

public class UJoyStick : MonoBehaviour
{
    [SerializeField]
    Transform joyStickInside;

    Transform joyStickOutSide;


    Vector2 startPosition;


    void Awake()
    {
        joyStickOutSide = transform;
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
        Debug.Log("OnPointerDown startPosition=" + startPosition);
    }

    void OnPointerUp(Vector2 position)
    {
        Debug.Log("OnPointerUp position=" + position);
    }

    void OnDrag(Vector2 position)
    {
        Debug.Log("OnDrag position=" + position);

        Vector2 endPosition = position;
        Vector2 offset = endPosition - startPosition;

        Debug.Log("OnDrag offset=" + offset);

        joyStickInside.localPosition += new Vector3(offset.x, offset.y, 0f);

        Debug.Log("OnDrag joyStickInside.localPosition=" + joyStickInside.localPosition);

        startPosition = position;
    }
}
