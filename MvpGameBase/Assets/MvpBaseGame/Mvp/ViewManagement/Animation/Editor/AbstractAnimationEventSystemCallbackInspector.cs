using MvpBaseGame.Mvp.ViewManagement.Animation.Impl;
using UnityEditor;
using UnityEngine;

namespace MvpBaseGame.Mvp.ViewManagement.Animation.Editor
{
    [CustomEditor(typeof(AbstractAnimationEventSystemCallback<>), true)]
    public class AbstractAnimationEventSystemCallbackInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawTriggerGUI("OnEnterState > enabled:", "_isActiveEnter", "_enterTrigger", "Fired as soon as state is entered");
            DrawTriggerGUI("OnEndState   > enabled:", "_isActiveEnd", "_endTrigger", "Fired 1st time the end of the clip is reached");
            DrawTriggerGUI("OnExitState   > enabled:", "_isActiveExit", "_exitTrigger", "Fired as soon as state is exited");
            serializedObject.ApplyModifiedProperties();
        }
        
        private void DrawTriggerGUI(string label, string activePropertyName, string triggerName, string tooltip = "")
        {
            EditorGUILayout.BeginHorizontal();
            
            SerializedProperty isActive = serializedObject.FindProperty(activePropertyName);

            EditorGUILayout.LabelField(new GUIContent(label, tooltip), GUILayout.Width(140));
            
            isActive.boolValue = EditorGUILayout.Toggle(isActive.boolValue, GUILayout.Width(20));

            GUI.enabled = isActive.boolValue;

            EditorGUILayout.PropertyField(serializedObject.FindProperty(triggerName),new GUIContent(string.Empty, tooltip), GUILayout.ExpandWidth(true));

            GUI.enabled = true;
            
            EditorGUILayout.EndHorizontal();
        }
    }
}