import React, {Component} from 'react'
import Placar from './placar'
import dateFormat from 'dateformat'

class Container extends Component{

    render(){
        const data = new Date();

        return(
            <div className="Center">
                <div className="Container"> 
                    <div className="Placar">
                    <Placar time = "Fortaleza" origem = "Casa" />
                    </div>
                    <div className="Partida">
                    <div>
                        <p>Castelão</p>
                        <p>{dateFormat(data, 'dd/mm/yyyy HH:MM')}</p>
                    </div>
                    </div>
                    <div className="Placar">
                    <Placar time = "Siará" origem = "Visitante"/>
                    </div>
                </div>
            </div>
        )
    }
}

export default Container