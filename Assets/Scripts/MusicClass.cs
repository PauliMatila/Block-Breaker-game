using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicClass : MonoBehaviour
{
    private static MusicClass musicClassInstance;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (musicClassInstance == null)
        {
            musicClassInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
