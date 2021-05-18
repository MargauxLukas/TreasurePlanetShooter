using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxeBackground : MonoBehaviour
{
    public List<Transform> backgroundSprites;
    public List<float> speeds;

    private void Update()
    {
        for(int i = 0; i < backgroundSprites.Count; i++)
        {
            backgroundSprites[i].position -= Vector3.right * speeds[i] * Time.deltaTime;
            if (backgroundSprites[i].position.x < -25)
            {
                backgroundSprites[i].position += Vector3.right * 50;
            }
        }
    }
}
