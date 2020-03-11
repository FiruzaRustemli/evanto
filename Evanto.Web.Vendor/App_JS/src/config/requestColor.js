const getColor = (type) => {
  switch (type) {
    case 1:
      return '#FF7043' //amber
    case 2:
      return '#26A69A' //green
    case 3:
      return '#EF5350' //red
    case 4:
      return '#5C6BC0' //blue
  }
}

export const getClassName = (type) => {
  switch (type) {
    case 1:
      return 'waiting_request' //amber
    case 2:
      return 'approved_request' //green
    case 3:
      return 'rejected_request' //red
    case 4:
      return 'own_request' //blue
  }
}

export default getColor