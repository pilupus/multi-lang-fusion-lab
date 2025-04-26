const { app, BrowserWindow } = require('electron');
const path = require('path');

const createWindow = () => {
    // 브라우저 창을 생성합니다.
    const win = new BrowserWindow({
        width: 800,
        height: 600,
        webPreferences: {
            preload: path.join(__dirname, 'preload.js'), // Preload 스크립트 경로
            nodeIntegration: false,
            contextIsolation: true
        }
    });

    // React 개발 서버의 URL을 불러옵니다.
    win.loadURL('http://localhost:3000'); // React 앱의 URL로 변경하세요.
    // win.loadFile(path.join(__dirname, 'build', 'index.html')); // 빌드된 React 앱을 사용할 경우 주석 해제
};

app.whenReady().then(() => {
    createWindow();

    app.on('activate', () => {
        // macOS의 경우 닫힌 창이 있으면 다시 생성합니다.
        if (BrowserWindow.getAllWindows().length === 0) createWindow();
    });
});

// 모든 창이 닫히면 애플리케이션을 종료합니다.
app.on('window-all-closed', () => {
    if (process.platform !== 'darwin') app.quit();
});