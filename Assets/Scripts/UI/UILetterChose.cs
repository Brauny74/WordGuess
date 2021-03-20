using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILetterChose : UILetter
{
    public override void Init(char letter)
    {
        base.Init(letter);
        LetterText.text = Letter.ToString();
    }

    public void OnClick()
    {
        if (!GameController.instance.GameActive)
            return;
        if (GameController.instance.GuessWord.CheckLetter(Letter))
        {
            GameController.instance.GuessWord.RemoveLetter(Letter);
            GameController.instance.CheckWin();
            GameController.instance.Letters.RemoveLetter(this);
        }
        else
        {
            GameController.instance.Tries -= 1;
        }
    }
}
