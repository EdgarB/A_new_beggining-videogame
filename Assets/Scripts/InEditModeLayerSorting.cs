
using UnityEngine;

#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEditor;

#endif

[ExecuteInEditMode]


public class InEditModeLayerSorting : MonoBehaviour {
    SpriteRenderer tempRend;
    void Awake()
    {
#if UNITY_EDITOR
        tempRend = gameObject.GetComponent<SpriteRenderer>();
#endif
    }



    void LateUpdate()
    {


#if UNITY_EDITOR
        tempRend.sortingOrder = (int)Camera.main.WorldToScreenPoint(tempRend.bounds.min).y * -1;
#endif
    }


}
