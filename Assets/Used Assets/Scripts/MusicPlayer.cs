using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Awake() {
        int num = FindObjectsByType<MusicPlayer>(FindObjectsSortMode.None).Length;
        if (num > 1) {
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
        }
    }
}
