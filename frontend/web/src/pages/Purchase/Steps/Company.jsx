import Card from './Card'

import api from '../../../services/api'
import { companies as _companies } from '../../../services/api_test'

import { useContext, useEffect, useState } from 'react'
import { logout } from '../../../services/auth'

import { StepContext } from '../../../contexts/steps'
import { checkImageURL } from '../../../helpers'

const Company = ({ title, ...props }) => {

  const [companies, setCompanies] = useState([])
  const [selectedItemCompany, setSelectedItemCompany] = useState(null)
  const { handleNextStep, updateSelectedCompany } = useContext(StepContext)
 
  async function getCompanies() {
    try {
      const response = await api.get("/company")
      // const response = await _companies("/company")
      setCompanies(response.data)
    } catch (error) {
      if (error?.data?.status === 401) logout();
    }
  }

  useEffect(() => {
    getCompanies()
  }, [])

  useEffect(() => {
    if(!selectedItemCompany?.checkbox.checked) {
      setSelectedItemCompany(null)
      updateSelectedCompany(null)
      handleNextStep(true)
    } else {
      handleNextStep(false)
    }
  }, [selectedItemCompany])

  function select(index) {
    const item = document.querySelectorAll('.companies-items')[index]
    const checkbox = document.querySelectorAll('.checkbox-company')[index]
    checkbox.checked = !checkbox.checked

    if(item.classList.contains('selected')) item.classList.remove('selected')
    else item.classList.add('selected')

    if(selectedItemCompany && selectedItemCompany?.checkbox.name !== checkbox.name) {
      selectedItemCompany.checkbox.checked = false
      selectedItemCompany.item.classList.remove('selected')
    }

    setSelectedItemCompany({item, checkbox})
    updateSelectedCompany(companies[index])
  }

  return (
    <Card title={title} >
      <ul className="companies listItem">
        { companies.map((company, index) => (
          <li
            key={company.id} 
            onClick={() => select(index)} 
            className="companies-items">

            <input type="checkbox" className="checkbox-company" name={index}/>
            <img src={checkImageURL(company)} alt="Imagem da Loja" className="item-img" />
            <h3>{company.companyName}</h3>

          </li>
        )) }
      </ul>
    </Card>
  )
}

export default Company