using System;
using System.Collections;
using System.Collections.Generic;

namespace NetworkSystem
{
    public class HTTPpostEvent
    {
        public string url, key,data;
        public Action<string, string, string> onCompleteCallback;

        public HTTPpostEvent(string url, string key,string data, Action<string, string, string> onCompleteCallback)
        {
            this.data = data;
            this.url = url;
            this.key = key;
            this.onCompleteCallback = onCompleteCallback;
        }
    }

    public class DownloadFileEvent
    {
        public string url, key;
        public Action<string, byte[], string> onCompleteCallback;
        public Action<float, string> onProgress;
        public DownloadFileEvent(string url, string key, Action<string, byte[], string> onCompleteCallback, Action<float, string> onProgress)
        {
            this.onProgress = onProgress;
            this.url = url;
            this.key = key;
            this.onCompleteCallback = onCompleteCallback;
        }
    }

    public class HTTPGetEvent
    {
        public string url, key;
        public Action<string, string, string> onCompleteCallback;

        public HTTPGetEvent(string url,string key, Action<string, string, string> onCompleteCallback)
        {
            this.url = url;
            this.key = key;
            this.onCompleteCallback = onCompleteCallback;
        }
    }
    public class NetworkManager
    {
        HTTPController httpController=null;
        public NetworkManager()
        {
            //listen to events in constructor
        }
        ~NetworkManager()
        {
            // Remove all listeners here
        }

        private void GetRequest(HTTPGetEvent info)
        {
            if (httpController == null)
            {
                httpController = new HTTPController();
            }
            httpController.GetRequest(info.url, info.key, info.onCompleteCallback);
        }

        private void PostRequest(HTTPpostEvent info)
        {
            if (httpController == null)
            {
                httpController = new HTTPController();
            }
            httpController.PostRequest(info.url, info.key, info.data, info.onCompleteCallback);
        }
        private void DownloadFileRequest(DownloadFileEvent info)
        {
            if (httpController == null)
            {
                httpController = new HTTPController();
            }
            httpController.DownloadFile(info.url, info.key, info.onCompleteCallback, info.onProgress);
        }
    }
}
