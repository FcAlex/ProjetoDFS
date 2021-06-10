import { format } from 'date-fns'
import Button from '../../components/Button'

import api from '../../services/api'
import { purchases as getPurchases } from '../../services/api_test'
import useAuth from '../../hooks/useAuth'
import { useEffect, useState } from 'react'
import { logout } from '../../services/auth'
import Popup from 'reactjs-popup';
import 'reactjs-popup/dist/index.css';

import './styles.css'

const Order = props => {

  const [purchases, setPurchases] = useState([])
  const [filterText, setFilterText] = useState('')
  const { getData } = useAuth()
  const { id } = getData()

  useEffect(() => {
    (async () => {
      try {
        // const response = await api.get("/purchase", { params: id})
        const response = await getPurchases()

        setPurchases(response.data)
      } catch (error) {
        if (error.response.status === 401) logout()
      }
    })()
  }, [id])

  useEffect(() => {
    if (filterText) {
      setPurchases(purchases.filter(purchase => purchase.name.includes(filterText)))
    }
  }, [filterText, purchases])

  function handleFilter(e) {
    setFilterText(e.target.value)
  }

  function defineStatus(purchase) {
    switch (purchase.status) {
      case 1:
        return 'Emitido'
      case 2:
        return 'Confirmado'
      case 3:
        return 'Enviado'
      case 4:
        return 'Entregue'
      case 5:
        return 'Cancelado'
      default:
        return 'Erro'
    }
  }

  function definePaymentMethod(purchase) {
    switch (purchase.paymentMethod) {
      case 1:
        return 'Crédito'
      case 2:
        return 'Débito'
      case 3:
        return 'Em dinheiro'
      default:
        return 'Erro'
    }
  }

  function generatePDF() {

  }

  function renderRows() {
    return (
      purchases.map(purchase => (
        <tr key={purchase.id}>
          <td>{purchase.id}</td>
          <td>{purchase.name}</td>
          <td>R${purchase.value.toFixed(2)}</td>
          <td>{defineStatus(purchase)}</td>
          <td>{definePaymentMethod(purchase)}</td>
          <td>{format(new Date(purchase.date), 'dd/MM/yyyy')}</td>
          <td>
            <Button icon="file-pdf" title="Gerar PDF" onClick={e => generatePDF()}></Button>
            <Button icon="shopping-bag" title="Listar Compras"></Button>
            <Button icon="edit" title="Editar Pedido"></Button>
            <Button icon="trash" title="Deletar pedido"></Button>
          </td>
        </tr>
      ))
    )
  }

  return (
    <main className="orders">
      <h1>Compras Realizadas</h1>
      <div className="listaCompras">
        <div className="filter">
          <input type="text" className="filter-input" onChange={handleFilter} value={filterText} />
          <Button bg="green" icon="filter">Filtrar</Button>
        </div>

        <table>
          <thead>
            <tr>
              <th>ID</th>
              <th>Nome</th>
              <th>Valor Total</th>
              <th>Status</th>
              <th>Método de Pagamento</th>
              <th>Data</th>
              <th></th>
            </tr>
          </thead>

          <tbody>
            {renderRows()}
          </tbody>
        </table>
      </div>
    </main>
  )
}

export default Order