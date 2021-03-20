using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordToGuess : MonoBehaviour
{
    public UILetterGuess LetterGuessPrefab;
    public Vector2 CoordPlaceStep;
    public Vector2 CoordStartPos;
    public List<UILetterGuess> WordUI;

    public string Word;

    public void Init(string word)
    {
        Word = word;
        if (WordUI != null && WordUI.Count > 0)
        {
            foreach (UILetterGuess letterUI in WordUI)
            {
                Destroy(letterUI.gameObject);
            }
        }
        WordUI = new List<UILetterGuess>();
        for (int l = 0; l < Word.Length; l++)
        {
            WordUI.Add(GenerateLetter(Word[l], l, 0));
        }
    }

    UILetterGuess GenerateLetter(char letter, int coordX, int coordY)
    {
        UILetterGuess letterUI = Instantiate(LetterGuessPrefab, transform).GetComponent<UILetterGuess>();
        letterUI.GetComponent<RectTransform>().anchoredPosition = new Vector2(CoordStartPos.x + (CoordPlaceStep.x * coordX), CoordStartPos.y + (CoordPlaceStep.y * coordY));
        letterUI.Init(letter);
        return letterUI;
    }

    public bool CheckLetter(char letter)
    {
        return Word.Contains(letter.ToString());
    }

    public void RemoveLetter(char letter) {
        foreach (UILetterGuess UILetter in WordUI)
        {
            if (!UILetter.Shown && UILetter.GetLetter() == letter)
            {
                UILetter.ShowLetter();
                Word = Word.Remove(Word.IndexOf(letter), 1);
                return;
            }
        }
    }

}
