using UnityEngine;
using System.Collections;
using Kogarasi.WebView;

public class TestView : MonoBehaviour , IWebViewCallback 
{

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}

	void OnGUI()
	{
		if(GUI.Button( new Rect(0,0,100,30) , "start"))
		{
			WebView.cInstance.LoadURL("http://www.luzexi.com");
			WebView.cInstance.setCallback(this);
			WebView.cInstance.SetVisibility(true);
			WebView.cInstance.SetMargins(0,0,640,960);
		}
		if(GUI.Button(new Rect(0,30,100,30),"close"))
		{
			WebView.cInstance.SetVisibility(false);
		}
	}

	public void onLoadStart( string url )
	{
		Debug.Log("start " + url);
	}
	public void onLoadFinish( string url )
	{
		Debug.Log("finish " + url);
	}
	public void onLoadFail( string url )
	{
		Debug.Log("fail " + url);
	}
}
