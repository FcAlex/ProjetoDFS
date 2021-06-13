import bgDefault from '../assets/bgDefault.svg'

export function checkImageURL(obj) {
  if(!obj?.imageURL || obj.imageURL === '') return bgDefault
  else return obj.imageURL
}