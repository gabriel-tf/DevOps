import React, { Component } from 'react'
import Heroes from './my_heroes/Heroes'

class Hero extends Component {
  render() {
    return (
        <div className="container body-content">            
            <h1>My Heroes</h1>            
            <Heroes />
        </div>
    )
  }
}

export default Hero;
