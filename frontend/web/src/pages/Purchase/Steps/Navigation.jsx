import { useContext } from 'react'
import Button from '../../../components/Button'
import { StepContext } from '../../../contexts/steps'

const Navigation = (props) => {

  const { disableNext } = useContext(StepContext)

  return (
    <nav className="navegation">
      {!disableNext
        ? props.current !== props.size
          ? <Button onClick={props.next} icon="arrow-right" bg="blue">Próximo</Button>
          : <Button onClick={props.next} icon="check" bg="green">Finalizar</Button>
        : <Button style={{ cursor: 'auto' }} icon="arrow-right" bg="gray">Próximo</Button>}

      {props.current !== 1
        ? <Button onClick={props.prev} icon="arrow-left" bg="blue">Anterior</Button>
        : <Button icon="arrow-left" bg="gray">Anterior</Button>}
    </nav>
  )
}

export default Navigation