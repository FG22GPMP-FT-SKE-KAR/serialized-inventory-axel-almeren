using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Clicker : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthAmountText;
    [SerializeField] private TextMeshProUGUI armorAmountText;
    [SerializeField] private TextMeshProUGUI speedAmountText;
    [SerializeField] private GameObject healthGray;
    [SerializeField] private GameObject armorGray;
    [SerializeField] private GameObject speedGray;
    [SerializeField] private TextMeshProUGUI healthTimerText;

    private float healthValue;
    private float armorValue;
    private float speedValue;
    private float healthTime = 10;
    private float armorTime = 20;
    private float speedTime = 60;    

    public static Clicker Instance { get; private set; }


    private void Awake()
    {
        Application.runInBackground = true;
        Application.targetFrameRate = 60;
        healthValue = PlayerPrefs.GetFloat("healthValue");
        armorValue = PlayerPrefs.GetFloat("armorValue");
        speedValue = PlayerPrefs.GetFloat("speedValue");
    }
    private void Update()
    {
        healthTime = Time.deltaTime;
        armorTime = Time.deltaTime;
        speedTime = Time.deltaTime;
    }

    public void ClickedHealth()
    {
        StartCoroutine(HealthCor());
    }

    public IEnumerator HealthCor()
    {
        if (healthAmountText != null)
        {
            ++healthValue;
            healthAmountText.text = healthValue.ToString();
        }
        Debug.Log("Health Button Clicked");
        healthGray.SetActive(true);
        yield return new WaitForSecondsRealtime(10f);
        healthGray.SetActive(false);
    }

    public void ClickedArmor()
    {
        StartCoroutine(ArmorCor());
        
    }
    public IEnumerator ArmorCor()
    {
        if (armorAmountText != null)
        {
            ++armorValue;
            armorAmountText.text = armorValue.ToString();
        }
        Debug.Log("Armor Button Clicked");
        armorGray.SetActive(true);        
        yield return new WaitForSecondsRealtime(20f);
        armorGray.SetActive(false);
    }

    public void ClickedSpeed()
    {
        StartCoroutine(SpeedCor());
    }

    public IEnumerator SpeedCor()
    {
        if (speedAmountText != null)
        {
            ++speedValue;
            speedAmountText.text = speedValue.ToString();
        }
        Debug.Log("Speed Button Clicked");
        speedGray.SetActive(true);
        yield return new WaitForSecondsRealtime(60f);
        speedGray.SetActive(false);
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetFloat("healthValue", healthValue);
        PlayerPrefs.SetFloat("armorValue", armorValue);
        PlayerPrefs.SetFloat("speedValue", speedValue);
        //PlayerPrefs.
        PlayerPrefs.Save();
    }
}
