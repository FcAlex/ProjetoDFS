import PaymentCard from 'react-credit-cards'
import Card from './Card'
import { Steps, Step } from 'react-step-builder'
import Input from '../../../components/Input'

import 'react-credit-cards/es/styles-compiled.css'
import { useContext, useEffect, useReducer } from 'react';

import imgCash from '../../../assets/cash.png'
import { StepContext } from '../../../contexts/steps'

const Credit = () => {

  const initialState = {
    cvc: '',
    expiry: '',
    focus: '',
    name: '',
    number: '',
  }

  const [state, dispatch] = useReducer(reducer, initialState);
  const { updateBoletoInfo, updateCreditInfo, handlePaymentInCash } = useContext(StepContext)

  useEffect(() => {
    updateBoletoInfo(null)
    handlePaymentInCash(false)
  }, [updateBoletoInfo, handlePaymentInCash])

  useEffect(() => {
    updateCreditInfo(state)
  }, [updateCreditInfo, state])

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

const Boleto = () => {

  const initialState = {
    nome: '',
    cpf: '',
    telefone: '',
    email: ''
  }

  const [state, dispatch] = useReducer(reducer, initialState);
  const { updateCreditInfo, updateBoletoInfo, handlePaymentInCash } = useContext(StepContext)

  useEffect(() => {
    updateCreditInfo(null)
    handlePaymentInCash(false)
  }, [updateCreditInfo, handlePaymentInCash])

  useEffect(() => {
    updateBoletoInfo(state)
  }, [updateBoletoInfo, state])

  function reducer(state, action) {
    return { ...state, [action.type]: action.value }
  }

  return (
    <form className="boleto">
      <h3>Informe seus dados para geração do boleto</h3>
      <Input type="text" placeholder="Nome completo" value={state.nome}
        onChange={e => dispatch({ type: 'nome', value: e.target.value })}
        required
      />
      <Input type="tel" placeholder="CPF" value={state.cpf}
        onChange={e => dispatch({ type: 'cpf', value: e.target.value })}
        mask="999.999.999-99" required
      />
      <Input type="tel" placeholder="Telefone" value={state.telefone}
        onChange={e => dispatch({ type: 'telefone', value: e.target.value })}
        mask="(99) 9 9999-9999" required
      />
      <Input type="email" placeholder="Email (Opcional)" value={state.email}
      onChange={e => dispatch({ type: 'email', value: e.target.value })}
      />
    </form>
  )
}

const Cash = () => {

  const { updateCreditInfo, handlePaymentInCash, updateBoletoInfo } = useContext(StepContext)

  useEffect(() => {
    updateCreditInfo(null)
    updateBoletoInfo(null)
    handlePaymentInCash(true)
  }, [updateCreditInfo, handlePaymentInCash, updateBoletoInfo])

  return (
    <div className="cash">
      <span>
        <i className="fas fa-exclamation-circle"></i>
        <h1 className="title-cash">O pagamento será realizado no momento do recebimento</h1>
      </span>
      <img src={imgCash} alt="Pagamento em dinheiro" />
    </div>
  )
}

const Nav = ({ allSteps, jump, current }) => (
  <ul className="nav-steps">
    {allSteps.map(step => (
      <li key={step.order} onClick={() => jump(step.order)} className={step.order === current ? 'step-selected' : ''}> {step.title} </li>
    ))}
  </ul>
)

const Payment = ({ title, ...props }) => {

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