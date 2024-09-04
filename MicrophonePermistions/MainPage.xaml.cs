using Microsoft.AspNetCore.Components.WebView;
#if ANDROID 
using MicrophonePermistions.Platforms.Android;
using AndroidX.Activity;
using Microsoft.Maui.ApplicationModel;
#endif
using System;
namespace MicrophonePermistions
{
    public partial class MainPage : ContentPage
    {

        private  void BlazorWebViewInitializing(object? sender, BlazorWebViewInitializingEventArgs e)
        {

        }
        private void BlazorWebViewInitialized(object? sender, BlazorWebViewInitializedEventArgs e)
        {


#if ANDROID

        var activity = Platform.CurrentActivity as ComponentActivity;
        if (activity == null)
        {
            throw new InvalidOperationException($"The permission-managing WebChromeClient requires that the current activity be a '{nameof(ComponentActivity)}'.");
        }
        e.WebView.Settings.JavaScriptEnabled = true;
        e.WebView.Settings.AllowFileAccess = true;
        e.WebView.Settings.MediaPlaybackRequiresUserGesture = false;
        e.WebView.Settings.SetGeolocationEnabled(true);
        e.WebView.Settings.SetGeolocationDatabasePath(e.WebView.Context?.FilesDir?.Path);
        e.WebView.SetWebChromeClient(new PermissionManagingBlazorWebChromeClient(e.WebView.WebChromeClient!, activity));
#endif
        }
        public MainPage()
        {
            InitializeComponent();
        }
    }
}
