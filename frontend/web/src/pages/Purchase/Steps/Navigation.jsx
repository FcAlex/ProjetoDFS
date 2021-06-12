import Button from '../../../components/Button'

const Navigation = ({disable, ...props}) => {
  console.log(props.size, props.current)
  return (
    <nav className="navegation">
      {props.current !== 1 
        ? <Button onClick={props.prev} icon="arrow-left" bg="blue">Anterior</Button> 
        : <Button icon="arrow-left" bg="gray">Anterior</Button>}

      {!disable
        ? props.current !== props.size 
          ? <Button onClick={props.next} icon="arrow-right" bg="blue">Próximo</Button>
          : <Button onClick={props.next} icon="check" bg="green">Finalizar</Button>
        : <Button icon="arrow-right" bg="gray">Próximo</Button>}
    </nav>
  )
}

export default Navigation