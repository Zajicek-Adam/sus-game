using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPManager : MonoBehaviour
{
    public int maxEXP = 100;
    public int level = 0;
    public GameObject slider;
    public Text lvlText;

    public int currentEXP; //CHANGE TO PRIVATE ONCE TESTING FINISHED
    // Start is called before the first frame update
    void Start()
    {
        slider.GetComponent<Slider>().maxValue = maxEXP;
        slider.GetComponent<Slider>().value = currentEXP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceiveEXP(int exp)
    {
        currentEXP += exp;
        slider.GetComponent<Slider>().value = currentEXP;
    }
    void HandleEXP()
    {
        currentEXP = 0;
        lvlText.text = "LVL " + level;
        level++;
    }
}
