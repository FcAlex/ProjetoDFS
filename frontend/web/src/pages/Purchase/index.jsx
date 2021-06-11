import { Steps, Step } from 'react-step-builder'
import Company from './Steps/Company'
import Product from './Steps/Product'
import Payment from './Steps/Payment'
import Confirmation from './Steps/Confirmation'

import './styles.css'

const HeaderNav = props => (
  <nav className="navegation">
    <ul>
      <li>Loja</li>
      <li>Produto</li>
      <li>Pagamento</li>
      <li>Confirmação</li>
    </ul>
  </nav>
)

const Purchase = props => {
  return (
    <main className="purchase">
      <h1>Comprar</h1>
      <Steps config={{ navigation: { component: HeaderNav, location: "before" } }}>
        <Step title="Selecione a loja" component={Company} />
        <Step title="Selecione o item" component={Product} />
        <Step title="Selecione a forma de pagamento" component={Payment} />
        <Step title="Confirme a compra" component={Confirmation} />
      </Steps>
    </main>
  )
}

export default Purchase