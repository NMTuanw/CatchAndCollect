using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnergyUI : MonoBehaviour
{
    public TextMeshProUGUI energy_Text;

    [Header("Reference Script")]
    public Attack attack;

    void Awake()
    {
        attack = GameObject.Find("Player").GetComponent<Attack>();
    }
    private void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        energy_Text.text = "" + attack.currentEnergy;
    }
}
