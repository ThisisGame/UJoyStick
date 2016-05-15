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
    Image joyStickOutSide;

    [SerializeField]
    Image joyStickInside;


    void Awake()
    {
        joyStickOutSide.enabled = false;
        joyStickInside.enabled = false;
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
            OnPointerDown();
        }
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            OnPointerUp();
        }
        if(Input.GetKey(KeyCode.Mouse0))
        {
            OnDrag();
        }
	}


    void OnPointerDown()
    {
        joyStickOutSide.enabled = true;
        joyStickInside.enabled = true;
    }

    void OnPointerUp()
    {
        joyStickOutSide.enabled = false;
        joyStickInside.enabled = false;
    }

    void OnDrag()
    {

    }
}
