using MoverioARScript;
using System.Collections.Generic;
using UnityEngine;

public class TargetLoader2D : MonoBehaviour
{

    public GameObject TrackingTarget;
    private GameObject mTrackingTarget;
    private string internalStoragePath = "";
    /*
     * Caution
     * - Root folder is MOVERIO's internal storage folder path.
     * - Please copy training data to any location in MOVERIO's internal storage.
     * example) When copying to internal storage/Sample/Image/model.zip
     */
    private string trainingDataFilePath = "/Sample/Image/model.zip";

    // Use this for initialization
    void Start()
    {
        if (TrackingTarget == null)
        {
            return;
        }

#if !UNITY_EDITOR && UNITY_ANDROID
        using (AndroidJavaClass env = new AndroidJavaClass("android.os.Environment"))
        {
            using (AndroidJavaObject storageDir = env.CallStatic<AndroidJavaObject>("getExternalStorageDirectory"))
            {
                internalStoragePath = storageDir.Call<string>("getCanonicalPath");
            }
        }
#endif
        
        if ((internalStoragePath.Length == 0) || (trainingDataFilePath.Length == 0))
        {
            return;
        }

        string tempTrainingDataFile = internalStoragePath + trainingDataFilePath;

        mTrackingTarget = Instantiate(TrackingTarget);
        //Get file list
        List<string> fileList = mTrackingTarget.GetComponent<TrackingLoader>().GetImageTrainingFileList(tempTrainingDataFile);

        foreach(var item in fileList)
        {
            GameObject trackingTarget = Instantiate(TrackingTarget);
            trackingTarget.GetComponent<TrackingLoader>().LoadImageTrainingData(tempTrainingDataFile, item);

            //Sample displays tracking target file name
            GameObject messageText = new GameObject();
            messageText.AddComponent<TextMesh>();
            messageText.transform.parent = trackingTarget.transform;
            messageText.transform.localScale = new Vector3(50, 50, 50);
            messageText.transform.localEulerAngles = new Vector3(0, 180, 0);
            messageText.transform.localPosition = new Vector3(0, 0, 0);
            messageText.transform.hideFlags = HideFlags.NotEditable;
            messageText.GetComponent<TextMesh>().text = item;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
