using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{ 
    private TextMeshProUGUI text;
    [SerializeField] private string hoverText, notHoverText;
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.text = hoverText;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.text = notHoverText;
    }


}
