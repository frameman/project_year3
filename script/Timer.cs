using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public GameObject timerObject;
    public GameObject toilteObject;
    public GameObject catObject;
    public float timerDuration = 3f;
    public TextMeshPro timerText;
    private bool isVisible = false;

    void Start()
    {
        SetObjectTransparency(timerObject, 0f);
        SetObjectTransparency(timerText.gameObject, 0f);
    }

    void Update()
    {
        if (isVisible)
        {
            timerDuration -= Time.deltaTime;
            DisplayTime(timerDuration);
            if (timerDuration <= 0f)
            {
                SetObjectTransparency(timerObject, 0f);
                timerDuration = 3f;
                isVisible = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == toilteObject && collision.contacts.Length > 0 && collision.contacts[0].otherCollider.gameObject == catObject)
        {
            Debug.Log("Cat collided with toilte!");
            isVisible = true;
            SetObjectTransparency(timerObject, 1f);
        }
    }

    void SetObjectTransparency(GameObject obj, float alphaVal)
    {
        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            Material mat = renderer.material;
            Color color = mat.color;
            color.a = alphaVal;
            mat.color = color;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
