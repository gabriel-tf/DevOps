import React, {Component} from 'react'

class Contador extends Component{

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
                <div><h4>{this.props.nome}</h4></div>
                <div><h4>{this.state.cont}</h4></div>
                <button onClick={() => this.calcula(-1)}>-</button>
                <button onClick={() => this.calcula(1)}>+</button>
            </div>
        )
    }
}

export default Contador