using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndText : MonoBehaviour
{
    public Text MainText;
    private bool isFirstTime;
    [Header("文本内容")]
    public TextAsset Textin;
    private int index;
    private int TextLength;
    List<string> Textlist = new List<string>();
    [Header("广播")]
    public VoidEventSO OpenEndCanvsEvent;
    private void Awake()
    {
        isFirstTime = true;
        StartList(Textin);
        index = 0;
    }
    private void OnEnable()
    {
        StartText();
    }
    public void StartText()
    {
        StartCoroutine(OpenText());
    }
    private IEnumerator OpenText()
    {
        if (isFirstTime)
        {
            isFirstTime=false;
            yield return new WaitForSeconds(2f);
        }
        for (int i = 0; i < Textlist[index].Length; i++)
        {
            MainText.text += Textlist[index][i];
            yield return new WaitForSeconds(0.15f);
            if (i == Textlist[index].Length - 1)
            {
                yield return new WaitForSeconds(1f);
                MainText.text = " ";
                i = -1;
                index++;
                if(index == 8)
                {
                    OpenEndCanvsEvent.RaiseEvent();
                }
            }
        }
    }
    public void StartList(TextAsset textin)
    {
        Textlist.Clear();
        index = 0;
        var text = textin.text.Split('\n');
        foreach (var Text in text)
        {
            Textlist.Add(Text);
        }
        TextLength = Textlist.Count - 1;
    }
}
