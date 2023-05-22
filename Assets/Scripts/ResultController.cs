using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultController : MonoBehaviour
{
    public GameObject titleBackground;
    public GameObject title;
    public GameObject description;
    public GameObject continueObject;
    private bool _spaceClicked = false;

    private static IEnumerator DelayedAction(float delay)
    {
        yield return new WaitForSeconds(delay);
    }

    private IEnumerator Start()
    {
        titleBackground.SetActive(false);
        title.SetActive(false);
        description.SetActive(false);
        continueObject.SetActive(false);

        yield return StartCoroutine(DelayedAction(1f));
        titleBackground.SetActive(true);
        title.SetActive(true);

        yield return StartCoroutine(DelayedAction(1f));
        description.SetActive(true);

        yield return StartCoroutine(DelayedAction(1f));
        while (!_spaceClicked)
        {
            continueObject.SetActive(true);
            yield return StartCoroutine(DelayedAction(0.5f));
            continueObject.SetActive(false);
            yield return StartCoroutine(DelayedAction(0.5f));
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !_spaceClicked)
        {
            _spaceClicked = true;
            // Change Scene
        }
    }
}
