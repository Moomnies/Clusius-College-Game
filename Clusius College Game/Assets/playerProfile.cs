using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerProfile : MonoBehaviour
{
    [SerializeField] float totalExp;
    [SerializeField] float nextLevelExp;
    [SerializeField] float PreviusLevelExp;
    [SerializeField] float CurrentLevelExp;
    [SerializeField] float PlayerLevel;
    [SerializeField] TMPro.TextMeshProUGUI levelText;
    [SerializeField] TMPro.TextMeshProUGUI ExpText;
    [SerializeField] Slider sliderExp;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame GetComponent<TMPro.TextMeshProUGUI>().text
    void Update()
    {
        nextLevelExp = 100 * Mathf.Sqrt(PlayerLevel);
        CurrentLevelExp = (totalExp - PreviusLevelExp);
        ExpText.text = ((int)CurrentLevelExp).ToString() +"/"+ ((int)nextLevelExp).ToString();
        levelText.text = PlayerLevel.ToString();
        sliderExp.value = CurrentLevelExp;
        sliderExp.maxValue = nextLevelExp;

        if (totalExp > (PreviusLevelExp + nextLevelExp))
        {
            PreviusLevelExp = totalExp;
            PlayerLevel++;
        }
    }



}
