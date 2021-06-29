import { createContext, useCallback, useState } from "react";
import { toastError } from "../helpers";
import api from "../services/api";
import { getData } from "../services/auth";

export const StepContext = createContext({})

const StepProvider = props => {

  const TYPE = { BOLETO: 2, INCASH: 3, CREDIT: 1 }

  const [disableNext, setDisableNext] = useState(true)
  const [selectedCompany, setSelectedCompany] = useState(null)
  const [selectedProducts, setSelectedProducts] = useState([])
  const [boletoInfo, setBoletoInfo] = useState(null)
  const [creditInfo, setCreditInfo] = useState(null)
  const [typeOfPayment, setTypeOfPayment] = useState(TYPE.CREDIT)
  const [deliveryAddress, setDeliveryAddress] = useState(null)
  const [observation, setObservation] = useState('')
  const [name, setName] = useState('')

  function handleObservation(e) {
    setObservation(e.target.value)
  }

  function handleName(e) {
    setName(e.target.value)
  }

  function updateAddress(address) {
    setDeliveryAddress(address)
  }

  function handleTypeOfPayment(type) {
    if (type === TYPE.BOLETO || type === TYPE.INCASH || type === TYPE.CREDIT)
      setTypeOfPayment(type)
  }

  function updateBoletoInfo(boletoInfo) {
    setBoletoInfo(boletoInfo)
  }

  function updateCreditInfo(creditInfo) {
    setCreditInfo(creditInfo)
  }

  function addSelectedProduct(product) {
    if (selectedProducts.includes(product)) return

    selectedProducts.push(product)
    setSelectedProducts([...selectedProducts])
  }

  function removeSelectedProduct(product) {
    const index = selectedProducts.indexOf(product)
    if (index < 0) return
    setSelectedProducts([...selectedProducts.splice(index, 1)])
  }

  const clearSelectedProduct = useCallback(() => {
    setSelectedProducts(_ => [])
  }, [])

  const handleNextStep = useCallback((value) => {
    setDisableNext(value)
  }, [])

  function updateSelectedCompany(company) {
    setSelectedCompany(company)
  }

  async function sendPurchase() {
    const address = `
      ${deliveryAddress.rua}, 
      ${deliveryAddress.numero}, 
      ${deliveryAddress.complemento ? deliveryAddress.complemento + ', ' : ''}
      ${deliveryAddress.bairro},
      ${deliveryAddress.cidade},
      ${deliveryAddress.estado}`

    const purchase = {
      value: selectedProducts.map(prod => prod.value).reduce((acc, cur) => acc + cur, 0),
      date: new Date(Date.now()).toUTCString,
      name,
      paymentMethod: typeOfPayment,
      status: 1,
      observation,
      cep: deliveryAddress.cep,
      address,
      userId: getData().id,
      purchaseProducts: selectedProducts.map(prod => ({ ProductId: prod.id }))
    }

    api.post('/purchase', purchase)
  }

  return (
    <StepContext.Provider value={{
      disableNext,
      handleNextStep,
      selectedCompany,
      updateSelectedCompany,
      selectedProducts,
      addSelectedProduct,
      removeSelectedProduct,
      clearSelectedProduct,
      updateBoletoInfo,
      updateCreditInfo,
      boletoInfo,
      creditInfo,
      type: TYPE,
      typeOfPayment,
      handleTypeOfPayment,
      deliveryAddress,
      updateAddress,
      sendPurchase,
      handleObservation,
      handleName,
      observation,
      name
    }}>
      {props.children}
    </StepContext.Provider>
  )
}

export default StepProvider