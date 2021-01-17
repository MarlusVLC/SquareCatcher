using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BornAndDieCycle : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.y <= -GameManager.GetInstance.genPosY)
        {
            Destroy(gameObject);
        }        
    }
}
