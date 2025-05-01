using System;
using System.Windows;
using Microsoft.Web.WebView2.Wpf;

namespace app_server
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeWebView();
        }

        private async void InitializeWebView()
        {
            // WebView2의 CoreWebView2 초기화 후 파일 로드
            await webView2.EnsureCoreWebView2Async();
            // UI 폴더에 있는 index.html 파일을 로드합니다.
            // UI 폴더가 실행 파일 기준 상대 경로에 있다면 아래와 같이 작성할 수 있습니다.
            string uiFolderPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ui");
            string fullPath = System.IO.Path.Combine(uiFolderPath, "index.html");

            // 파일 경로의 "\"를 "/"로 변경하여 file URI 형식이 맞게 변환합니다.
            string uriPath = "file:///" + fullPath.Replace("\\", "/");
            webView2.Source = new Uri(uriPath);
        }
    }
}