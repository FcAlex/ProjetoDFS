import { Steps, Step } from 'react-step-builder'
import Company from './Steps/Company'
import Product from './Steps/Product'
import Payment from './Steps/Payment'
import Confirmation from './Steps/Confirmation'

import './styles.css'
import Navigation from './Steps/Navigation'
import StepProvider, { StepContext } from '../../contexts/steps'
import { useContext } from 'react'

const Purchase = props => {

  const { disableNext } = useContext(StepContext)

  const Nav = props => <Navigation disable={disableNext} {...props}></Navigation>

  return (
    <StepProvider>
      <main className="purchase">
        <h1>Comprar</h1>
        <Steps config={{ navigation: { component: Nav, location: "after" } }}>
          <Step title="Selecione a loja" component={Company} />
          <Step title="Selecione o item" component={Product} />
          <Step title="Selecione a forma de pagamento" component={Payment} />
          <Step title="Confirme a compra" component={Confirmation} />
        </Steps>
      </main>
    </StepProvider>
  )
}

export default Purchase