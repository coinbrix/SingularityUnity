using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyUI.Toast;

public class ButtonClickHandler: MonoBehaviour, ISingularityUnitySdkProtocol
{
    private SingularityUnity _singularityUnity; 
    void Awake()
    {
        UnityThread.initUnityThread();
    }
	
    public void OnButtonClick()
    {
        Debug.Log("Button Clicked");
        Dictionary<string, object> parameters = new Dictionary<string,object>();

        parameters.Add("key", "neobrix");
        
        Dictionary<string, string> parametersInternal = new Dictionary<string,string>();
        parametersInternal.Add("environment", "1");

        parameters.Add("singularityConfig", parametersInternal);

        if (_singularityUnity == null)
        {
            _singularityUnity = new SingularityUnity(this);
        }
        _singularityUnity.OpenLoginScreen(parameters);
    }

    public Dictionary<string, object> getUserData()
    {
        return SingularityUnity.GetUserData();
    }

    public void onGetSingularityUserInfo(Dictionary<string, object> info)
    {
        Debug.Log("NewButtonHandler - onGetSingularityUserInfo - " + info);
        foreach (var pair in info) {
         Debug.Log("{0} {1}" + pair.Key + pair.Value);
        }
    }

    public void onSingularityClose()
    {
        Debug.Log("NewButtonHandler - onSingularityClose");
        UnityThread.executeInUpdate(() =>
        {
            Toast.Show ("onSingularityClose") ;
        });
    }

    public void onSingularityLogout()
    {
        Debug.Log("NewButtonHandler - onSingularityLogout");
        UnityThread.executeInUpdate(() =>
        {
            Toast.Show ("onSingularityLogout") ;
        });
    }

    public void onSingularityError(string message, int errCode)
    {
        Debug.Log("NewButtonHandler - onSingularityError");
        UnityThread.executeInUpdate(() =>
        {
            Toast.Show ("onSingularityError") ;
        });
    }
}