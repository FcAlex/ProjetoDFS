import { createContext, useState } from "react";

export const StepContext = createContext({})

const StepProvider = props => {

  const [disableNext, setDisableNext] = useState(true)
  const [selectedCompany, setSelectedCompany] = useState(null)
  const [selectedProducts, setSelectedProducts] = useState([])

  function addSelectedProduct(product) {
    if(selectedProducts.includes(product)) return

    selectedProducts.push(product)
    setSelectedProducts([...selectedProducts])
  }

  function removeSelectedProduct(product) {
    const index = selectedProducts.indexOf(product)
    if(index < 0) return
    setSelectedProducts([...selectedProducts.splice(index, 1)])
  }

  function handleNextStep(value) {
    setDisableNext(value)
  }

  function updateSelectedCompany(company) {
    setSelectedCompany(company)
  }

  return (
    <StepContext.Provider value={{
      disableNext,
      handleNextStep,
      selectedCompany, 
      updateSelectedCompany,
      selectedProducts,
      addSelectedProduct,
      removeSelectedProduct
    }}>
      {props.children}
    </StepContext.Provider>
  )
}

export default StepProvider