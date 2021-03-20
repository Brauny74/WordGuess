using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LettersPool : MonoBehaviour
{
    public UILetterChose LetterChosePrefab;
    public List<UILetterChose> PoolUI;
    public Vector2 CoordPlaceStep;
    public Vector2 CoordStartPos;
    public int KeyBoardLength = 10;

    List<char> GenerateLettersPool(string wordToGuess)
    {
        //We add letters from the word to the pool, so the player can always guess the word.
        List<char> letters = new List<char>();
        foreach (char L in wordToGuess)
        {
            letters.Add(L);
        }
        //Fill the pool to the pool size with fakse letter
        int startIndex = letters.Count;
        for (int i = startIndex; i < GameController.instance.PoolSize; i++)
        {
            char randomLetter = GameController.instance.AllPossibleLetters[Random.Range(0, GameController.instance.AllPossibleLetters.Length)];
            letters.Add(randomLetter);
        }
        //Shuffle the pool, so the word to guess won't be the first 
        letters.Shuffle();
        return letters;
    }

    UILetterChose GenerateLetter(char letter, int coordX, int coordY)
    {
        UILetterChose letterUI = Instantiate(LetterChosePrefab, transform).GetComponent<UILetterChose>();
        letterUI.GetComponent<RectTransform>().anchoredPosition = new Vector2(CoordStartPos.x + (CoordPlaceStep.x * coordX), CoordStartPos.y + (CoordPlaceStep.y * coordY));
        letterUI.Init(letter);
        return letterUI;
    }

    public void RemoveLetter(UILetterChose letter)
    {
        PoolUI.Remove(letter);
        Destroy(letter.gameObject);
    }

    public void Init(string wordToGuess)
    {
        if (PoolUI != null && PoolUI.Count > 0)
        {
            foreach (UILetterChose letterUI in PoolUI)
            {
                Destroy(letterUI.gameObject);
            }
        }
        PoolUI = new List<UILetterChose>();
        List<char> letters = GenerateLettersPool(wordToGuess);
        int coordX = -1;
        int coordY = 0;
        foreach(char letter in letters)
        {
            coordX++;
            if (coordX >= KeyBoardLength)
            {
                coordX = 0;
                coordY++;
            }
            PoolUI.Add(GenerateLetter(letter, coordX, coordY));
        }
    }
}
