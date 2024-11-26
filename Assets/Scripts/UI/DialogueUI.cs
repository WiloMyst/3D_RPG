using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// 对话UI
public class DialogueUI : MonoBehaviour
{
    public static DialogueUI Instance { get; private set; } //单例模式，static对象属性+Awake() 实现

    private TextMeshProUGUI nameText;
    private TextMeshProUGUI contentText;
    private Button continueButton;

    private List<string> contentList;
    private int contentIndex = 0;

    private GameObject uiGameObject; //对话UI

    private Action OnDialogueEnd; //回调函数

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        uiGameObject = transform.Find("UI").gameObject;
        nameText = transform.Find("UI/NameTextBg/NameText").GetComponent<TextMeshProUGUI>();
        contentText = transform.Find("UI/ContentText").GetComponent<TextMeshProUGUI>();
        continueButton = transform.Find("UI/ContinueButton").GetComponent<Button>();
        continueButton.onClick.AddListener(this.OnContinueButtonClick);
        Hide();
    }

    // 设置UI可见
    public void Show()
    {
        uiGameObject.SetActive(true); 
    }
    public void Show(string name, List<string> content, Action OnDialogueEnd = null)
    {
        nameText.text = name;
        contentList = new List<string>();
        contentList.AddRange(content);
        contentIndex = 0;
        contentText.text = contentList[0];
        this.OnDialogueEnd = OnDialogueEnd;

        uiGameObject.SetActive(true);
    }

    // 设置UI隐藏
    public void Hide()
    {
        uiGameObject.SetActive(false);
    }

    // 点击按钮切换对话框文本，并判断UI隐藏
    private void OnContinueButtonClick()
    {
        if(++contentIndex >= contentList.Count)
        {
            OnDialogueEnd?.Invoke();
            Hide();
            return;
        }
        contentText.text = contentList[contentIndex];
    }
}
