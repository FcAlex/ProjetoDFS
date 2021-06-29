import { useContext } from 'react'
import Button from '../../../components/Button'
import { StepContext } from '../../../contexts/steps'
import { toastError, toastSuccess } from '../../../helpers'
import api from '../../../services/api'

import { useToasts } from 'react-toast-notifications'

const Navigation = (props) => {

  const { disableNext, sendPurchase } = useContext(StepContext)
  const { addToast } = useToasts()

  async function postPurchase() {
    try {
      await sendPurchase()
      toastSuccess(addToast, "Compra cadastrada com sucesso!")
    } catch (e) {
      toastError(addToast, "Ocorreu algo inesperado! ", e.response.status)
    }
  }

  return (
    <nav className="navegation">
      {!disableNext
        ? props.current !== props.size
          ? <Button onClick={props.next} icon="arrow-right" bg="blue">Próximo</Button>
          : <Button onClick={postPurchase} icon="check" bg="green">Finalizar</Button>
        : <Button style={{ cursor: 'auto' }} icon="arrow-right" bg="gray">Próximo</Button>}

      {props.current !== 1
        ? <Button onClick={props.prev} icon="arrow-left" bg="blue">Anterior</Button>
        : <Button icon="arrow-left" bg="gray">Anterior</Button>}
    </nav>
  )
}

export default Navigation