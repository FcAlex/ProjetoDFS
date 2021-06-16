import { useContext } from 'react'
import { StepContext } from '../../../contexts/steps'
import Card from './Card'
import If from '../../../helpers/If'

const Confirmation = ({title, ...props}) => {

  const { 
    selectedCompany, 
    selectedProducts,
    typeOfPayment,
    boletoInfo,
    creditInfo,
    type } = useContext(StepContext)

  console.log(boletoInfo)

  function payment() {
    switch(typeOfPayment) {
      case type.BOLETO:
        return (
          <ul>
            <h3>Por Boleto</h3>
            <li>Nome: {boletoInfo.nome}</li>
            <li>CPF: ***.***.**{boletoInfo.cpf.substr(10)}</li>
            <li>Telefone: {boletoInfo.telefone}</li>
            <If test={boletoInfo.email}>
              <li>Email: {boletoInfo.email}</li>
            </If>
          </ul>
        )
      case type.CREDIT:
        return (
          <ul>
            <h3>Por Cartão de crédito</h3>
            <li>Cartão: **** **** **** *{creditInfo.number.substr(16)}</li>
          </ul>
        )
      case type.INCASH:
        return (
          <p>Em dinheiro</p>
        )
      default:
        return
    }
  }

  return (
    <Card title={title} navigation={props}>
      <details>
        <summary>Dados da Loja</summary>
        <div className="infos">
          {selectedCompany.companyName}
        </div>
      </details>

      <details>
        <summary>Dados dos Produtos</summary>
        <div className="infos">
          <ul>
            {selectedProducts.map(product => (
              <li>
                <p> {product.name} </p>
                <p> R$ {product.value.toFixed(2)} </p>
              </li>
            ))}
          </ul>
        </div>
      </details>

      <details>
        <summary>Forma de Pagamento</summary>
        <div className="infos">
          {payment()}
        </div>
      </details>
    </Card>
  )
}

export default Confirmation