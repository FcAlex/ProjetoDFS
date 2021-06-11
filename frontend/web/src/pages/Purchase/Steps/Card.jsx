
import Navigation from './Navigation'

const Card = ({title, children, navigation}) => {
  return (
    <section className="card">
      <h2>{title}</h2>
      <section className="card-content">
        {children}
      </section>
      <Navigation {...navigation}/>
    </section>
  )
}

export default Card