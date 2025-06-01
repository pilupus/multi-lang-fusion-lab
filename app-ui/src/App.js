import logo from './logo.svg';
import './App.css';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <h1>This is header</h1>
      </header>
      <main>
        <h1>This is main</h1>
      </main>
      <footer>
        <h1>This is footer</h1>
      </footer>
    </div>
  );
}

export default App;
