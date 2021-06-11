import Cards from 'react-credit-cards'
import Card from './Card'

import 'react-credit-cards/es/styles-compiled.css'
import { useReducer } from 'react';

const initialState = {
  cvc: '',
  expiry: '',
  focus: '',
  name: '',
  number: '',
}

function reducer(state, action) {
  return {...state, [action.type]: action.value}
}

const Payment = ({ title, ...props }) => {

  const [state, dispatch] = useReducer(reducer, initialState);

  return (
    <Card title={title} navigation={props}>
      <Cards
        cvc={state.cvc}
        expiry={state.expiry}
        focused={state.focus}
        name={state.name}
        number={state.number}
      />

      <form action="">
        <input type="tel" placeholder="Número do Cartão" value={state.number}
          onChange={e => dispatch({type: 'number', value: e.target.value})}
          onFocus={e => dispatch({type: 'focus', value: 'number'})}
        />
        <input type="text" placeholder="Nome do titular" value={state.name}
          onChange={e => dispatch({type: 'name', value: e.target.value})}
          onFocus={e => dispatch({type: 'focus', value: 'name'})}
        />
        <input type="text" placeholder="Data de expiração" value={state.expiry}
          onChange={e => dispatch({type: 'expiry', value: e.target.value})}
          onFocus={e => dispatch({type: 'focus', value: 'expiry'})}
        />
        <input type="text" placeholder="CVC" value={state.cvc}
          onChange={e => dispatch({type: 'cvc', value: e.target.value})}
          onFocus={e => dispatch({type: 'focus', value: 'cvc'})}
        />
      </form>
    </Card>
  )
}

export default Payment