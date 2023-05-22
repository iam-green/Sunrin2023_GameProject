using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectResultController : MonoBehaviour
{
    public GameObject background;
    
    private static IEnumerator DelayedAction(float delay)
    {
        yield return new WaitForSeconds(delay);
    }
    
    private IEnumerator Start()
    {
        background.SetActive(false);
        yield return StartCoroutine(DelayedAction(2f));
        background.SetActive(true);
        yield return StartCoroutine(DelayedAction(5f));
        // Change Scene
    }
}
