using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI hpText;
    
    [SerializeField] private PlayerCharacterController bobby;
    [SerializeField] private GameObject skillsHolder;
    [SerializeField] private SkillButtonUI[] skillsButtonUI;

    private void OnEnable()
    {
        bobby.onTakeDamageEventAction += RefreshHpText;
    }

    private void OnDisable()
    {
        bobby.onTakeDamageEventAction -= RefreshHpText;
    }

    private void Start()
    {
        hpText.text = bobby.Hp.ToString();

        for (int i = 0; i < skillsButtonUI.Length; i++)
        {
            skillsButtonUI[i].skillIcon.sprite =  skillsButtonUI[i].skillIcons[i];
            skillsButtonUI[i].skillNameText.text = "Skill " + (i + 1);
        }
    }
    
    public void RefreshHpText(int newHp)
    {
        hpText.text = newHp.ToString();
    }
}