using UnityEngine;
using CustomEditorWindow;

public class AddNumbers : MonoBehaviour, IEditorButton
{
    [SerializeField] private int[] numbers;
    public void OnClickBehaviour()
    {
        int sum = 0;

        if (numbers.Length == 0)
        {
            Debug.Log("No numbers to add.");
            return;
        }
        else
        {
            foreach (int number in numbers)
            {
                sum += number;
            }
        }

        Debug.Log($"The sum of the numbers is {sum}.");
    }
}
