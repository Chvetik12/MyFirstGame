using UnityEngine;

public class AnimCristalDelay : MonoBehaviour
{
    Animator anim;
    float timeDelay;

    void Awake()
    {
        anim = GetComponent<Animator>();
        anim.speed = 0;
        timeDelay = Random.Range(0.1f,0.7f);
    }

    void Update()
    {
        timeDelay -= Time.deltaTime;//час що пройшов між кадрами
        if(timeDelay<=0)
        {
            anim.speed = 1;
            this.enabled = false;// щоб гасилось, коли анімація не потрібна
        }
    }
}
