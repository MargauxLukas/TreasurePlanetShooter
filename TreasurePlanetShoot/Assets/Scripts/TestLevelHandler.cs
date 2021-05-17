using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLevelHandler : MonoBehaviour
{
    public float coef;

    // Update is called once per frame
    void Update()
    {
        transform.position -= Vector3.right * Time.deltaTime * coef;
    }
}
