export const getBookingColor = (statusId) => {
    switch (statusId) {
        case 1:
            return '#FF7043';
            break;
        case 2:
            return '#26A69A';
            break;
        case 3:
            return '#EF5350';
            break;
        case 4:
            return '#5C6BC0';
            break;
    }
}