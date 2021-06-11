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
          { id: 104, name: 'Abril', status: 3, paymentMethod: 3, value: 189.5, date: Date.now() },
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
          { id: 102, tradingName: 'Loja A', legalName: 'Soluções LTDA' },
          { id: 103, tradingName: 'Loja B', legalName: 'Soluções LTDA' },
          { id: 104, tradingName: 'Loja C', legalName: 'Soluções LTDA' },
          { id: 105, tradingName: 'Loja D', legalName: 'Soluções LTDA' },
        ]
      })
    }, 1000)
  })
}