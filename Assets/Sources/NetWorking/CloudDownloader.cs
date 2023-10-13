using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CloudDownloader : MonoBehaviour
{
    public string url = "https://drive.google.com/file/d/1SxTj2iNp3FFdnEya92Cqhh45FCpfGZbw/view?usp=drive_link";

    void Start()
    {
        StartCoroutine(DownloadData());
    }

    IEnumerator DownloadData()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                string data = webRequest.downloadHandler.text;
            }
            else
            {
                Debug.LogError("Error: " + webRequest.error);
            }
        }
    }
}
