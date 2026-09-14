using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;

    public GameObject splashPrefab;

    private GameManager gm;
    public float jumpForce;

    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.AddForce(Vector3.up * jumpForce);

        GameObject splash = Instantiate(splashPrefab, transform.position + new Vector3(0f, -0.2f, 0f), transform.rotation);
        splash.transform.SetParent(collision.gameObject.transform);




        string metarialName = collision.gameObject.GetComponent<MeshRenderer>().material.name;

        if (metarialName == "SafeColor (Instance)")
        {
            //puan alacak
        }
        else if (metarialName == "UnSafeColor (Instance)")
        {
            //Bölüm yeniden başlayacak

            gm.RestartGame();
        }
        else if (metarialName == "LastRing (Instance)")
        {
            //Bir sonraki levele geçecek

            Debug.Log("Next Level");
        }
    }
}

