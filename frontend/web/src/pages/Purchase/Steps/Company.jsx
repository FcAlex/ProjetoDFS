import Card from './Card'

import api from '../../../services/api'
import { companies as _companies } from '../../../services/api_test'

import { useEffect, useState } from 'react'
import { logout } from '../../../services/auth'

import bgDefault from '../../../assets/bgDefault.svg'

const Company = ({ title, ...props }) => {

  const [companies, setCompanies] = useState([])
  const [selectedCompany, setSelectedCompany] = useState(null)

  async function getCompanies() {
    try {
      // const response = await api.get("/company")
      const response = await _companies("/company")

      setCompanies(response.data)
    } catch (error) {
      if (error?.data.status === 401) logout();
    }
  }

  useEffect(() => {
    getCompanies()
  }, [])

  useEffect(() => {
    if(!selectedCompany?.checkbox.checked) setSelectedCompany(null)
    console.log(selectedCompany)
  }, [selectedCompany])

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

    setSelectedCompany({item, checkbox})
  }

  return (
    <Card title={title} navigation={props}>
      <ul className="companies">
        { companies.map((company, index) => (
          <li key={company.id} onClick={() => select(index)} className="companies-items">
            <input type="checkbox" className="checkbox-company" name={index}/>
            <img src={bgDefault} alt="Imagem da Loja" />
            <h3>{company.tradingName}</h3>
          </li>
        )) }
      </ul>
    </Card>
  )
}

export default Company