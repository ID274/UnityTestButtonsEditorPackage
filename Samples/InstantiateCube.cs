using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEditorWindow;

public class InstantiateCube : MonoBehaviour, IEditorButton
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Transform parent;
    [SerializeField] private Vector3 position;

    public void OnClickBehaviour()
    {
        if (cubePrefab == null)
        {
            Debug.LogError("Cube prefab is not assigned.", this);
            return;
        }

        GameObject cube;
        if (parent != null)
        {
            cube = Instantiate(cubePrefab, position, Quaternion.identity);
        }
        else
        {
            cube = Instantiate(cubePrefab);
        }

        if (parent != null)
        {
            cube.transform.SetParent(parent);
        }
    }
}
