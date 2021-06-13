import Card from './Card'
import api from '../../../services/api'
import { useContext, useEffect, useState } from 'react'
import { StepContext } from '../../../contexts/steps'
import { checkImageURL } from '../../../helpers'

const Product = ({ title, ...props }) => {

  const [products, setProducts] = useState([])
  const { selectedCompany } = useContext(StepContext)

  async function getProducts() {
    try {
      const response = await api.get(`/product/company/${selectedCompany.id}`)

      setProducts(response.data)
    } catch (error) {
      console.log(error)
    }
  }

  useEffect(() => {
    getProducts()
  }, [])

  return (
    <Card title={title} navigation={props}>
      <ul className="products listItem">
        {products.map((product, index) => (
          <li
            key={product.id}
            // onClick={() => select(index)} 
            className="products-items">
            <input type="checkbox" className="checkbox-company" name={index} />
            <img src={checkImageURL(product)} alt="Imagem da Loja" className="item-img" />
              <h3 className="value">R$ {product.value.toFixed(2)}</h3>
              <p>{product.name}</p>
              <p>{product.description}, {product.observation}</p>
          </li>
        ))}
      </ul>
    </Card>
  )
}

export default Product