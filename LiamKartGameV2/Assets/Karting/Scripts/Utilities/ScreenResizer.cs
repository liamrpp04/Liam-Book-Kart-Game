using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif
using UnityEngine;
using UnityEngine.UI;

public class ScreenResizer : MonoBehaviour
{
    [SerializeField] private float originalValue = 720;
    [SerializeField] private float targetValue = 1080;

    public void ResizeChildWidgets()
    {
        Transform[] childs = GetComponentsInChildren<Transform>(true);

        for (int i = 0; i < childs.Length; i++)
        {
            ResizeRectTransform(childs[i]);
            ResizeTMPText(childs[i]);
            ResizeLayoutGroup(childs[i]);
            ResizeLayoutElement(childs[i]);
        }
    }

    public void SwitchValues()
    {
        float tmpOriginalValue = originalValue;
        originalValue = targetValue;
        targetValue = tmpOriginalValue;
    }

    private void ResizeRectTransform(Transform obj)
    {
        RectTransform rect = obj.GetComponent<RectTransform>();

        if (rect == null)
            return;

        rect.anchoredPosition = Calculate(rect.anchoredPosition);
        rect.sizeDelta = Calculate(rect.sizeDelta);
    }

    private void ResizeTMPText(Transform obj)
    {
        TMP_Text tmpText = obj.GetComponent<TMP_Text>();

        if (tmpText == null)
            return;

        tmpText.fontSize = Calculate(tmpText.fontSize);
        tmpText.fontSizeMin = Calculate(tmpText.fontSizeMin);
        tmpText.fontSizeMax = Calculate(tmpText.fontSizeMax);

        tmpText.ForceMeshUpdate();
    }

    private void ResizeLayoutGroup(Transform obj)
    {
        LayoutGroup layoutGroup = obj.GetComponent<LayoutGroup>();

        if (layoutGroup == null)
            return;


        layoutGroup.padding.left = Calculate(layoutGroup.padding.left);
        layoutGroup.padding.right = Calculate(layoutGroup.padding.right);
        layoutGroup.padding.top = Calculate(layoutGroup.padding.top);
        layoutGroup.padding.bottom = Calculate(layoutGroup.padding.bottom);

        if (layoutGroup is GridLayoutGroup)
        {
            GridLayoutGroup gridLayout = layoutGroup as GridLayoutGroup;
            gridLayout.spacing = Calculate(gridLayout.spacing);
            gridLayout.cellSize = Calculate(gridLayout.cellSize);
        }

        if (layoutGroup is VerticalLayoutGroup)
        {
            VerticalLayoutGroup verticalLayout = layoutGroup as VerticalLayoutGroup;
            verticalLayout.spacing = Calculate(verticalLayout.spacing);
        }

        if (layoutGroup is HorizontalLayoutGroup)
        {
            HorizontalLayoutGroup horizontalLayout = layoutGroup as HorizontalLayoutGroup;
            horizontalLayout.spacing = Calculate(horizontalLayout.spacing);
        }
    }

    private void ResizeLayoutElement(Transform obj)
    {
        LayoutElement layoutElement = obj.GetComponent<LayoutElement>();

        if (layoutElement == null)
            return;

        layoutElement.minWidth = Calculate(layoutElement.minWidth);
        layoutElement.minHeight = Calculate(layoutElement.minHeight);
        layoutElement.preferredWidth = Calculate(layoutElement.preferredWidth);
        layoutElement.preferredHeight = Calculate(layoutElement.preferredHeight);
    }

    private float Calculate(float sourceValue)
    {
        return targetValue * sourceValue / originalValue;
    }

    private int Calculate(int sourceValue)
    {
        return (int)(targetValue * sourceValue / originalValue);
    }

    private Vector2 Calculate(Vector2 sourceValue)
    {
        return targetValue * sourceValue / originalValue;
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(ScreenResizer))]
public class ScreenResizerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ScreenResizer resizer = (ScreenResizer)target;

        if (GUILayout.Button("Switch Values"))
        {
            resizer.SwitchValues();
            EditorSceneManager.MarkSceneDirty(resizer.gameObject.scene);
        }

        if (GUILayout.Button("Resize Screen"))
        {
            resizer.ResizeChildWidgets();
            EditorSceneManager.MarkSceneDirty(resizer.gameObject.scene);
        }
    }
}

#endif

