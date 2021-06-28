import { useContext } from 'react'
import { StepContext } from '../../../contexts/steps'
import Card from './Card'
import If from '../../../helpers/If'

const Confirmation = ({ title, ...props }) => {

  const {
    selectedCompany,
    selectedProducts,
    typeOfPayment,
    boletoInfo,
    creditInfo,
    deliveryAddress,
    type } = useContext(StepContext)

  function payment() {
    switch (typeOfPayment) {
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
        return false
    }
  }

  return (
    <Card title={title} navigation={props} className="confirmation">
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
              <li key={product.id}>
                <table className="products-selected">
                  <thead>
                    <tr>
                      <th>ID</th>
                      <th>Produto</th>
                      <th>Valor</th>
                      <th>Descrição</th>
                    </tr>
                  </thead>
                  <tbody>
                    {selectedProducts.map(product => (
                      <tr key={product.id}>
                        <td>{product.id}</td>
                        <td> {product.name} </td>
                        <td> R$ {product.value.toFixed(2)} </td>
                        <td> {product.description} </td>
                      </tr>
                    ))}
                  </tbody>
                </table>
              </li>
            ))}
          </ul>
        </div>
      </details>

      <details>
        <summary>Forma de Pagamento</summary>
        <div className="infos method-payment">
          {payment()}
        </div>
      </details>

      <details>
        <summary>Endereço</summary>
        <div className="infos">
          <ul className="endereco-infos">
            <li><strong>Rua: </strong> {deliveryAddress.rua}</li>
            <li><strong>Nr.: </strong> {deliveryAddress.numero}</li>
            <li><strong>Complemento: </strong> {deliveryAddress.complemento}</li>
            <li><strong>Bairro: </strong> {deliveryAddress.bairro}</li>
            <li><strong>CEP: </strong> {deliveryAddress.cep}</li>
            <li><strong>Cidade: </strong> {deliveryAddress.cidade}</li>
            <li><strong>Estado: </strong> {deliveryAddress.estado}</li>
          </ul>
        </div>
      </details>
    </Card>
  )
}

export default Confirmation