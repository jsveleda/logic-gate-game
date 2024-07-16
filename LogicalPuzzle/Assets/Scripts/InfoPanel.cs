using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Operational;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    [SerializeField]
    private Button previousButton;
    [SerializeField]
    private Button nextButton;
    [SerializeField]	
    private Button returnButton;

    [SerializeField]
    private Image gateImage;
    [SerializeField]
    private TextMeshProUGUI gateNameText;
    [SerializeField]
    private TextMeshProUGUI gateDescriptionText;

    private Array enumValues;
    private int index = 1;

    private void OnEnable()
    {
        enumValues = Enum.GetValues(typeof(LogicOperationType));
        previousButton.onClick.AddListener(OnPreviousButtonClick);
        nextButton.onClick.AddListener(OnNextButtonClick);
        returnButton.onClick.AddListener(OnReturnButtonClick);
        UpdateFields();
    }

    private void UpdateFields()
    {
        LogicOperationType operationType = (LogicOperationType)enumValues.GetValue(index);
        GateInfo gateInfo = GlobalPrefabs.Instance.gateInfoList.First(info => info.operationType == operationType);

        gateImage.sprite = gateInfo.gateSprite;
        gateNameText.text = gateInfo.gateName;
        gateDescriptionText.text = gateInfo.gateDescription;
    }

    private void OnReturnButtonClick()
    {
        gameObject.SetActive(false);
    }

    private void OnNextButtonClick()
    {
        index = (index + 1) % enumValues.Length;
        index = index == 0? 1: index;
        UpdateFields();
    }

    private void OnPreviousButtonClick()
    {
        index = (index - 1 + enumValues.Length) % enumValues.Length;
        index = index == 0? enumValues.Length - 1: index;
        UpdateFields();
    }

    private void OnDisable()
    {
        previousButton.onClick.RemoveListener(OnPreviousButtonClick);
        nextButton.onClick.RemoveListener(OnNextButtonClick);
        returnButton.onClick.RemoveListener(OnReturnButtonClick);        
    }
}
