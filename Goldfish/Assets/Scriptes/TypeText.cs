using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeText : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public float typingSpeed;
    public int index = 0;

    void Start()
    {
        StartCoroutine(Type());
        
    }

   //IEnumerator Type()
   // {
   //     for (int i = 0; i < sentences.Length; i++)
   //     {
   //         textDisplay.text += sentences[i];
   //         yield return new WaitForSeconds(typingSpeed);
   //     }
   // }
    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {

            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
