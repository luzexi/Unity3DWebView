using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using Kogarasi.WebView;


//	WebView.cs
//	Author: Lu Zexi
//	2014-07-17


/// <summary>
/// Web view.
/// </summary>
public class WebView : MonoBehaviour
{
	private static WebView s_cInstance;
	public static WebView cInstance
	{
		get
		{
			if(s_cInstance == null)
			{
				GameObject obj = new GameObject("WebView");
				s_cInstance = obj.AddComponent<WebView>();
			}
			return s_cInstance;
		}
	}


	private IWebView webView;
	private IWebViewCallback	callback = null;

#region Method

	public void Awake()
	{

#if UNITY_ANDROID
		webView = new WebViewAndroid();
#elif UNITY_IPHONE
		webView = new WebViewIOS();
#else
		webView = new WebViewNull();
#endif

		webView.Init( name );
	}

	public void OnDestroy()
	{
		webView.Term();
	}

	public void SetMargins( int x, int y, int width, int height )
	{
		webView.SetMargins( x, y, width, height );
	}

	public void SetVisibility( bool state )
	{
		webView.SetVisibility( state );
	}

	public void LoadURL( string url )
	{
		webView.LoadURL( url );
	}

	public void EvaluateJS( string js )
	{
		webView.EvaluateJS( js );
	}

	/*
	public void CallFromJS( string message )
	{
		Debug.Log( "CallFromJS : " + message );
	}
	*/

	public void setCallback( IWebViewCallback _callback )
	{
		callback = _callback;
	}

	public void onLoadStart( string url )
	{
		if( callback != null )
		{
			callback.onLoadStart( url );
		}
	}

	public void onLoadFinish( string url )
	{
		if( callback != null )
		{
			callback.onLoadFinish( url );
		}
	}

	public void onLoadFail( string url )
	{
		if( callback != null )
		{
			callback.onLoadFail( url );
		}
	}

#endregion

}
