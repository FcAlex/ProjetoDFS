
import Card from './Card'
import Input from '../../../components/Input'
import { useContext, useEffect, useReducer } from 'react'
import { StepContext } from '../../../contexts/steps'

const Address = ({ title }) => {

  const initialState = {
    rua: '',
    numero: '',
    complemento: '',
    bairro: '',
    cep: '',
    cidade: '',
    estado: 'CE'
  }

  function reducer(state, action) {
    return { ...state, [action.type]: action.value.replaceAll('_', '') }
  }

  const [address, dispatch] = useReducer(reducer, initialState)
  const { updateAddress } = useContext(StepContext)

  function handleInput(e) {
    dispatch({ type: e.target.name, value: e.target.value })
  }

  useEffect(() => {
    updateAddress(address)
  }, [address, updateAddress])

  return (
    <Card title={title} className="address">
      <div className="rua-nr">
        <Input type="text" placeholder="Rua" value={address.rua} name="rua"
          onChange={handleInput}
        />
        <Input type="number" placeholder="Nr." value={address.numero} name="numero"
          onChange={handleInput}
        />
      </div>
      <div>
        <Input type="text" placeholder="Complemento" value={address.complemento} name="complemento"
        onChange={handleInput}
        />
      </div>
      <div>
        <Input type="text" placeholder="Bairro" value={address.bairro} name="bairro"
          onChange={handleInput}
        />
        <Input type="text" placeholder="CEP" value={address.cep} name="cep"
        onChange={handleInput} mask="99.999-999"
        />
      </div>
      <div className="cidade-estado"> 
        <Input type="text" placeholder="Cidade" value={address.cidade} name="cidade"
        onChange={handleInput}
        />
        <SelectState value={address.estado} name="estado" onChange={handleInput}/>
      </div>
    </Card>
  )
}

const SelectState = ({value, name, onChange}) => {
  return (
    <select name={name} value={value} onChange={onChange}>
      <option value="AC">Acre</option>
      <option value="AL">Alagoas</option>
      <option value="AP">Amapá</option>
      <option value="AM">Amazonas</option>
      <option value="BA">Bahia</option>
      <option value="CE" selected>Ceará</option>
      <option value="DF">Distrito Federal</option>
      <option value="ES">Espírito Santo</option>
      <option value="GO">Goiás</option>
      <option value="MA">Maranhão</option>
      <option value="MT">Mato Grosso</option>
      <option value="MS">Mato Grosso do Sul</option>
      <option value="MG">Minas Gerais</option>
      <option value="PA">Pará</option>
      <option value="PB">Paraíba</option>
      <option value="PR">Paraná</option>
      <option value="PE">Pernambuco</option>
      <option value="PI">Piauí</option>
      <option value="RJ">Rio de Janeiro</option>
      <option value="RN">Rio Grande do Norte</option>
      <option value="RS">Rio Grande do Sul</option>
      <option value="RO">Rondônia</option>
      <option value="RR">Roraima</option>
      <option value="SC">Santa Catarina</option>
      <option value="SP">São Paulo</option>
      <option value="SE">Sergipe</option>
      <option value="TO">Tocantins</option>
    </select>
  )
}

export default Address