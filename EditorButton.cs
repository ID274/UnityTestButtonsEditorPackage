using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEditorWindow;
public class EditorButton : MonoBehaviour, IEditorButton
{
    public void OnClickBehaviour()
    {
        Debug.Log("EditorButton clicked!");
    }
}
