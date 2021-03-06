import { format } from 'date-fns'
import Button from '../../components/Button'

import api from '../../services/api'
import useAuth from '../../hooks/useAuth'
import { useCallback, useEffect, useReducer, useState } from 'react'
import { logout } from '../../services/auth'
import { toastError, toastSuccess } from '../../helpers'
import { useToasts } from 'react-toast-notifications'

import Input from '../../components/Input'

import './styles.css'
import Modal from '../../components/Modal'

const initialState = {
  contentModal: '',
  footerModal: '',
  titleModal: ''
}

const Order = props => {

  const [filterText, setFilterText] = useState('')
  const [purchases, setPurchases] = useState([])
  const [filterPurchase, setFilterPurchase] = useState([])
  const [showModal, setShowModal] = useState(false)
  const [modal, dispatch] = useReducer(reducer, initialState);
  const { getData } = useAuth()
  const { id } = getData()
  const { addToast } = useToasts()

  function reducer(state, action) {
    switch (action.type) {
      case 'content':
        return { ...state, contentModal: action.value }
      case 'footer':
        return { ...state, footerModal: action.value }
      case 'title':
        return { ...state, titleModal: action.value }
      default:
        return state
    }
  }

  const getPurchases = useCallback(async () => {
    try {
      const response = await api.get(`/purchase/user/${id}`)
      // const response = await getPurchases()
      setPurchases(response.data)
      setFilterPurchase(response.data)
    } catch (error) {
      if (error.response?.status === 401) logout()
    }
  }, [id])

  useEffect(() => {
    getPurchases()
  }, [getPurchases])

  useEffect(() => {
    if (filterText !== '') {
      const results = purchases.filter(purchase =>
        purchase.name.toLowerCase().includes(filterText.toLowerCase())
      )

      setFilterPurchase(results)
    } else {
      setFilterPurchase(purchases)
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
        return 'Cr??dito'
      case 2:
        return 'D??bito'
      case 3:
        return 'Em dinheiro'
      default:
        return 'Erro'
    }
  }

  async function deleteOrder(id) {
    try {
      await api.delete(`/purchase/${id}`)

      toastSuccess(addToast, "Pedido deletado com sucesso!")
      getPurchases()
    } catch (err) {
      toastError(addToast, "Algo deu errado!")
    }
  }

  function close(value) {
    setShowModal(!value)
  }

  async function buttonDetails(purchase) {

    try {
      const response = await api.get(`/product/purchase/${purchase.id}`)
      const products = response.data ?? []

      dispatch({
        type: 'content', value: (
          <>
            <ul>
              {products.map(product => (
                <li key={product.id}>
                  <table>
                    <thead>
                      <tr>
                        <th>ID</th>
                        <th>Produto</th>
                        <th>Valor</th>
                        <th>Descri????o</th>
                      </tr>
                    </thead>
                    <tbody>
                      {products.map(product => (
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
          </>
        )
      })

      dispatch({
        type: 'footer', value: (
          <>
            <Button bg="gray" onClick={_ => close(true)}>Voltar</Button>
          </>
        )
      })

      dispatch({
        type: 'title', value: (
          <>
            <i className="fas fa-exclamation-circle"></i> Lista de Produtos
          </>
        )
      })

      close(false)
    } catch (e) {
      console.log(e)
    }
  }

  function buttonDelete(purchase) {
    dispatch({
      type: 'content', value: (
        <>
          <p>Deseja realmente deletar esse pedido?</p>
          <p>Essa a????o ?? irrevers??vel</p>

          <ul>
            <li><strong>Nome:</strong> {purchase.name}</li>
            <li><strong>Valor Total:</strong> {purchase.value}</li>
            <li><strong>Data:</strong> {format(new Date(purchase.date), 'dd/MM/yyyy')}</li>
          </ul>
        </>
      )
    })

    dispatch({
      type: 'footer', value: (
        <>
          <Button bg="red" onClick={_ => {
            deleteOrder(purchase.id)
            close(true)
          }}>
            Deletar
          </Button>
          <Button bg="gray" onClick={_ => close(true)}>Cancelar</Button>
        </>
      )
    })

    dispatch({
      type: 'title', value: (
        <>
          <i className="fas fa-exclamation-circle"></i> Aviso
        </>
      )
    })

    close(false)
  }

  function renderRows() {
    return (
      filterPurchase.map(purchase => (
        <tr key={purchase.id}>
          <td>{purchase.id}</td>
          <td>{purchase.name}</td>
          <td>R${purchase.value.toFixed(2)}</td>
          <td>{defineStatus(purchase)}</td>
          <td>{definePaymentMethod(purchase)}</td>
          <td>{format(new Date(purchase.date), 'dd/MM/yyyy')}</td>
          <td>
            <Button icon="shopping-bag" title="Listar Compras" onClick={e => buttonDetails(purchase)}>
            </Button>
            <Button icon="trash" title="Deletar pedido" onClick={_ => buttonDelete(purchase)}></Button>
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
          <Input
            className="filter-input"
            type="text"
            onChange={handleFilter}
            value={filterText}
            placeholder="Realize sua busca"
            icon="filter"
          />
        </div>

        <table>
          <thead>
            <tr>
              <th>ID</th>
              <th>Nome</th>
              <th>Valor Total</th>
              <th>Status</th>
              <th>M??todo de Pagamento</th>
              <th>Data</th>
              <th></th>
            </tr>
          </thead>

          <tbody>
            {renderRows()}
          </tbody>
        </table>
      </div>
      <Modal show={showModal} close={close} title={modal.titleModal} footer={modal.footerModal}>
        {modal.contentModal}
      </Modal>
    </main>
  )
}

export default Order