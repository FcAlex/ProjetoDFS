
import Navigation from './Navigation'

const Card = ({title, children, navigation}) => {
  console.log(navigation)
  return (
    <section className="card">
      <h2>{title}</h2>
      {children}
      <Navigation {...navigation}/>
    </section>
  )
}

export default Card