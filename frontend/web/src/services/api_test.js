export const signIn = () => {

  return new Promise(resolve => {

    setTimeout(() => {
      resolve({
        result: {
          token: 'jk12h3j21h3jk212h3jk12h3jkh12j3kh12k123hh21g3f12fdfasfas3',
          user: {
            name: 'Alex Sousa',
            email: 'alex@example.com',
          }
        }
      });
    }, 1000);
  });
}

export const purchases = () => {
  return new Promise(resolve => {
    setTimeout(() => {
      resolve({
        data: [
          { id: 101, name: 'Janeiro', status: 2, paymentMethod: 1, value: 150, date: Date.now() },
          { id: 102, name: 'Fevereiro', status: 1, paymentMethod: 2, value: 200, date: Date.now() },
          { id: 103, name: 'Março', status: 4, paymentMethod: 3, value: 315, date: Date.now() },
          { id: 104, name: 'Abril', status: 3, paymentMethod: 3, value: 75.5, date: Date.now() },
        ]
      })
    }, 1000)
  })
}

export const companies = () => {
  return new Promise(resolve => {
    setTimeout(() => {
      resolve({
        data: [
          { id: 102, companyName: 'Loja A' },
          { id: 103, companyName: 'Loja B' },
          { id: 104, companyName: 'Loja C' },
          { id: 105, companyName: 'Loja D' },
          { id: 106, companyName: 'Loja E' },
          { id: 107, companyName: 'Loja F' },
        ]
      })
    }, 1000)
  })
}

export const products = () => {
  return new Promise(resolve => {
    setTimeout(() => {
      resolve({
        data: [
          { id: 109, value: 5.1, name: 'Item A', description: 'lorem ipsum', observation: 'foo' },
          { id: 110, value: 7.8, name: 'Item B', description: 'lorem ipsum', observation: 'foo' },
          { id: 111, value: 5.35, name: 'Item C', description: 'lorem ipsum', observation: 'foo' },
          { id: 112, value: 12.0, name: 'Item D', description: 'lorem ipsum', observation: 'foo' },
          { id: 113, value: 7.8, name: 'Item E', description: 'lorem ipsum', observation: 'foo' },
          { id: 114, value: 51.15, name: 'Item F', description: 'lorem ipsum', observation: 'foo' },
        ]
      })
    }, 1000)
  })
}