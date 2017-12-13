import React, { Component } from 'react'
import axios from 'axios'
import Input from '../form/Input'
import Button from '../form/Button'

class Heroes extends Component {
    constructor(props) {
        super(props)

        this.state = { list: [], stateChanged: false }
    }    

    componentWillMount() {
        this.getList()
    }

    getList() {
        axios.get('http://localhost:51162/api/Heroes')
            .then(resp => {
                this.setState({ list: resp.data })                
            })
            .catch(e => {                
                {alert("Erro ao acessar os dados.")}
            })
    }

    newHero() {
        const { list } = this.state                
        list.push({nome: '', checked: false})
        this.setState({list})
    }

    removeHero(hero, index) {
        const { list } = this.state

        if (list.length > 1) {
            if (hero.id !== undefined) {
                this.submit(hero, 'delete')
            }
                        
            list.splice(index, 1)
            this.setState({list})
        } else {
            {alert('Não foi possível excluir este herói.')}
        }
    }

    submit(values, method) {        
        const { list } = this.state        
        const id = values.id ? values.id : ''
        axios[method](`http://localhost:51162/api/Heroes/${id}`, values)
            .then(resp => {                
                let msg = ''
                let typeMsg = 'success'
                switch (method) {
                    case 'post':
                        msg = 'inserido'                        
                        list[values.index].id = resp.data.id
                        break
                    case 'put':
                        msg = 'atualizado'
                        break
                    case 'delete':
                        msg = 'removido'
                        typeMsg = 'error'
                        break
                    default:
                        break
                }                

                {alert(`Item ${msg} com sucesso!`)}
            })
            .catch(e => {
                {alert('Não foi possível realizar esta operação')}
            })
        
        if (method === 'post')
            this.setState({list})
    }

    updateListState = obj => (element) => {
        const { list } = this.state
        list.map(hero => {

            if (hero.id === obj.id) {
                if (element.target.name === 'input_text_' + obj.id) {
                    hero.name = element.target.value
                }

                if (element.target.name === 'input_text_power_of_' + obj.id) {
                    hero.power = element.target.value
                }

                if (element.target.type === 'checkbox') {
                    hero.checked = element.target.checked
                    this.submit(hero, 'put')
                }
            }
            return hero;
        })

        this.setState({
            list,
            stateChanged: true
        })
    }

    handlePostPut(hero, index) {
        hero.index = index
        
        if (hero.id !== undefined) {
            const { stateChanged } = this.state
            if (stateChanged) {
                this.submit(hero, 'put')
                this.setState({ stateChanged: false })
            }
        } else {            
            if (hero.name !== '') {
                this.submit(hero, 'post')
            }
        }
    }

    renderRows() {
        const list = this.state.list || []

        return list.map((hero, index) => (
            <tr className={"tr_clone row" + (hero.checked ? ' item-checked' : '')} key={index}>
                <td>  
                    <Input
                        readOnly={false}
                        type="text"      
                        name={"input_text_" + hero.id}
                        value={hero.name}
                        onChange={this.updateListState(hero)}
                        />
                    <Input
                        readOnly={false}
                        type="text"      
                        name={"input_text_power_of_" + hero.id}
                        value={hero.power}
                        onChange={this.updateListState(hero)}
                        onBlur={() => this.handlePostPut(hero, index)}
                        />
                    <Button 
                        className="remove btn btn-default btn-sm"
                        onClick={() => this.removeHero(hero, index)}>
                        <span className="glyphicon glyphicon-minus"></span>
                    </Button>                                        
                </td>
            </tr>
        ))
    }

    renderNewHeroBtn(){
        return (
        <Button 
            className="add btn btn-default btn-sm"
            onClick={() => this.newHero()}>
            <span className="glyphicon glyphicon-plus"></span>
        </Button>
        )
    }

    render() {
        return (
            
            <div> 
                <div className="pad" > 
                    {this.renderNewHeroBtn()} 
                </div>        
                <table className="table">
                    <tbody>        
                        {this.renderRows()}
                    </tbody>
                </table>                
            </div>
        )
    }
}

export default Heroes