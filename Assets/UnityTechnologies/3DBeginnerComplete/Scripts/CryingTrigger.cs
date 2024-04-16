using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryingScript : MonoBehaviour
{
    public AudioSource Crying;
    int truth = 0;

    // Start is called before the first frame update
    void Start()
    {
        Crying.Play();
    }



    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = transform.position;
        GameObject[] ghosts = GameObject.FindGameObjectsWithTag("Ghost");
        bool truth = false;
        float shortestDistance = 0.0f;
        for (int i = 0; i < ghosts.Length; i++)
        {
            Vector3 ghostPosition = ghosts[i].transform.position;
            float dist = Vector3.Distance(playerPosition, ghostPosition);
            if (dist <= 5)
            {
                shortestDistance = dist;
                truth = true;
            }
        }
        if (truth)
        {
            Debug.Log(shortestDistance);
            if (Crying.isPlaying)
            {
                Debug.Log("Changing Volume...");
                Crying.volume = shortestDistance / 5;
                Debug.Log(Crying.volume);
            }
        }
        /*else
        {
            if (!Crying.isPlaying)
            {
                Debug.Log(shortestDistance);
                Debug.Log("Stopped Crying");
                Crying.Play();
            }
        }*/
    }

}