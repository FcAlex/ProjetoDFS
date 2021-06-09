import { format } from 'date-fns'
import Input from '../../components/Input'
import Button from '../../components/Button'

import api from '../../services/api'
import useAuth from '../../hooks/useAuth'
import { useEffect, useState } from 'react'

import './styles.css'

const Order = props => {

  const [purchases, setPurchases] = useState([]) 
  const { getData } = useAuth()
  const { id } = getData()

  useEffect(() => {
    (async () => {
      try {
        const response = await api.get("/purchase", { params: id})

        setPurchases(response.data)
      } catch (error) {
        console.log(error.response)
      }
    })()
  }, [id])

  function renderRows() {
    return (
      purchases.map(purchase => (
        <tr key={purchase.id}>
          <td>{purchase.id}</td>
          <td>R${purchase.value.toFixed(2)}</td>
          <td>{format(new Date(purchase.date), 'dd/MM/yyyy')}</td>
          <td>
            <Button icon="file-pdf" title="Gerar PDF"></Button>
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
          <Input placeholder="Busque por ID" />
          <Button bg="green" icon="filter" />
        </div>

        <table>
          <thead>
            <tr>
              <th>ID</th>
              <th>Valor Total</th>
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