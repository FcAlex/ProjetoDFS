import Card from './Card'
import api from '../../../services/api'
import { useCallback, useContext, useEffect, useState } from 'react'
import { StepContext } from '../../../contexts/steps'
import { checkImageURL } from '../../../helpers'

const Product = ({ title, ...props }) => {

  const [products, setProducts] = useState([])
  const {
    clearSelectedProduct,
    selectedProducts,
    addSelectedProduct,
    removeSelectedProduct,
    selectedCompany,
    handleNextStep } = useContext(StepContext)

  const getProducts = useCallback(async () => {
    try {
      const response = await api.get(`/product/company/${selectedCompany.id}`)
      setProducts(response.data)
    } catch (error) {
      console.log(error)
    }
  }, [selectedCompany.id])

  useEffect(() => {
    getProducts()
    handleNextStep(true)
    clearSelectedProduct()
  }, [handleNextStep, clearSelectedProduct, getProducts])

  // todo: use o hook useCallback para utilizar clearSelectedProduct() e limpar a lista de produtos
  // ao iniciar a lista, de forma que no contexto não haja produtos anteriores a atual seleção

  function select(index) {
    const item = document.querySelectorAll('.products-items')[index]
    const checkbox = document.querySelectorAll('.checkbox-company')[index]
    if (item.classList.contains('selected')) item.classList.remove('selected')
    else item.classList.add('selected')
    checkbox.checked = !checkbox.checked


    if (checkbox.checked) {
      addSelectedProduct(products[index])
      handleNextStep(false)
    } else {
      removeSelectedProduct(products[index])
      if (selectedProducts.length === 0) handleNextStep(true)
    }
  }

  return (
    <Card title={title} navigation={props}>
      <ul className="products listItem">
        {products.map((product, index) => (
          <li
            key={product.id}
            onClick={() => select(index)}
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