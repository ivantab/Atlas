import React, { Component } from "react";

class Pelicula extends Component {

marcar = () => {
  this.props.marcarFavorita (this.props.peliculaParam,this.props.indice)
}

    render() 
    {
        
        const {titulo, Image} = this.props.peliculaParam;



        return (
          
                <article className="article-item" id="article-template">
                <div className="image-wrap">
                  <img src={Image} alt={titulo}/>               
                </div>
                <h2>{titulo}</h2>
                <span className="date">Hace 5 minutos</span>
                <a href="/">Leer más</a>
                <button onClick={this.marcar}> 
                    Marcar Como Favorito
                </button>
                <div className="clearfix"></div>
              </article>
                
           
        );
    }

}

export default Pelicula;