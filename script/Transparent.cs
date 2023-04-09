using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Transparent : MonoBehaviour
{
    public GameObject eye;
    public GameObject skin;
    public GameObject timerObject;
    public TextMeshPro timerText;
    public float timerDuration = 10f;

    private float alpha = 1f;
    private bool isTransparent = false;
    private bool isTimerRunning = false;

    void Start(){
        ChangeAlpha(timerObject.GetComponent<Renderer>().material, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered");
        if (other.gameObject.tag == "toilet")
        {
            print("collided");
            if (!isTransparent)
            {
                alpha = 0f;
                isTransparent = true;
                ChangeAlpha(eye.GetComponent<Renderer>().material, alpha);
                ChangeAlpha(skin.GetComponent<Renderer>().material, alpha);
                ChangeAlpha(timerObject.GetComponent<Renderer>().material, 1f);

                // Start the timer coroutine
                StartCoroutine(TimerCoroutine());
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        //Debug.Log("Trigger entered");
        if (other.gameObject.tag == "toilet")
        {
            print("collision ended");

            if (isTransparent)
            {
                alpha = 1f;
                isTransparent = false;
                ChangeAlpha(eye.GetComponent<Renderer>().material, alpha);
                ChangeAlpha(skin.GetComponent<Renderer>().material, alpha);

                // Stop the timer coroutine
                StopCoroutine(TimerCoroutine());
            }
        }
    }

    void ChangeAlpha(Material mat, float alphaVal)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);
    }

    IEnumerator TimerCoroutine()
    {
        isTimerRunning = true;
        while (timerDuration > 0)
        {
            yield return new WaitForSeconds(1f);
            timerDuration--;
            DisplayTime(timerDuration);
        }
        ChangeAlpha(timerObject.GetComponent<Renderer>().material, 0f);
        timerDuration = 10f;
        isTimerRunning = false;
        timerText.text = "Toilte Time";
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
