import bgDefault from '../assets/bgDefault.svg'

export function checkImageURL(obj) {
  if (!obj?.imageURL || obj.imageURL === '') return bgDefault
  else return obj.imageURL
}

export function toastError(addToast, msg) {
  addToast(msg, {
    appearance: 'error',
    autoDismiss: true,
  })
}

export function toastSuccess(addToast, msg) {
  addToast(msg, {
    appearance: 'success',
    autoDismiss: true,
  })
}