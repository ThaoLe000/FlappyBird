using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdsManager : MonoBehaviour
{
    [SerializeField] private GameObject adsPanel;
    [SerializeField] private Text countdownText; // text dem nguoc
    [SerializeField] Button skipButton;
    [SerializeField] private float adDurantion;

    public void ShowAd()
    {
        adsPanel.SetActive(true);
        skipButton.gameObject.SetActive(false);
        StartCoroutine(Countdown());
    }
    private IEnumerator Countdown()
    {
        float timeLeft = adDurantion;
        while (timeLeft > 0)
        {
            countdownText.text = "Bạn có thể bỏ qua sau: " + Mathf.Ceil(timeLeft) + " giây";
            yield return new WaitForSeconds(1f);
            timeLeft--;
        }

        skipButton.gameObject.SetActive(true);
        countdownText.text = "Bấm để bỏ qua";
    }
    public void SkipAd()
    {
        AddCoin();
        adsPanel.SetActive(false);
    }
    private void AddCoin()
    {
        int number = PlayerPrefs.GetInt("Money", 0);
         number += 1000;
        PlayerPrefs.SetInt("Money", number);
        PlayerPrefs.Save();
    }


}
