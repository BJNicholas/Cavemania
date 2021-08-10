using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_BG : MonoBehaviour
{
    public static Music_BG MusicInstance;

    // Start is called before the first frame update
    private void Awake()
    {
        if (MusicInstance != null && MusicInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        MusicInstance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
