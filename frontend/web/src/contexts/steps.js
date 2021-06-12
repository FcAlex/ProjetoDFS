import { createContext, useState } from "react";

export const StepContext = createContext({})

const StepProvider = props => {

  const [disableNext, setDisableNext] = useState(true)
  const [selectedCompany, setSelectedCompany] = useState(null)

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
      updateSelectedCompany
    }}>
      {props.children}
    </StepContext.Provider>
  )
}

export default StepProvider