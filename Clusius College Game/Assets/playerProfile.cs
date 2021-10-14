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
    [SerializeField] string name;
    string[] firstName = { "cute","long","big","tiny","red","blue"};
    string[] secondName = { "sad","strong","lazy","toasted", "disrupted", "super"};
    string[] thirdName = { "dragon","box","farmer","scarecrow","panda","pumkin"};
    [SerializeField] TMPro.TextMeshProUGUI levelText;
    [SerializeField] TMPro.TextMeshProUGUI ExpText;
    [SerializeField] TMPro.TextMeshProUGUI nameText;
    [SerializeField] Slider sliderExp;

    void earnExp(float amount)
    {
        totalExp += amount;
        nextLevelExp = 100 * Mathf.Sqrt(PlayerLevel);
        CurrentLevelExp = (totalExp - PreviusLevelExp);

        if (totalExp > (PreviusLevelExp + nextLevelExp))
        {
            PreviusLevelExp = totalExp;
            PlayerLevel++;
        }
        sliderExp.maxValue = nextLevelExp;
        sliderExp.value = CurrentLevelExp;
        ExpText.text = ((int)CurrentLevelExp).ToString() + "/" + ((int)nextLevelExp).ToString();
        levelText.text = PlayerLevel.ToString();
    }

    public void changeName()
    {
        name = (firstName[(int)Random.Range(0, firstName.Length)] +" "+ secondName[(int)Random.Range(0, secondName.Length)] +" "+ thirdName[(int)Random.Range(0, thirdName.Length)]);
        nameText.text = name;
    }
}
 