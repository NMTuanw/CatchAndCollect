using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossUI : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI bossName_Text;
    public TextMeshProUGUI bossHealth_Text;

    [Header("Reference Script")]
    public BossSO bossSO;

    private void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        bossName_Text.text = "" + bossSO.bossName;
        bossHealth_Text.text = "" + BossHealthManager.instance.health;
    }

}
