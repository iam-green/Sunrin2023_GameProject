using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultTitleBackground : MonoBehaviour
{
    public GameObject resultObject;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        resultObject.SetActive(false);
        yield return new WaitForSeconds(1);
        resultObject.SetActive(true);
    }
}
