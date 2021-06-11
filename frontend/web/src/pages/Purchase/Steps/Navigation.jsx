import Button from '../../../components/Button'

const Navigation = props => {
  return (
    <nav className="navegation">
      <Button onClick={props.prev} icon="arrow-left" bg="blue">Anterior</Button>
      <Button onClick={props.next} icon="arrow-right" bg="blue">Próximo</Button>
    </nav>
  )
}

export default Navigation