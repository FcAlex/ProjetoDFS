
const MenuItem = ({ icon, path, label }) => {
  return (
    <li className="item">
      <a href={path}>
        <i className={`input-group-text fas fa-${icon}`}></i> 
        { label }
      </a>
    </li>
  )
}

export default MenuItem