
import './assets/css/App.css';
//impoerts modules

import Header from './components/Header';
import Slider from './components/Slider';
import SideBar from './components/SideBar';
import Footer from './components/Footer';
import SeccionPruebas from './components/SeccionPruebas';
import Peliculas from './components/Peliculas';

function App() {
  return (
    <div className="App">
      <Header />
      <Slider/>
      
      <div className="Center">
      <Peliculas></Peliculas>
      <SideBar/>
        <div className="clearfix"></div>
      </div> 

      <Footer/>  
      
    </div>
  );
}

export default App;
