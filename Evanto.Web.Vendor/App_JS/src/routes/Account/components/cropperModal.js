import React, { Component } from 'react'
import { Modal } from '../../../components/UIComponents'
import Cropper from 'react-cropper'
import 'cropperjs/dist/cropper.css'

class CropperModal extends Component {

    _crop = () => {
        crop(this.refs.cropper.getCroppedCanves().toDataURL())
    }
    render() {
        const { show, crop, hide } = this.props
        return (
            <Modal
                confirmText='Dəyiş'
                cancelText='Ləğv et'
                header='Cropper'
                confirm={() => {
                    hide()
                }}
                cancel={hide}
                show={show}>
                <div style={{margin: '0 auto'}}>
                    <Cropper
                        ref='cropper'
                        src='https://avatars1.githubusercontent.com/u/14249924?v=3&s=460'
                        // Cropper.js options
                        aspectRatio={16 / 16}
                        minContainerWidth={565}
                        minContainerHeight={400}
                        guides={true}
                        crop={crop} />
                </div>
            </Modal>
        )
    }
}

export default CropperModal