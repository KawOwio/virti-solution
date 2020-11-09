using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Code : MonoBehaviour
{
    private Text text;
    private List<int> numbers = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    public void AddNumber(int num)
    {
        if (numbers.Count < 8)
        {
            numbers.Add(num);
            ChangeText();
        }
    }

    public void DeleteNumber()
    {
        if (numbers.Count > 0)
        {
            numbers.RemoveAt(numbers.Count - 1);
            ChangeText();
        }
    }

    private void ChangeText()
    {
        // Reset the text
        text.text = "";

        int temp = numbers.Count;

        // Fill the numbers from the list
        for (int i = 0; i < temp; i++)
        {
            text.text += numbers[i] + " ";
        }

        // If not enough numbers then put placeholders
        for (int i = temp; i < 8; i++)
        {
            text.text += "- ";
        }

        // Remove extra " " in the end 
        text.text.Remove(temp);
    }

    public void ResetCode()
    {
        if (numbers.Count > 0)
        {
            numbers.Clear();
            ChangeText();
        }
    }
}
