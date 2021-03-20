using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UILetter : MonoBehaviour
{
    public TMP_Text LetterText;
    protected char Letter;

    public virtual void Init(char letter)
    {
        Letter = letter;
    }

    public char GetLetter()
    {
        return Letter;
    }
}
