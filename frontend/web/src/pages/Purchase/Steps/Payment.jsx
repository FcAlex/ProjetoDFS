import PaymentCard from 'react-credit-cards'
import Card from './Card'
import { Steps, Step } from 'react-step-builder'
import Input from '../../../components/Input'

import 'react-credit-cards/es/styles-compiled.css'
import { useReducer } from 'react';
import Button from '../../../components/Button'

const initialState = {
  cvc: '',
  expiry: '',
  focus: '',
  name: '',
  number: '',
}

const Payment = ({ title, ...props }) => {

  const [state, dispatch] = useReducer(reducer, initialState);

  function setFocus(e) {
    dispatch({ type: 'focus', value: e.target.name })
  }

  function reducer(state, action) {
    return { ...state, [action.type]: action.value.replaceAll('_', '') }
  }

  const Credit = (props) => (
    <div className="payment-options">
      <PaymentCard
        cvc={state.cvc}
        expiry={state.expiry}
        focused={state.focus}
        name={state.name}
        number={state.number}
      />

      <form className="info-payment">
        <Input type="tel" placeholder="Número do Cartão" name="number" value={state.number}
          onChange={e => dispatch({ type: 'number', value: e.target.value })}
          onFocus={setFocus} mask="9999 9999 9999 9999"
        />
        <Input type="text" placeholder="Nome do titular" name="name" value={state.name}
          onChange={e => dispatch({ type: 'name', value: e.target.value })}
          onFocus={setFocus} maxLength={25}
        />
        <Input type="text" placeholder="Data de expiração" name="expiry" value={state.expiry}
          onChange={e => dispatch({ type: 'expiry', value: e.target.value })}
          onFocus={setFocus} mask="99/99"
        />
        <Input type="text" placeholder="CVC" value={state.cvc} name="cvc"
          onChange={e => dispatch({ type: 'cvc', value: e.target.value })}
          onFocus={setFocus} mask="999"
        />
      </form>
    </div>
  )

  const Boleto = () => (
    <h1>Boleto</h1>
  )

  const Cash = () => (
    <h1>Dinheiro</h1>
  )

  const Nav = ({ allSteps, jump, current }) => (
    <ul className="nav-steps">
      {allSteps.map(step => (
        <li key={step.order} onClick={() => jump(step.order)} className={step.order === current ? 'step-selected' : ''}> {step.title} </li>
      ))}
    </ul>
  )

  return (
    <Card title={title} navigation={props} className="payment">
      <Steps config={{ navigation: { component: Nav, location: "before" } }}>
        <Step title="Pagamento por cartão de crédito" component={Credit} />
        <Step title="Pagamento por Boleto" component={Boleto} />
        <Step title="Pagamento em dinheiro" component={Cash} />
      </Steps>
    </Card>
  )
}

export default Payment