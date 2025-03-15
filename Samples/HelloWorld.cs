using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEditorWindow;

public class HelloWorld : MonoBehaviour, IEditorButton
{
    public void OnClickBehaviour()
    {
        Debug.Log("Hello, World!");
    }
}
