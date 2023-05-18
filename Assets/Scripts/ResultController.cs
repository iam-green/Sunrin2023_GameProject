using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultController : MonoBehaviour
{
    public List<float> delay = new() { 1, 2, 0 };
    [TextArea]
    public List<string> content = new() {"제목", "내용1\n내용2"};
    public List<GameObject> textObject = new();

    IEnumerator DelayedAction(float second) {
        yield return new WaitForSeconds(second);
    }
    
    IEnumerator Start()
    {
        foreach (var o in textObject)
        {
            o.SetActive(false);
        }
        for (var i=0; i<textObject.Count; i++)
        {
            yield return DelayedAction(delay[i]);
            textObject[i].SetActive(true);
            Debug.Log(i);
            Debug.Log(content.Count-1);
            if (i < content.Count-1)
            {
                textObject[i].GetComponent<TextMeshProUGUI>().text = content[i];
            }
        }
    }
}
