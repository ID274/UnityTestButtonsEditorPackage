using UnityEngine;
using System;
using UnityEditor;

// I originally wanted this struct to use MonoScript instead of MonoBehaviour so that it could be used without needing an
// instance of the script. However, I got stuck and decided on this instead, which unfortunately comes with limitations.

[Serializable]
public struct ButtonStruct
{
    public string name;
    public string description;
    public MonoBehaviour script;
    public Action action;
}
