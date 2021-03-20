using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILetterGuess : UILetter
{
    public bool Shown;

    public override void Init(char letter)
    {
        base.Init(letter);
        HideLetter();
    }

    public void ShowLetter()
    {
        LetterText.text = Letter.ToString();
        Shown = true;
    }

    public void HideLetter()
    {
        LetterText.text = "";
        Shown = false;
    }
}
