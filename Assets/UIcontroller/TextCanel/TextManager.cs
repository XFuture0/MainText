using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;
public class TextManager : MonoBehaviour
{
    public GameObject PanelOwn;
    public InputPlayController inputActions;
    public Text Name;
    public Text MainText;
    private bool canSkip;
    private bool canPress;
    [Header("�ı�����")]
    public TextAsset Textin;
    private int index;
    private int TextLength;
    List<string> Textlist = new List<string>();
    private void Awake()
    {
        StartList(Textin);
        index = 0;
    }
    private void OnEnable()
    {
        inputActions = new InputPlayController();
        inputActions.Enable();
        inputActions.Player.Enter.started += OnEnterText;
    }

    private void OnEnterText(InputAction.CallbackContext context)
    {
        if (index <= TextLength)
        {
            switch (Textlist[index]) 
            {
                case "A\r":
                    Name.text = "Player";
                    index++;
                    break;
                case "B\r":
                    Name.text = "???";
                    index++;
                    break;
            }
            if (index == TextLength)
            {
                PanelOwn.SetActive(false);
            }
            if (!canPress && !canSkip)
            {
                StartCoroutine(TextPrint());
            }
            else if (canPress && !canSkip)
            {
                canSkip = true;
            }
        }
    }
    private IEnumerator TextPrint()
    {
        canPress = true;
        MainText.text = " ";
        for (int i = 0;i < Textlist[index].Length;i++)
        {
            if (canSkip)
            {
                MainText.text = Textlist[index];
                index++;
                canSkip = false;
                canPress = false;
                break;
            }
            MainText.text += Textlist[index][i];
            yield return new WaitForSeconds(0.1f);
            if(i == Textlist[index].Length - 1)
            {
                canPress = false;
                index++;
            }
        }
    }
    public void StartList(TextAsset textin)
    {
        Textlist.Clear();
        index = 0;
       var text =  textin.text.Split('\n');
        foreach (var Text in text)
        {
            Textlist.Add(Text);
            Debug.Log(Text);
        }
        TextLength = Textlist.Count - 1;
    }
}
