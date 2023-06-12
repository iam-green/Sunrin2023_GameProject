using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class SelectRhythm : MonoBehaviour
{
    public int img;
    
    private Camera _uiCamera;
    private Collider _collider;

    private bool _isMouseOver;
    private bool _isMousePushed;
    
    private void Awake()
    {
        _uiCamera = FindObjectOfType<Camera>();
        _collider = GetComponent<Collider>();
    }

    private void Update()
    {
        var ray = _uiCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            if (Input.GetMouseButtonDown(0))
                OnMouseClick();
        
        if (hit.collider != null && hit.collider == _collider && !_isMouseOver)
        {
            _isMouseOver = true;
            OnMouseEnter();
        }
    }

    private void OnMouseClick()
    {
        Debug.Log("OnMouseClick");
    }
    
    private void OnMouseEnter()
    {
        GameObject.Find("Banner")
            .GetComponent<SelectBanner>().SetBannerImage(img);
    }
}
