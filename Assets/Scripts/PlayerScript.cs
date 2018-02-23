using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {



    private Camera mainCamera;

    private float t;
    public float speed;
    private Vector3 currentPos;
    private Vector3 nextPos;

    private GameObject weapon;

	// Use this for initialization
	void Start () {
        t = 1f;
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        nextPos = currentPos = transform.position;
        weapon = gameObject.transform.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.position = Vector3.Lerp(currentPos, nextPos, t);

		if (Input.GetMouseButtonUp(1))
        {
            currentPos = transform.position;
          nextPos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.nearClipPlane));
            t = 0;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(Attack());
        }

        if (t < 1)
        {
            t += 0.1f * speed * Time.deltaTime;
        }
	}

    private IEnumerator Attack()
    {
        weapon.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        weapon.gameObject.SetActive(false);
    }
}
