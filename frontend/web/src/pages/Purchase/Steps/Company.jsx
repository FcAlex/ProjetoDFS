import Card from './Card'

import api from '../../../services/api'
import { companies as _companies } from '../../../services/api_test'

import { useContext, useEffect, useState } from 'react'
import { logout } from '../../../services/auth'

import bgDefault from '../../../assets/bgDefault.svg'
import { StepContext } from '../../../contexts/steps'

const Company = ({ title, ...props }) => {

  const [companies, setCompanies] = useState([])
  const { handleNextStep, selectedCompany, updateSelectedCompany } = useContext(StepContext)
 
  async function getCompanies() {
    try {
      const response = await api.get("/company")
      // const response = await _companies("/company")
      console.log(response.data)
      
      setCompanies(response.data)
    } catch (error) {
      if (error?.data?.status === 401) logout();
    }
  }

  useEffect(() => {
    getCompanies()
  }, [])

  useEffect(() => {
    if(!selectedCompany?.checkbox.checked) {
      updateSelectedCompany(null)
      handleNextStep(true)
    } else {
      handleNextStep(false)
    }
  }, [selectedCompany, handleNextStep, updateSelectedCompany])

  function select(index) {
    const item = document.querySelectorAll('.companies-items')[index]
    const checkbox = document.querySelectorAll('.checkbox-company')[index]
    checkbox.checked = !checkbox.checked

    if(item.classList.contains('selected')) item.classList.remove('selected')
    else item.classList.add('selected')

    if(selectedCompany && selectedCompany?.checkbox.name !== checkbox.name) {
      selectedCompany.checkbox.checked = false
      selectedCompany.item.classList.remove('selected')
    }

    updateSelectedCompany({item, checkbox})
  }

  function checkImageURL(company) {
    if(!company?.imageURL || company.imageURL === '') return bgDefault
    else return company.imageURL
  }

  return (
    <Card title={title} >
      <ul className="companies">
        { companies.map((company, index) => (
          <li
            key={company.id} 
            onClick={() => select(index)} 
            className="companies-items">

            <input type="checkbox" className="checkbox-company" name={index}/>
            <img src={checkImageURL(company)} alt="Imagem da Loja" />
            <h3>{company.companyName}</h3>

          </li>
        )) }
      </ul>
    </Card>
  )
}

export default Company