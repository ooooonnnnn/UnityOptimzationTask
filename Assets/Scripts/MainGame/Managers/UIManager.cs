using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI hpText;
    
    [SerializeField] private PlayerCharacterController bobby;
    [SerializeField] private GameObject skillsHolder;
    [SerializeField] private SkillButtonUI[] skillsButtonUI;
    
    public void RefreshHpText(int newHp)
    {
        hpText.text = newHp.ToString();
    }

    private void OnValidate()
    {
        bobby.onTakeDamageEventAction += RefreshHpText;
        skillsHolder = GameObject.Find("Skills Group");
        skillsButtonUI = skillsHolder.GetComponentsInChildren<SkillButtonUI>();
        for (int i = 0; i < skillsButtonUI.Length; i++)
        {
            skillsButtonUI[i].skillIcon.sprite =  skillsButtonUI[i].skillIcons[i];
            skillsButtonUI[i].skillNameText.text = "Skill " + (i + 1);
        }
        hpText.text = bobby.Hp.ToString();
    }
}
