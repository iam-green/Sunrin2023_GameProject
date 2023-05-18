using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowContinue : MonoBehaviour
{
    public float startDelay = 3f;
    public float glowDelay = 0.5f;
    public GameObject textObject;
    private bool _glowing = true;
    
    IEnumerator Start()
    {
        while (_glowing)
        {
            textObject.SetActive(true);
            yield return new WaitForSeconds(glowDelay);
            textObject.SetActive(false);
            yield return new WaitForSeconds(glowDelay);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _glowing = false;
            textObject.SetActive(true);
        }
    }
}
