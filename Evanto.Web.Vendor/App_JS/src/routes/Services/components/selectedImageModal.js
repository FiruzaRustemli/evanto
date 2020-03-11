import React, { Component } from 'react'
import DialogContainer from 'react-md/lib/Dialogs'
import Button from 'react-md/lib/Buttons/Button'
import { connect } from 'react-redux'
import { uploadVendorServiceImages } from '../modules/services'

class SelectedImageModal extends Component {

    upload = (args) => {
        const { uploadVendorServiceImages, vendorService, hideImageModal } = this.props
        let dto = {}
        Object.assign(dto, { images: args, vendorServiceId: vendorService.id })
        console.log('args', dto)
        uploadVendorServiceImages(dto)
        hideImageModal()
    }
    render() {  
        const { modalImages, hideImageModal, imageModal, width, removeSelectedImage, uploadVendorServiceImages, vendorService } = this.props
        const actions = [<Button flat onClick={hideImageModal} label='Ləğv edin' />]
        if(modalImages && modalImages.length > 0) {
            actions.unshift(<Button onClick={() => this.upload(modalImages)} flat label='Əlavə edin' />)
        }
        return (
            <DialogContainer
                id="speed-boost"
                visible={imageModal}
                className={`${width > 1090 ? 'dialog-request ' : ''}`}
                title='Aşağıdakı şəkillər yüklənsin?'
                onHide={() => hideImageModal()}
                aria-describedby="speed-boost-description"
                modal
                actions={actions}
            >
                <div className='md-grid'>
                    {modalImages && modalImages.map((item, key) => {
                        return (
                            <div key={key} className='image-removable md-cell md-cell--3'>
                                <img style={{ width: '100%', minHeight: '30px' }} src={`data:image/jpeg;charset=utf-8;base64, ${item.container}`} />
                                <i onClick={() => removeSelectedImage(item.imageKey, false)} className='material-icons'>delete</i>
                            </div>
                        )
                    })}
                </div>

            </DialogContainer>
        )
    }
}

const mapStateToProps = (state) => ({
    width: state.events.width,
    vendorService: state.services.vendorService
})

const mapDispatchToProps = {
    uploadVendorServiceImages
}

export default connect(mapStateToProps, mapDispatchToProps)(SelectedImageModal)