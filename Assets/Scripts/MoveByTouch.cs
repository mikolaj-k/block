using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveByTouch : MonoBehaviour {
	void Update () {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
        }
	}
}
