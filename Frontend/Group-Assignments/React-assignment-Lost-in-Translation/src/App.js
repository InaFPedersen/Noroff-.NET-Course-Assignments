import logo from './logo.svg';
import './App.css';
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import { LoginPage } from './views/LoginPage.jsx'
import { ProfilePage } from './views/ProfilePage.jsx'
import { TranslationPage } from './views/TranslationPage.jsx'
import { useState } from 'react'
function App() {
  let [translations, setTranslations] = useState([])
  let [username, setUsername] = useState("");
  const loginGuard = () => {
    if (username === "") {
      return (
        <>

          <Route path='/Translation/' element={<LoginPage setUsername={setUsername} setTranslations={setTranslations} translations={translations} />} />
          <Route path='/Profile/' element={<LoginPage setUsername={setUsername} setTranslations={setTranslations} translations={translations} />} />
        </>
      )
    }
    return (
      <>
        <Route path='/Translation/' element={<TranslationPage username={username} setTranslations={setTranslations} translations={translations} />} />
        <Route path='/Profile/' element={<ProfilePage username={username} setUsername={setUsername} setTranslations={setTranslations} translations={translations} />} />
      </>
    )
  }
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <div>
          <BrowserRouter>
            <Routes>

              <Route path='/' element={<LoginPage setUsername={setUsername} setTranslations={setTranslations} translations={translations} />} />
              {loginGuard()}
            </Routes>
          </BrowserRouter>
        </div>
      </header>
    </div>
  );
}

export default App;
