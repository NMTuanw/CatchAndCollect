using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerUI_Stat : MonoBehaviour
{
    public CharacterStats characterStats;
    public TextMeshProUGUI stat1;
    public TextMeshProUGUI stat2;
    public TextMeshProUGUI stat3;
    public TextMeshProUGUI stat4;
    public TextMeshProUGUI stat5;  
    // Start is called before the first frame update
    void Start()
    {
        characterStats = GameObject.Find("Player").GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerUI_Stat();
    }

    private void UpdatePlayerUI_Stat()
    {
        stat1.text = "Health: " + characterStats.health; 
        stat2.text = "moveSpeed: " + characterStats.moveSpeed; 
        stat3.text = "dashSpeed: " + characterStats.dashSpeed; 
        stat4.text = "dashCooldown: " + characterStats.dashCooldown; 
        stat5.text = "dashDuration: " + characterStats.dashDuration; 
    }
}
