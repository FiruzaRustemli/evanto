const changeFontSize = (width, length) => {
    if (width > 1030) {
        if (length <= 20) {
            return '70pt'
        }

        return (70 - ((length - 20) + 3)) + 'pt'
    } else if (width > 500 && width < 1030) {
        //tablet
        if (length <= 20) {
            return '50pt'
        }

        return (50 - ((length - 20) + 3)) + 'pt'
    } else if (width < 500) {
        // phone
        if (length <= 20) {
            return '30pt'
        }

        return (30 - ((length - 20) + 3)) + 'pt'
    }
}

export default changeFontSize