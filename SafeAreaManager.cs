using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SafeAreaManager : VisualElement
{
    public new class UxmlFactory : UxmlFactory<SafeAreaManager, VisualElement.UxmlTraits> {}

    public SafeAreaManager()
    {
        RegisterCallback<GeometryChangedEvent>(LayoutChanged);
    }

    private void LayoutChanged(GeometryChangedEvent e)
    {
        var safeArea = Screen.safeArea;

        try
        {
            var leftTop = RuntimePanelUtils.ScreenToPanel(panel,
                new Vector2(safeArea.xMin, Screen.height - safeArea.yMax));
            var rightBottom = RuntimePanelUtils.ScreenToPanel(panel,
                new Vector2(Screen.width - safeArea.xMax, safeArea.yMin));
        
            style.paddingLeft = leftTop.x;
            style.paddingTop = leftTop.y;
            style.paddingRight = rightBottom.x;
            style.paddingBottom = rightBottom.y;
        }
        catch (InvalidCastException) {}
    } 
}
