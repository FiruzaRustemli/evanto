export const validate = values => {
    const errors = {}
    var emailPattern = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    if (!values.username) {
        errors.username = '##required'
    } else if (values.username.length > 30 || values.username.length < 3) {
        errors.username = '##incorrectEmailLength'
    } else if(!emailPattern.test(values.username)) {
        errors.username = '##incorrectEmailFormat'
    }

    if (!values.name) {
        errors.name = '##required'
    } else if (values.name.length > 30 || values.name.length < 3) {
        errors.name = '##incorrectCompanyNameLength'
    }

    if (!values.firstName) {
        errors.firstName = '##required'
    } else if (values.firstName.length > 30 || values.firstName.length < 3) {
        errors.firstName = '##incorrectFirstNameLength'
    }

    if (!values.lastName) {
        errors.lastName = '##required'
    } else if (values.lastName.length > 30 || values.lastName.length < 3) {
        errors.lastName = '##incorrectLastNameLength'
    }

    if (!values.phone) {
        errors.phone = '##required'
    } 

    if (!values.passwordString) {
        errors.passwordString = '##required'
    } else if (values.passwordString.length > 20 || values.passwordString.length < 5) {
        errors.passwordString = '##incorrectPassword'
    }

    return errors
}