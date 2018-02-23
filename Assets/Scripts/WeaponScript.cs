using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour 
{


    Camera _camera;
	// Use this for initialization
	void Start () 
    {
        _camera = GameObject.Find("Main Camera").GetComponent<Camera>();
	}
	// Update is called once per frame
	void Update () 
    {
        Vector2 mousePos = (_camera.ScreenToWorldPoint(Input.mousePosition));
        Vector2 targetDirection = mousePos - new Vector2(transform.position.x, transform.position.y);
        transform.right = targetDirection;
	}
}
