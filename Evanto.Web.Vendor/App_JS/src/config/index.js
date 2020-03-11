import bookingStatus from './bookingStatus'
import urlConfig from './urlConfig'
import requestColor, { getClassName as requestClass } from './requestColor'
import bookingColorClass from './bookingColorClass'
export const languageKey = {
    key: 'lang',
    azerbaijani: 'az',
    english: 'en',
    russian: 'ru'
}

export const oauth = {
    client_secret: 'J02oowSeCx0LdE6yk2iCA2PNL5vs2MyG7BOYPPoqoaY=',
    client_id: 'J02oowSeCx0LdE6yk2iCA2PNL5vs2MyG7BOYPPoqoaY=',
    grant_type: 'password',
    localStorageTokenKey: 'lgon24x'
}
export const fileExtension = /(?:\.([^.]+))?$/

const calendarStyle = {
    month: {
        name: 'month',
        subtract: 'months',
        add: 'month'
    },
    week: {
        name: 'agendaWeek',
        subtract: 'weeks',
        add: 'week'
    },
    day: {
        name: 'basicDay',
        subtract: 'days',
        add: 'day'
    }
}

export { urlConfig, bookingStatus, requestColor, calendarStyle, requestClass, bookingColorClass }