import React, { Component } from "react";
import Pelicula from "./Pelicula"
//import axios from 'axios';

class Peliculas extends Component {
  state = {
    Peliculas: [
      {
        titulo: "batman vs superman ",
        Image: "https://www.cinemascomics.com/wp-content/uploads/2017/01/Batman-v-Superman-510-x-314.jpg.webp",
      },
      {
        titulo: "batman vs superman 2",
        Image: "https://www.cinemascomics.com/wp-content/uploads/2017/01/Batman-v-Superman-510-x-314.jpg.webp",
      },
      {
        titulo: "batman vs superman 3",
        Image: "https://www.cinemascomics.com/wp-content/uploads/2017/01/Batman-v-Superman-510-x-314.jpg.webp",
      },
      {
        titulo: "batman vs superman 4",
        Image: "https://www.cinemascomics.com/wp-content/uploads/2017/01/Batman-v-Superman-510-x-314.jpg.webp",
      },
      
    ],
    MiFavorita : {} ,
    nombre: "Ivan Taborda",
    Indice: null
  };

  cambiarTitulo = () => {

   
      // axios.get(`http://localhost:36501/RSA?code=1`)
      //   .then(res => {
      //     console.log(res)           
      //   })
        
        
    var {Peliculas} = this.state;
    Peliculas[0].titulo = "AAAAAAAAAAAAAAAAAAAA";
    this.setState ({
      Peliculas 
    });
  }

 favorita = (pelic,key) => {

  this.setState({
    MiFavorita : pelic ,
    Indice : key,
   }) ;
  
  
 }

 const

  render() {  
    return (    
      <div id="content" className="peliculas">
        <h1 className="subheader">Peliculas</h1>
        <div>
          <button name="CambiarNombre" onClick={this.cambiarTitulo}>
            Cambiar Nombre
            </button>
        </div>
        <div>
          
            <strong>La pelicula favorita es : </strong>
            {
              this.state.MiFavorita.titulo &&
              <p>
              <strong> {this.state.MiFavorita.titulo}</strong>
              <strong>Indice : {this.state.Indice}</strong>
              </p>
            }
            
          
        </div>

        <h1>Seleccion de la peliculas favoritas de {this.state.nombre}</h1>

        <div id="articles" className="peliculas">
          {this.state.Peliculas.map((Peli, index) => {
            return (
              <Pelicula key={index} peliculaParam = {Peli} marcarFavorita = {this.favorita} indice = {index}></Pelicula>
            );
          }
          )
          }
        </div>
      </div>
    );
  }
}

export default Peliculas;
