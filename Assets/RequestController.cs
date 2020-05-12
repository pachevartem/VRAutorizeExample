using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RequestController : MonoBehaviour
{
    public Text DebugWindow;
    public InputField LoginField;
    public InputField PassField;
    void Start()
    {
        
        // A correct website page.
        // StartCoroutine(GetRequest("https://www.example.com"));
    }

    public void VIZOVIMENYASKNOPKI()
    {
        string url = "http://localhost:5001/weatherforecast/valid?";
        string email = LoginField.text;
        string pass = GetSHA256(PassField.text);
        string request =string.Format($"{url}email={email}&pass={pass}");
        StartCoroutine(GetRequest(request));
    }
    public static string GetSHA256(string word)
    {
        using (SHA256 cr = SHA256.Create())
        {
            var sBuilder = new StringBuilder();
            byte[] _tempB = cr.ComputeHash(Encoding.UTF8.GetBytes(word));

            for (int i = 0; i < _tempB.Length; i++)
            {
                sBuilder.Append(_tempB[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
              string _t = string.Format(pages[page] + ": Error: " + webRequest.error);
              DebugWindow.text = _t;
            }
            else
            {
                string _t = string.Format(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                DebugWindow.text = _t;    
            }
        }
    }
}
