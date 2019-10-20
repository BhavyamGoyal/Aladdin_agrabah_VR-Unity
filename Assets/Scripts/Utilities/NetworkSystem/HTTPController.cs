

using System;
using System.Collections;
using UnityEngine;

namespace NetworkSystem
{
    public class HTTPController
    {
        //Replace IEnumerator with Async 
        public IEnumerator DownloadFile(string url, string key, Action<string, byte[], string> onDownloadCompletedCallback, Action<float, string> progressCallback)
        {
            using (UnityEngine.Networking.UnityWebRequest webRequest = UnityEngine.Networking.UnityWebRequest.Get(url))
            {
                if (progressCallback != null)
                    progressCallback(webRequest.downloadProgress, key);
                webRequest.SendWebRequest();
                // Request and wait for the desired page.
                while (webRequest.downloadProgress < 1)
                {
                    progressCallback(webRequest.downloadProgress, key);
                    // here we will use await
                    yield return new WaitForSeconds(0.03f);
                }
                progressCallback(1f, key);
                if (onDownloadCompletedCallback != null)
                    onDownloadCompletedCallback(key, webRequest.isDone ? (webRequest.downloadHandler.data) : null, webRequest.error);
            }
        }

        public IEnumerator GetRequest(string url, string key, Action<string, string, string> onGetCompletedCallback)
        {
            using (UnityEngine.Networking.UnityWebRequest webRequest = UnityEngine.Networking.UnityWebRequest.Get(url))
            {
                // here we will use await
                yield return webRequest.SendWebRequest();
                if (onGetCompletedCallback != null)
                    onGetCompletedCallback(key, webRequest.isDone ? (webRequest.downloadHandler.text) : null, webRequest.error);
            }
        }

        public IEnumerator PostRequest(string url, string key, string data, Action<string, string, string> onPostCompletedCallback)
        {
            using (UnityEngine.Networking.UnityWebRequest webRequest = UnityEngine.Networking.UnityWebRequest.Post(url, data))
            {
                // here we will use await
                yield return webRequest.SendWebRequest();

                if (onPostCompletedCallback != null)
                    onPostCompletedCallback(key, webRequest.isDone ? (webRequest.downloadHandler.text) : null, webRequest.error);
            }
        }
    }
}