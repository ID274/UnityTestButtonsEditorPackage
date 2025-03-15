using CustomEditorWindow;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CustomButtonWindow : EditorCustomWindow
{
    private bool showButtonFields = false;
    private bool isEditing = false;
    private List<ButtonStruct> persistentButtonData = new List<ButtonStruct>();
    private ButtonStruct currentButton;

    [MenuItem("Window/Custom Button Window")]
    public static void ShowWindow()
    {
        GetWindow<CustomButtonWindow>("Custom Button Window");
    }

    public override void Initialise()
    {
        windowName = "Custom Button Window";
        base.Initialise();
    }

    protected override void OnGUI()
    {
        base.OnGUI();
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Existing Buttons", EditorStyles.boldLabel);
        LoadButtons();
        EditorGUILayout.Space();
        if (isEditing == false)
        {
            if (GUILayout.Button("Create New Button"))
            {
                showButtonFields = true;
                isEditing = true;
                currentButton = new ButtonStruct();
            }
        }
        if (showButtonFields)
        {
            // create new button
            currentButton = CreateNewButton(currentButton);
        }
    }

    public override void Reset()
    {
        base.Reset();
        ResetButtons();
    }

    private void LoadButtons()
    {
        EditorGUILayout.BeginVertical("box");
        foreach (ButtonStruct button in persistentButtonData)
        {
            EditorGUILayout.BeginVertical("box");

            if (GUILayout.Button(button.name))
            {
                if (button.action != null)
                {
                    button.action();
                }
                else
                {
                    Debug.LogError("Button action is null.", this);
                }
            }

            if (!string.IsNullOrEmpty(button.description))
            {
                EditorGUILayout.LabelField(button.description, EditorStyles.wordWrappedMiniLabel);
            }

            EditorGUILayout.EndVertical();
        }
        EditorGUILayout.EndVertical();
    }

    private void ResetButtons()
    {
        persistentButtonData.Clear();
    }

    private ButtonStruct CreateNewButton(ButtonStruct buttonData)
    {
        buttonData.name = EditorGUILayout.TextField("Button Name", buttonData.name);
        buttonData.description = EditorGUILayout.TextField("Description", buttonData.description);
        buttonData.script = (MonoBehaviour)EditorGUILayout.ObjectField("Script", buttonData.script, typeof(MonoBehaviour), true);

        if (buttonData.script != null)
        {
            IEditorButton editorButton = buttonData.script as IEditorButton;
            buttonData.action = editorButton != null ? editorButton.OnClickBehaviour : null;
        }


        string actionText = buttonData.action != null ? "Action assigned." : "No action assigned.";
        EditorGUILayout.TextArea($"Action: {actionText}", EditorStyles.whiteLabel);
        GUI.color = buttonData.name != null && buttonData.script != null && buttonData.action != null ? Color.green : Color.red;

        if (buttonData.name != null && !string.IsNullOrEmpty(buttonData.name) && buttonData.script != null && buttonData.action != null)
        {
            if (GUILayout.Button("Confirm"))
            {
                persistentButtonData.Add(buttonData);
                Debug.Log($"Button {buttonData.name} created.");
                showButtonFields = false;
                isEditing = false;
            }
        }

        return buttonData;
    }
}