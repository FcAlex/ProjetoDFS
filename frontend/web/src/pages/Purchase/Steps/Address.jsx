
import Card from './Card'
import Input from '../../../components/Input'

const Address = ({ title }) => {
  return (
    <Card title={title} className="address">
      <div className="rua-nr">
        <Input type="text" placeholder="Rua" //value={state.number}
          // onChange={e => dispatch({ type: 'nome', value: e.target.value })}
          required
        />
        <Input type="number" placeholder="Nr." //value={state.number}
          // onChange={e => dispatch({ type: 'cpf', value: e.target.value })}
          mask="999.999.999-99" required
        />
      </div>
      <div>
        <Input type="text" placeholder="Complemento"
        // onChange={e => dispatch({ type: 'email', value: e.target.value })}
        />
      </div>
      <div>
        <Input type="tel" placeholder="Bairro" //value={state.number}
          // onChange={e => dispatch({ type: 'telefone', value: e.target.value })}
          mask="(99) 9 9999-9999" required
        />
        <Input type="email" placeholder="CEP" //name="email"
        // onChange={e => dispatch({ type: 'email', value: e.target.value })}
        />
      </div>
      <div className="cidade-estado">
        <Input type="text" placeholder="Cidade" //name="email"
        // onChange={e => dispatch({ type: 'email', value: e.target.value })}
        />
        <SelectState />
      </div>
    </Card>
  )
}

const SelectState = () => {
  return (
    <select name="estados-brasil">
      <option value="AC">Acre</option>
      <option value="AL">Alagoas</option>
      <option value="AP">Amapá</option>
      <option value="AM">Amazonas</option>
      <option value="BA">Bahia</option>
      <option value="CE">Ceará</option>
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