using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    [SerializeField] private RawImage videoRawImage;
    [SerializeField] private VideoPlayer videoPlayer;

    public void StartVideo()
    {
        PlayStreamingClip(videoPlayer, "Simulation/POI_0_0.mp4", true);
    }

    public void PlayStreamingClip(VideoPlayer pVideoPlayer,string videoFile, bool looping = true)
    {
        pVideoPlayer.source = VideoSource.Url;
        pVideoPlayer.url = Application.streamingAssetsPath + "/VIDEOS/" + videoFile;
        pVideoPlayer.isLooping = looping;
        StartCoroutine(PlayVideo(pVideoPlayer));
    }

    private IEnumerator PlayVideo(VideoPlayer pVideoPlayer)
    {
        pVideoPlayer.Prepare();

        while (!pVideoPlayer.isPrepared)
            yield return null;

        pVideoPlayer.Play();
        videoRawImage.texture = pVideoPlayer.texture;

        while (!pVideoPlayer.isPlaying)
            yield return null;

    }
}
