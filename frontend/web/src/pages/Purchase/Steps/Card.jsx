
const Card = ({title, children, className}) => {
  return (
    <section className={`${className} card`}>
      <h2>{title}</h2>
      <section className="card-content">
        {children}
      </section>
    </section>
  )
}

export default Card