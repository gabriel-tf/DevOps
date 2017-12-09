import React, {Component} from 'react'

class Placar extends Component{

    constructor(params){
        super(params)
        this.state ={
            cont:0,
        }
    }

    calcula(val){
        this.setState({
            cont: this.state.cont + val,
        })
    }

    render(){
        return(
            <div> 
                <div><h4>{this.props.origem}: {this.props.time} </h4></div>
                <div><h4>{this.state.cont}</h4></div>   
                <button onClick={() => this.calcula(1)}>Gol</button>
            </div>
        )
    }
}

export default Placar