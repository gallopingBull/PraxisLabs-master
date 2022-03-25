using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


//[CustomEditor(typeof(NarrativeData))]
public class InspectorCustomizer : Editor
{/*
    public void ShowArrayProperty(SerializedProperty list)
    {
        EditorGUI.indentLevel += 1;
        for (int i = 0; i < list.arraySize; i++)
        {
            EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i), new GUIContent("Bla" + (i + 1).ToString()));
        }
        EditorGUI.indentLevel -= 1;
    }

    public override void OnInspectorGUI()
    {
        ShowArrayProperty(serializedObject.FindProperty("Scenes"));
    }*/
}

