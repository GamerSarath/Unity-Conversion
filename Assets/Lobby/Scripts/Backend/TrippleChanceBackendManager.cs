/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class TrippleChanceBackendManager : MonoBehaviour
{
    IEnumerator StartGame(string uid, string apitoken, int gameid, int dev,int gameplay )
    {
        WWWForm form = new WWWForm();
        form.AddField("uid", uid);
        form.AddField("game_id", gameid);
        form.AddField("dev", dev);
        form.AddField("game_play", gameplay);
      //  form.AddField("bet_single[]", GameManager.Instance.selectedSingleCells.ToArray());

        form.AddField("api_token", apitoken);

        UnityWebRequest www = UnityWebRequest.Post(url, form);
        yield return www.Send();

        if (www.error != null)
        {
            Debug.Log(www.error);
        }
        else
        {

            Debug.Log("Response is " + www.downloadHandler.text);
            JsonUtility.FromJson<LoginData>(www.downloadHandler.text);
            if (BackendManager.Instance.loginDatas.status)
            {
                SceneManager.LoadScene(2);

            }
        }
    }
}
*/