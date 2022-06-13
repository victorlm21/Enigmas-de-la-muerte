using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirCofre : MonoBehaviour
{

    Animator anim;
    public AudioSource emisor;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Objeto")
        {
            anim.SetBool("AbrirCofre", true);
            emisor.clip = clip;
            emisor.Play();
        }
    }
}
