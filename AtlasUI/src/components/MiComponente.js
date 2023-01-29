import React, {Component} from "react";

class   MiComponente extends Component {
  render() {

    let receta= { 
        nombre: 'Pizza',
        ingredientes: ['Harina', 'Levadura', 'Tomate', 'Queso', 'Salsa'],
        calorias: '500'
     }


    return (   
        //Fragment es una etiqueta que no se muestra en pantalla y es necesaria porque return en jsx solo toma de a una etiqueta
        <React.Fragment>
        <h1>{receta.nombre}</h1>
        <h2>{receta.calorias}</h2>
        <ol>
            {receta.ingredientes.map((ingrediente,i) => <li key={i}>{ingrediente}</li>)}
        </ol>
        </React.Fragment>
    );
  }
}

export default MiComponente;