
import Input from '../../components/Input'
import Button from '../../components/Button'

import api from '../../services/api'
import useAuth from '../../hooks/useAuth'
import { useEffect } from 'react'

const Order = props => {

  const { getData } = useAuth()
  const { id } = getData()

  useEffect(() => {
    (async () => {
      try {
        const response = await api.get("/purchase")
        
        console.log(response)
      } catch (error) {
        console.log(error.message)
      }
    })()
  }, [id])

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

          </tbody>
        </table>
      </div>
    </main>
  )
}

export default Order