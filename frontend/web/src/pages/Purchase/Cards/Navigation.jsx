
const Navigation = props => {
  return (
    <nav className="navegation">
      <button onClick={props.prev}>Previous</button>
      <button onClick={props.next}>Next</button>
    </nav>
  )
}

export default Navigation