using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;

public class WordsPool : MonoBehaviour
{
    public string WordPoolTextAdress;

    public List<string> Pool;    

    public void Init()
    {
        Addressables.LoadAssetAsync<TextAsset>(WordPoolTextAdress).Completed += onTextLoad;
    }

    public void onTextLoad(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<TextAsset> obj)
    {
        Pool = new List<string>();
        string textWord = obj.Result.text;
        string[] textLines = textWord.Split('\n');
        foreach (string textLine in textLines)
        {
            string[] wordsInLine = textLine.Split(' ');
            foreach (string word in wordsInLine)
            {
                if(word.Trim(' ') != "" && word.Length >= GameController.instance.WordMinLength && word.Length <= GameController.instance.WordMaxLength && !word.ContainsDigits() && !Pool.Contains(word.StripPunctuation().ToUpper()))
                    Pool.Add(word.StripPunctuation().ToUpper());
            }
        }
        GameController.instance.Init();
    }

    public string GetRandomWord()
    {
        int wordIndex = Random.Range(0, Pool.Count);
        var word = Pool[wordIndex];
        Pool.RemoveAt(wordIndex);
        return word;
    }
}
