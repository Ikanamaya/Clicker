using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ClickerController : MonoBehaviour
{
    public TMP_Text counterText;
    public TMP_Text powerUpCostText;
    public TMP_Text autoClickCostText;
    public TMP_Text autoClickCounterText;
    public TMP_Text autoClickCounterText100;
    public TMP_Text autoClickCounterText500;
    public TMP_Text autoClickCounterText1000;
    int autoClickCounter100;
    int autoClickCounter500;
    int autoClickCounter1000;
    [SerializeField] private float delayAutoCLick;
    [SerializeField] private int autoClickPower;
    [SerializeField] private float autoClickCost;
    [SerializeField] private int autoClickCounter;
    public int clickStrength;
    public int clicks;
    int powerUp = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Click()
    {
        clicks += clickStrength;
        counterText.text = clicks.ToString();
    }


    public void BuyAutoClick()
    {
        if (clicks >= autoClickCost)
        {
            StartCoroutine(AutoClick(delayAutoCLick, autoClickPower));
            clicks -= System.Convert.ToInt32(autoClickCost);
            autoClickCost *= 1.75f;
            autoClickCostText.text = autoClickCost.ToString();
            counterText.text = clicks.ToString();
            autoClickCounter += 1;
            autoClickCounterText.text = autoClickCounter.ToString();


        }
    }


    public void BuyAutoCLick100()
    {
        if (clicks >= autoClickCost + 90)
        {
            StartCoroutine(AutoClick(delayAutoCLick, autoClickPower + 9));
            clicks -= 100;
            autoClickCost *= 1.75f;
            autoClickCostText.text = autoClickCost.ToString();
            counterText.text = clicks.ToString();
            autoClickCounter100 += 1;
            autoClickCounterText100.text = autoClickCounter100.ToString();
        }
    }


    public void BuyAutoCLick500()
    {
        if (clicks >= autoClickCost + 490)
        {
            StartCoroutine(AutoClick(delayAutoCLick, autoClickPower + 49));
            clicks -= 500;
            autoClickCost *= 1.75f;
            autoClickCostText.text = autoClickCost.ToString();
            counterText.text = clicks.ToString();
            autoClickCounter500 += 1;
            autoClickCounterText500.text = autoClickCounter500.ToString();
        }
    }


    public void BuyAutoCLick1000()
    {
        if (clicks >= autoClickCost + 990)
        {
            StartCoroutine(AutoClick(delayAutoCLick, autoClickPower + 99));
            clicks -= 1000;
            autoClickCost *= 1.75f;
            autoClickCostText.text = autoClickCost.ToString();
            counterText.text = clicks.ToString();
            autoClickCounter1000 += 1;
            autoClickCounterText1000.text = autoClickCounter1000.ToString();
        }
    }


    private IEnumerator AutoClick(float time, int clickPower)
    {

        yield return new WaitForSeconds(time);
        clicks += clickPower;
        counterText.text = clicks.ToString();
        StartCoroutine(AutoClick(time, clickPower));

    }
    public void ClickMultiplier()
    {
        if (clicks >= powerUp)
        {
            clicks -= powerUp;
            clickStrength += 1;
            counterText.text = clicks.ToString();
            powerUp += 10;
            powerUpCostText.text = powerUp.ToString();
        }
    }


    public void Save()
    {
        PlayerPrefs.SetInt("clicks", clicks);
        PlayerPrefs.SetInt("clickStrength", clickStrength);
        PlayerPrefs.SetInt("powerUp", powerUp);
        PlayerPrefs.SetInt("autoClickCounter", autoClickCounter);
        PlayerPrefs.SetFloat("autoClickCost", autoClickCost);
        PlayerPrefs.SetInt("autoClickCounter100", autoClickCounter100);
        PlayerPrefs.SetInt("autoClickCounter500", autoClickCounter500);
        PlayerPrefs.SetInt("autoClickCounter1000", autoClickCounter1000);
    }


    public void Load()
    {
        StopAllCoroutines();
        clicks = PlayerPrefs.GetInt("clicks", clicks);
        clickStrength = PlayerPrefs.GetInt("clickStrength", clickStrength);
        powerUp = PlayerPrefs.GetInt("powerUp", powerUp);
        autoClickCounter = PlayerPrefs.GetInt("autoClickCounter", autoClickCounter);
        for (int i = 0; i < autoClickCounter; i++)
        {
            StartCoroutine(AutoClick(delayAutoCLick, autoClickPower));
        }
        for (int i = 0; i < autoClickCounter100; i++)
        {
            StartCoroutine(AutoClick(delayAutoCLick, autoClickPower + 9));
        }
        for (int i = 0; i < autoClickCounter500; i++)
        {
            StartCoroutine(AutoClick(delayAutoCLick, autoClickPower + 49));
        }
        for (int i = 0; i < autoClickCounter1000; i++)
        {
            StartCoroutine(AutoClick(delayAutoCLick, autoClickPower + 99));
        }
        powerUpCostText.text = powerUp.ToString();
        counterText.text = clicks.ToString();
        autoClickCost = PlayerPrefs.GetFloat("autoClickCost", autoClickCost);
        autoClickCounter100 = PlayerPrefs.GetInt("autoClickCounter100", autoClickCounter100);
        autoClickCounter500 = PlayerPrefs.GetInt("autoClickCounter500", autoClickCounter500);
        autoClickCounter1000 = PlayerPrefs.GetInt("autoClickCounter1000", autoClickCounter1000);
        autoClickCostText.text = autoClickCost.ToString();
        autoClickCounterText100.text = autoClickCounter100.ToString();
        autoClickCounterText500.text = autoClickCounter500.ToString();
        autoClickCounterText1000.text = autoClickCounter1000.ToString();

    }
}
