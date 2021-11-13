using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageDetected : MonoBehaviour
{

    [SerializeField] private GameObject videoPlane;

    //dictionary of image name to mp4 url

    #region DictionaryInitialization

    public Dictionary<string, string> ImageVideoDictionary = new Dictionary<string, string>
    {
        {"hades_switch", "https://cdn.akamai.steamstatic.com/steam/apps/256759357/movie480.webm" },
        {"acnh_switch", "https://williamtburch.com/wp-content/uploads/2021/10/acnh.mp4"},
        {"mariokart8_switch", "https://williamtburch.com/wp-content/uploads/2021/10/yt5s.com-Mario-Kart-8-Deluxe-Nintendo-Switch-Presentation-2017-Trailer360p.mp4"},
        {"rcra_ps5", "https://williamtburch.com/wp-content/uploads/2021/10/yt5s.com-Ratchet-Clank_-Rift-Apart-%E2%80%93-Launch-Trailer-I-PS5360p.mp4"}
    };

    private List<GameObject> currentObjects;
    

    #endregion
    
    private ARTrackedImageManager _arTrackedImageManager;

    private void Awake()
    {
        _arTrackedImageManager = GetComponent<ARTrackedImageManager>();
        _arTrackedImageManager.trackedImagesChanged += OnChanged;

    }
    
    // void onEnable()
    // {
    // }
    //
    //
    // void onDisable()
    // {
    //     _arTrackedImageManager.trackedImagesChanged -= OnChanged;
    // }
    
     
    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        // else
            foreach (var newImage in eventArgs.added)
            {
            
                //the name of the image found
                var imageName = newImage.referenceImage.name;

                var video = Instantiate(videoPlane, newImage.transform);
                var player = video.GetComponent<VideoPlayer>();
                
                player.url = ImageVideoDictionary[imageName];
                player.Play();
                currentObjects.Add(video);
        }
        
        foreach (var updatedImage in eventArgs.updated)
        {
            
        }
        foreach (var removedImage in eventArgs.removed)
        {
         //   removedImage.gameObject.GetComponent<VideoPlayer>().Pause();
     //       GameObject.FindWithTag("Video").GetComponent<VideoPlayer>().Pause();
    
        }
        
    }

    private void Update()
    {
    }


}
