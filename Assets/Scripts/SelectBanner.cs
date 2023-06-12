using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectBanner : MonoBehaviour
{
    public Sprite[] image;
    
    public void SetBannerImage(int num)
    {
        gameObject.GetComponent<Image>().sprite = image[num];
    }
}
