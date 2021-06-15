import PaymentCard from 'react-credit-cards'
import Card from './Card'
import { Steps, Step } from 'react-step-builder'
import Input from '../../../components/Input'

import 'react-credit-cards/es/styles-compiled.css'
import { useReducer } from 'react';
import Button from '../../../components/Button'

import imgCash from '../../../assets/cash.png'

const initialState = {
  cvc: '',
  expiry: '',
  focus: '',
  name: '',
  number: '',
}

const Payment = ({ title, ...props }) => {

  const Credit = () => {

    const [state, dispatch] = useReducer(reducer, initialState);

    function reducer(state, action) {
      return { ...state, [action.type]: action.value.replaceAll('_', '') }
    }

    function setFocus(e) {
      dispatch({ type: 'focus', value: e.target.name })
    }

    return (
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
            onFocus={setFocus} mask="9999 9999 9999 9999" required
          />
          <Input type="text" placeholder="Nome do titular" name="name" value={state.name}
            onChange={e => dispatch({ type: 'name', value: e.target.value })}
            onFocus={setFocus} maxLength={25} required
          />
          <Input type="text" placeholder="Data de expiração" name="expiry" value={state.expiry}
            onChange={e => dispatch({ type: 'expiry', value: e.target.value })}
            onFocus={setFocus} mask="99/99" required
          />
          <Input type="text" placeholder="CVC" value={state.cvc} name="cvc"
            onChange={e => dispatch({ type: 'cvc', value: e.target.value })}
            onFocus={setFocus} mask="999" required
          />
        </form>
      </div>
    )
  }

  const Boleto = () => (
    <form className="boleto">
      <Input type="text" placeholder="Nome completo" name="nameBoleto" //value={state.number}
        // onChange={e => dispatch({ type: 'number', value: e.target.value })}
        // onFocus={setFocus} 
        required
      />
      <Input type="tel" placeholder="Número" name="number" //value={state.number}
        // onChange={e => dispatch({ type: 'number', value: e.target.value })}
        // onFocus={setFocus} 
        mask="999.999.999-99" required
      />
      <Input type="tel" placeholder="Telefone" name="cpf" //value={state.number}
        // onChange={e => dispatch({ type: 'number', value: e.target.value })}
        // onFocus={setFocus} 
        mask="(99) 9 9999-9999" required
      />
      <Input type="email" placeholder="Email (Opcional)" name="email" //value={state.number}
        // onChange={e => dispatch({ type: 'number', value: e.target.value })}
        // onFocus={setFocus} 
      />
      <Button bg="blue">Gerar Boleto</Button>
    </form>
  )

  const Cash = () => (
    <div className="cash">
      <span>
        <i class="fas fa-exclamation-circle"></i>
        <h1 className="title-cash">O pagamento será realizado no momento do recebimento</h1>
      </span>
      <img src={imgCash} alt="Pagamento em dinheiro" />
    </div>
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