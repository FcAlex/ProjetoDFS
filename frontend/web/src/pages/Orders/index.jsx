
import Input from '../../components/Input'
import Button from '../../components/Button'

import api from '../../services/api'
import useAuth from '../../hooks/useAuth'
import { useEffect, useState } from 'react'

const Order = props => {

  const [purchases, setPurchases] = useState([]) 
  const { getData } = useAuth()
  const { id } = getData()

  useEffect(() => {
    (async () => {
      try {
        const response = await api.get("/purchase", { params: id})
        console.log(response)
        setPurchases(response.data)
      } catch (error) {
        console.log(error.message)
      }
    })()
  }, [id])

  function renderRows() {
    return (
      purchases.map(purchase => (
        <tr key={purchase.id}>
          <td>{purchase.id}</td>
          <td>{purchase.value}</td>
          <td>{purchase.date}</td>
          <td></td>
        </tr>
      ))
    )
  }

  return (
    <main>
      <h1>Compras Realizadas</h1>
      <div className="listaCompras">
        <div style={{ display: 'flex', alignItems: "center" }}>  {/* TODO */}
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