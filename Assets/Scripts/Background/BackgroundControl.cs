using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Video;

public class BackgroundControl : MonoBehaviour
{
    private VideoPlayer BackGroundPlayer;

    private void Start()
    {
        BackGroundPlayer = GetComponent<VideoPlayer>();
        if (BackGroundPlayer) {
            BackGroundPlayer.source = VideoSource.Url;
            BackGroundPlayer.url = Path.Combine(Application.streamingAssetsPath, "GameJam_VapourStreet_5.mp4");
            BackGroundPlayer.prepareCompleted += StartPlay;
        }
        else
        {
            Debug.Log("No Player");
        }
        
    }


    void StartPlay(VideoPlayer videoPlayer)
    {
        videoPlayer.Play();
    }
}
