using System;
using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LanderUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleTextMesh;
    [SerializeField] private TextMeshProUGUI statsTextMEsh;
    [SerializeField] private Button nextBurron;
    [SerializeField] private TextMeshProUGUI nextBurronTextMesh;


    private Action nextButtonClickAction;

    private void Awake()
    {
        nextBurron.onClick.AddListener(() =>{
            nextButtonClickAction();
        });
    }


    private void Start()
    {
        Lander.Instance.OnLanded += Lander_Onlanded;
        Hide();
    }

    private void Lander_Onlanded(object sender, Lander.OnLandedEventArgs e)
    {
        if (e.landingType == Lander.LandingType.Success)
        {
            titleTextMesh.text = "SUCCESSFUL LANDING!";
            nextBurronTextMesh.text = "CONTINUE";
            nextButtonClickAction = GameManager.Instance.GoToNextLevel;
        } else
        {
            titleTextMesh.text = "<color=#ff0000>CRASH!</color>";
            nextBurronTextMesh.text = "RETRY";
            nextButtonClickAction = GameManager.Instance.RetryLevel;
        }

        statsTextMEsh.text =
        Mathf.Round(e.landingSpeed * 2f) + "\n" +
        Mathf.Round(e.dotVector * 100f) + "\n" +
        "x" + e.scoreMultiplier + "\n" +
        e.score;


    Show();
    }
    
private void Show()
{
    gameObject.SetActive(true);
}
    
private void Hide()
{
    gameObject.SetActive(false);
}








}
