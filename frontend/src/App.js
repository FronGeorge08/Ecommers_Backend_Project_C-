import logo from './logo.svg';
import './App.css';
import Register from './pages/register';
import Login from './pages/login';
import { BrowserRouter , Route,Routes} from 'react-router-dom';
import Header from './components/header';
import Footer from './components/footer';
import Component from './pages/playground';
function App() {
  return (
     <BrowserRouter>
     <Header/>
     <Routes>
      <Route path="/playground" Component={Component}/>
      <Route path="/" Component={Login} />
      <Route path="/register" Component={Register}/>
       </Routes>
       <Footer/>
    </BrowserRouter>
  )
}

export default App;
