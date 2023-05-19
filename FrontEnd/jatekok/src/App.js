import { BrowserRouter, NavLink, Route, Routes } from 'react-router-dom';
import './App.css';
import { GamesListPage } from "./GamesListPage";
import { GameSinglePage} from "./GameSinglePage";
import { GameAddPage } from "./GameAddPage";

function App() {
  return (
    <BrowserRouter>
      <nav className="navbar navbar-expand-sm navbar-primary bg-primary ">
        <div className="collapse navbar-collapse" id="navbarNav">
          <ul className="navbar-nav">
            <li className="nav-item">
              <NavLink to={`/`} className={({ isActive }) => "nav-link" + (isActive ? " active" : "")} end>
                <span className="nav-link">Játékok</span>
              </NavLink>
            </li>
            <li className="nav-item">
            <NavLink to={`/uj-jatek`} className={({ isActive }) => "nav-link" + (isActive ? " active" : "")} end>
                <span className="nav-link">Új játék</span>
              </NavLink>
            </li>
          </ul>
        </div>
      </nav>
      <Routes>
        <Route path='/' element={<GamesListPage />} />
        <Route path='/jatek/:jatekId' element={<GameSinglePage />} />
        <Route path='/uj-jatek' element={<GameAddPage />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
