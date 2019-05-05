using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class layersorting : MonoBehaviour {
    SpriteRenderer tempRend;
    // Use this for initialization
    void Awake () {
        tempRend = gameObject.GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {

        tempRend.sortingOrder = (int)Camera.main.WorldToScreenPoint(tempRend.bounds.min).y * -1;
    }
}
