import React, { Component } from 'react'
import { Field, reduxForm, destroy } from 'redux-form'
import TextField from 'material-ui/TextField'
import { RadioButton, RadioButtonGroup } from 'material-ui/RadioButton'
import Checkbox from 'material-ui/Checkbox'
import Dialog from 'material-ui/Dialog'
import FlatButton from 'material-ui/FlatButton';
import { SelectField, TimePicker } from 'redux-form-material-ui'
import MenuItem from 'material-ui/MenuItem'
import EditServiceForm from '../components/editServiceForm'
import { connect } from 'react-redux'
import { getVendorServiceById, updateVendorService, deleteVendorServiceImage } from '../modules/services'
import { hashHistory } from 'react-router'
import { getTranslate } from 'react-localize-redux'

class EditService extends Component {
    constructor(props) {
        super(props)
        this.state = {
            imageModal: false,
            images: [],
            imageViewerIsOpen: false,
            imageViewerActiveIndex: 0
        }
    }

    closeImageViewer= () => {
        this.setState({
            imageViewerIsOpen: false
        })
    }

    openImageViewer= (src) => {
        this.setState({
            imageViewerIsOpen: true,
            imageViewerActiveIndex: src
        })
    }

    componentWillMount() {
        const { getVendorServiceById } = this.props
        getVendorServiceById({ id: this.props.params.id })
    }

    hideImageModal = () => {
        this.setState({
            imageModal: false,
            images: []
        })
    }

    openImageModal = (images) => {
        this.setState({
            imageModal: true,
            images
        })
    }
    removeSelectedImage = (key, isAll) => {
        let newImages = this.state.images.slice()
        let filtered = newImages.filter(s => {
            return s.imageKey !== key
        })
        this.setState({
            images: filtered,
            imageModal: filtered.length !== 0
        })
    }

    backToServices = () => {
        hashHistory.replace('/services')
    }

    updateService = (args) => {
        const { updateVendorService, destroy } = this.props
        updateVendorService(args)
        // destroy('editServiceForm')
    }

    render() {
        const { vendorService, translate } = this.props
        if (vendorService) {
            return (
                <EditServiceForm
                    {...translate([
                        '##description',
                        '##priceMin',
                        '##priceMax',
                        '##name',
                        '##contact',
                        '##address',
                        '##required',
                        '##update',
                        '##cancel',
                        '##serviceImagesUpdateCardTitle',
                        '##serviceInformationUpdateCardTitle',
                        "##contactInfo",
                        "##addressText",
                        "##coordinateX",
                        "##coordinateY"
                    ]) }
                    initialValues={{
                        PriceMin: vendorService.priceMin,
                        PriceMax: vendorService.priceMax,
                        Name: vendorService.name,
                        VendorServiceId: vendorService.id,
                        Description: vendorService.description,
                        AddressText: vendorService.addressText,
                        ContactInfo: vendorService.contactInfo,
                        CoordinateX: vendorService.coordinateX,
                        CoordinateY: vendorService.coordinateY
                    }}
                    removeSelectedImage={this.removeSelectedImage}
                    imageModal={this.state.imageModal}
                    hideImageModal={this.hideImageModal}
                    openImageModal={this.openImageModal}
                    modalImages={this.state.images}
                    cancel={this.backToServices}
                    onSubmit={this.updateService}
                    images={vendorService.images}
                    imageViewerIsOpen={this.state.imageViewerIsOpen}
                    closeImageViewer={this.closeImageViewer}
                    openImageViewer={this.openImageViewer}
                    width = {this.props.width}
                    deleteVendorServiceImage={this.props.deleteVendorServiceImage}
                    imageViewerActiveIndex={this.state.imageViewerActiveIndex} />
            )
        } else {
            return <div></div>
        }
    }
}

const mapStateToProps = (state) => ({
    vendorService: state.services.vendorService,
    translate: getTranslate(state.locale),
    width: state.events.width
})

const mapDispatchToProps = {
    getVendorServiceById,
    updateVendorService,
    destroy,
    deleteVendorServiceImage
}

export default connect(mapStateToProps, mapDispatchToProps)(EditService)
