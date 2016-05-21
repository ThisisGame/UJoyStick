using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    UJoyStick joyStick;

	// Use this for initialization
	void Start ()
    {
        joyStick.OnMove3D = OnMove;
    }

    void OnMove(Vector3 pos)
    {
        transform.localPosition += pos;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
