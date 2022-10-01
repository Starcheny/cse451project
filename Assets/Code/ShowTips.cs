using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTips : MonoBehaviour
{
    // Start is called before the first frame update

    bool isShowTip;

    void Start()
    {
        isShowTip = false;
    }

    private void OnMouseEnter()
    {
        isShowTip = true;
    }

    private void OnMouseExit()
    {
        isShowTip = false;
    }

    private void OnGUI()
    {
        if (isShowTip)
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 30;
            style.normal.textColor = Color.grey;
            GUI.Label(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, 100, 100), "Key", style);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
