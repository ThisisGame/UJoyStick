using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    UJoyStick joyStick;


    float speed = 0.1f;

	// Use this for initialization
	void Start ()
    {
        joyStick.OnMove3D = OnMove;

        joyStick.OnRotate3D = OnRotate;
    }

    void OnMove(Vector3 direction)
    {
        transform.localPosition += direction* speed;
    }

    void OnRotate(Vector3 direction)
    {
        Debug.Log(direction);
        transform.localRotation = Quaternion.LookRotation(direction,Vector3.up);
    }
	
}
