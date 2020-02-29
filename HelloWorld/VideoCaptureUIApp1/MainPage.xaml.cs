using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.Media.Core;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace VideoCaptureUIApp1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        CameraCaptureUI captureUI = new CameraCaptureUI();
        
        public MainPage()
        {
            this.InitializeComponent();
            captureUI.VideoSettings.Format = CameraCaptureUIVideoFormat.Mp4;

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            StorageFile videoFile = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Video);

            if (videoFile == null)
            {
                return;
            }
            mediaPlayerElemet.Source = MediaSource.CreateFromStorageFile(videoFile);
            mediaPlayerElemet.MediaPlayer.Play();
        }
    }
}
