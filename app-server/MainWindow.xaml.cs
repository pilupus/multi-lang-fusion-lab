using System;
using System.IO;
using System.Windows;
using Microsoft.Web.WebView2.Core;

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
            try
            {
                // 로컬 애플리케이션 데이터 폴더 아래에 사용자 데이터 폴더 지정
                string userDataFolder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "app-server",
                    "WebView2UserData"
                );

                // 본 예제에서는 기본 브라우저 실행 파일 경로(null)와 사용자 데이터 폴더를 지정하여 환경 생성
                var env = await CoreWebView2Environment.CreateAsync(null, userDataFolder, null);
                await webView2.EnsureCoreWebView2Async(env);
            }
            catch (Exception ex)
            {
                MessageBox.Show("WebView2 초기화 중 오류 발생: " + ex.Message);
            }
        }
    }
}