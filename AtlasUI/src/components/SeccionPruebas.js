import React, {Component} from "react";

import MiComponente from './MiComponente';
import Peliculas from './Peliculas';


class SeccionPruebas extends Component {

 contador = 0;

incrementar = () => { this.setState({
    contador: (this.state.contador + 1)
}); }
decrementar = () => { this.setState({
    contador: (this.state.contador - 1)
});
 }


    state = {
        contador: 0
    }


    render() {
        return (
            <div>
<section id='content'>
            
            <section className='Componentes'>
               <MiComponente />
               <Peliculas />
            </section>
            <p>{this.state.contador}</p>
            <input type="button" value="Incrementar" onClick={this.incrementar} />
            <input type="button" value="Decrementar" onClick={this.decrementar} />
            </section>

            </div>
            
        );
    }
}

export default SeccionPruebas;