import PaymentCard from 'react-credit-cards'
import Card from './Card'

import Input from '../../../components/Input'

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
  return {...state, [action.type]: action.value.replaceAll('_', '')}
}

const Payment = ({ title, ...props }) => {

  const [state, dispatch] = useReducer(reducer, initialState);

  function setFocus(e) {
    dispatch({type: 'focus', value: e.target.name})
  }

  return (
    <Card title={title} navigation={props} className="payment">
      <PaymentCard
        cvc={state.cvc}
        expiry={state.expiry}
        focused={state.focus}
        name={state.name}
        number={state.number}
      />

      <form className="info-payment">
        <Input type="tel" placeholder="Número do Cartão" name="number" value={state.number}
          onChange={e => dispatch({type: 'number', value: e.target.value})}
          onFocus={setFocus} mask="9999 9999 9999 9999"
        />
        <Input type="text" placeholder="Nome do titular" name="name" value={state.name}
          onChange={e => dispatch({type: 'name', value: e.target.value})}
          onFocus={setFocus} maxLength={25}
        />
        <Input type="text" placeholder="Data de expiração" name="expiry" value={state.expiry}
          onChange={e => dispatch({type: 'expiry', value: e.target.value})}
          onFocus={setFocus} mask="99/99"
        />
        <Input type="text" placeholder="CVC" value={state.cvc} name="cvc"
          onChange={e => dispatch({type: 'cvc', value: e.target.value})} 
          onFocus={setFocus} mask="999"
        />
      </form>
    </Card>
  )
}

export default Payment