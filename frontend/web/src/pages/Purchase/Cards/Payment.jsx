import Card from './Card'

const Payment =  ({title, ...props})  => {
  return (
    <Card title={title} navigation={props}>
      Lorem ipsum dolor sit amet consectetur adipisicing elit. 
      Cupiditate inventore vitae laudantium dolorem tempore deserunt suscipit ullam facilis sed. 
      Expedita, minus! Dicta, repellendus eius magnam eligendi iure enim quod quam.
    </Card>
  )
}

export default Payment