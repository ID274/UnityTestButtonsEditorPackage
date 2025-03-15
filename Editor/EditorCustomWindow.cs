using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using CustomEditorWindow;

public abstract class EditorCustomWindow : EditorWindow, IEditorWindow
{
    protected string windowName = "Custom Window";
    protected bool isInitialised = false;

    private void OnEnable()
    {
        Debug.Log($"{windowName} enabled.");
    }

    private void OnDisable()
    {
        Debug.Log($"{windowName} disabled.");
    }

    protected virtual void OnGUI()
    {
        Initialise();

        if (GUILayout.Button("Reset"))
        {
            Reset();
        }
    }

    public virtual void Initialise()
    {
        if (isInitialised) return;

        isInitialised = true;
        Debug.Log($"Initialising {windowName}");
    }

    public virtual void Reset()
    {
        isInitialised = false;
        Debug.Log($"Resetting {windowName}");
        
        // close window
    }
}
