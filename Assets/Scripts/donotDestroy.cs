using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class donotDestroy : MonoBehaviour {

    void Awake()
    {
       DontDestroyOnLoad(gameObject);
            

    }
}
