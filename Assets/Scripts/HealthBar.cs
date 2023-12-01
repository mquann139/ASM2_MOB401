using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthImage;
    [SerializeField] private float updateSpeed = 1f; // 1 co the thay doi

    private void Awake()
    {
        GetComponentInParent<PlayerHealth>().OnHealthPecentChanged += HandleHealthChanged;
    }

    private void HandleHealthChanged(float p)
    {
        StartCoroutine(ChangePercent(p));
    }

    private IEnumerator ChangePercent(float per)
    {
        float preChanged = healthImage.fillAmount; // dien vao man hinh tich mau 100%
        float time_lapse = 0f;
        while (time_lapse<updateSpeed)
        {
            time_lapse += Time.deltaTime;
            // tinh toan de hien thi & tren man hinh tisch mau
            healthImage.fillAmount = Mathf.Lerp(preChanged, per, time_lapse / updateSpeed);
            yield return null;
        }

        healthImage.fillAmount = per;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
