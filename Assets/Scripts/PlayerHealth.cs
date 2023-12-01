using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float currentHealth = 100;
    private Animator anim;
    private float time;
    private AudioSource audioSource;
    public AudioClip deadSound; // khi chet phat ra am thanh
    public AudioClip hurtSound; // khi dau phat ra am thanh
    // dinh nghia delegate: thay doi phan tram suc khoe
    public event Action<float> OnHealthPecentChanged = delegate(float f) {  };

    private void Awake()
    {
        anim = GetComponent<Animator>(); // anh xa nhan vat
        audioSource = GetComponent<AudioSource>(); // anh xa am thanh
    }

    public void ModifyHealth(int amount) // ham thay doi suc khoe
    {
        currentHealth += amount;
        float currenHealthPercent = currentHealth / maxHealth;
        if (currentHealth > 10) // co the thay 10 bang so khac
        {
            // goi am thanh
            SoundManager.Instance.PlaySound(hurtSound);
        }

        OnHealthPecentChanged(currenHealthPercent); // thay doi tren man hinh tich mau
    }

     void Start()
    {
        
    }
     // Quan ly suc khoe
     void Update()
     {
         if (currentHealth<=0)// xu lys khi nhan vat chet
         {
             // xu ly am thanh
             audioSource.Pause();
             audioSource.clip = deadSound;
             audioSource.loop = false;
             //----
             audioSource.Play();
             audioSource.loop = false;
             // set trang thai chet
             anim.SetInteger("Death", 1);
             //
             GetComponent<PlayerRunning>().Dead(); // goi ham chet: Nhan vat khong chay
             GetComponent<ScoreManager>().Dead(); // goi ham chet: khong cong diem
             time += Time.deltaTime;
         }

         if (time>3f)// thoi gian cho de sang level
         {
             Application.LoadLevel("GameOverScene");
         }
     }
}
