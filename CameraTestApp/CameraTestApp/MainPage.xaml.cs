using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 を参照してください

namespace CameraTestApp
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void PhotoNoCrop(object sender, TappedRoutedEventArgs e)
        {
            var camera = new CameraCaptureUI();
            camera.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            camera.PhotoSettings.AllowCropping = false;
            var file = await camera.CaptureFileAsync(CameraCaptureUIMode.Photo);
            Debug.WriteLine("OK");
        }

        private async void PhotoCrop(object sender, TappedRoutedEventArgs e)
        {
            var camera = new CameraCaptureUI();
            camera.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            camera.PhotoSettings.AllowCropping = true;
            await camera.CaptureFileAsync(CameraCaptureUIMode.Photo);
        }

        private async void VideoNoTrim(object sender, TappedRoutedEventArgs e)
        {
            var camera = new CameraCaptureUI();
            camera.VideoSettings.Format = CameraCaptureUIVideoFormat.Mp4;
            camera.VideoSettings.AllowTrimming = false;
            var file = await camera.CaptureFileAsync(CameraCaptureUIMode.Video);
        }

        private async void VideoTrim(object sender, TappedRoutedEventArgs e)
        {
            var camera = new CameraCaptureUI();
            camera.VideoSettings.Format = CameraCaptureUIVideoFormat.Mp4;
            camera.VideoSettings.AllowTrimming = true;  
            var file = await camera.CaptureFileAsync(CameraCaptureUIMode.Video);
        }

        private async void VideoOrPhoto(object sender, TappedRoutedEventArgs e) {
            var camera = new CameraCaptureUI();
            camera.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            camera.PhotoSettings.AllowCropping = true;
            camera.VideoSettings.Format = CameraCaptureUIVideoFormat.Mp4;
            camera.VideoSettings.AllowTrimming = true;
            var file = await camera.CaptureFileAsync(CameraCaptureUIMode.PhotoOrVideo);
            Debug.WriteLine($"file={file.Name} ({file.ContentType})");
        }
    }
}
