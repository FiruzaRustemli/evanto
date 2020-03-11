import React from 'react'
import { Field, reduxForm } from 'redux-form'
import TextField from 'react-md/lib/TextFields'
import Button from 'react-md/lib/Buttons/Button'
import { Card, CardTitle, CardText, CardActions } from 'react-md/lib/Cards'
import FontIcon from 'react-md/lib/FontIcons'
import DialogContainer from 'react-md/lib/Dialogs'
import { getBase64 } from '../../../helpers'
import SelectedImageModal from './selectedImageModal'
import AccessibleFakeButton from 'react-md/lib/Helpers/AccessibleFakeButton';
import Portal from 'react-md/lib/Helpers/Portal';

const validate = values => {
    const errors = {}
    const requiredFields = ['PriceMin', 'PriceMax']
    requiredFields.forEach(field => {
        if (!values[field]) {
            errors[field] = values['##required']
        }
    })
    return errors
}

const renderTextField = ({ input, label, meta: { touched, error }, ...custom }) => (
    <TextField label={label}
        error={touched && error}
        errorText={touched && error}
        {...input}
        {...custom}
    />
)

const editServiceForm = props => {
    const { handleSubmit, imageViewerIsOpen, deleteVendorServiceImage, width, imageViewerActiveIndex, closeImageViewer, openImageViewer, images, pristine, imageModal, reset, submitting, removeSelectedImage, editClicked, cancel, hideImageModal, openImageModal, modalImages } = props
    return (
        <form className='md-cell md-cell--12' onSubmit={handleSubmit}>
            <div className='md-grid'>

                {images && imageViewerIsOpen &&
                    <DialogContainer
                        id="speed-boost"
                        visible={imageViewerIsOpen}
                        className={`${width > 1090 ? 'dialog-request ' : ''}`}
                        onHide={() => closeImageViewer()}
                        aria-describedby="speed-boost-description"
                        modal
                        actions={[<Button flat onClick={closeImageViewer} label='Ləğv edin' />]}
                    >
                        <img className='image-in-dialog'
                            src={`${imageViewerActiveIndex}`} />
                    </DialogContainer>
                }
                <Card className='md-cell md-cell--6-desktop md-cell--12-tablet md-cell--12-phone'>
                    <CardTitle title={props['##serviceInformationUpdateCardTitle']} />
                    <CardText>
                        <Field id='tbxDescription' name='Description' label={props['##description']} component={renderTextField} />
                        <Field id='tbxPriceMin' name='PriceMin' type='number' label={props['##priceMin']} component={renderTextField} /><br />
                        <Field id='tbxPriceMax' name='PriceMax' type='number' label={props['##priceMax']} component={renderTextField} /><br />
                        <Field id='tbxName' name='Name' label={props['##name']} component={renderTextField} />
                        <Field id='tbxContact' name='ContactInfo' label={props['##contactInfo']} component={renderTextField} />
                        <Field id='tbxAddress' name='AddressText' label={props['##addressText']} component={renderTextField} />
                        <Field id='tbxCoordinateX' name='CoordinateX' label={props['##coordinateX']} component={renderTextField} />
                        <Field id='tbxCoordinateY' name='CoordinateY' label={props['##coordinateY']} component={renderTextField} />
                    </CardText>
                    <CardActions>
                        <Button
                            flat
                            label={props['##update']}
                            primary={true}
                            onTouchTap={handleSubmit}
                        />
                        <Button
                            flat
                            label={props['##cancel']}
                            primary={true}
                            onTouchTap={() => {
                                cancel()
                            }}
                        />
                    </CardActions>
                </Card>
                <Card className='md-cell md-cell--6-desktop md-cell--12-tablet md-cell--12-phone'>
                    <CardTitle title={props['##serviceImagesUpdateCardTitle']} />
                    <CardText className='md-grid images-card-text'>
                        <div className='md-cell md-cell--2 image-upload-div'>
                            <label htmlFor='flUp' className='md-inline-block md-btn md-btn--icon md-btn--floating md-background--secondary md-background--secondary-hover md-pointer--hover md-btn--hover' >
                                <div className="md-ink-container"><span aria-hidden="true"></span></div>
                                <i className="md-icon material-icons">add</i>
                            </label>
                            <input multiple id='flUp' onClick={(e) => {
                                e.target.value = null
                            }} onChange={(e) => {
                                var strArray = []
                                const asyncLoop = (i, files, cb) => {
                                    console.log('file', files[i])
                                    getBase64(files[i])
                                        .then(b64s => {
                                            strArray.push({
                                                container: b64s,
                                                imageKey: i,
                                                mediaType: files[i].type,
                                                extension: /^.+\.([^.]+)$/.exec(files[i].name)[1]
                                            })
                                            if (i < files.length - 1) {
                                                asyncLoop(++i, files, cb)
                                            } else {
                                                cb()
                                            }
                                        })
                                }
                                asyncLoop(0, e.target.files, () => {
                                    openImageModal(strArray)
                                })
                            }} type='file' style={{ display: 'none' }} />
                        </div>
                        {images && images.length > 0
                            && images.map((item, key) => {
                                return (
                                    <div key={key} onClick={() => openImageViewer(`data:image/jpeg;charset=utf-8;base64, ${item.container}`)} style={{ backgroundImage: `url('${`data:image/jpeg;charset=utf-8;base64, ${item.container}`}')` }} className='image-removable md-cell md-cell--2'>
                                        <i onClick={(e) => {
                                            e.stopPropagation()
                                            deleteVendorServiceImage({ id: item.id })

                                        }} className='material-icons'>delete</i>
                                    </div>
                                )
                            })
                        }
                    </CardText>
                </Card>
                {modalImages
                    && modalImages.length > 0
                    && <SelectedImageModal
                        removeSelectedImage={removeSelectedImage}
                        modalImages={modalImages}
                        hideImageModal={hideImageModal}
                        imageModal={imageModal} />
                }
            </div>
        </form>
    )
}

export default reduxForm({
    form: 'editServiceForm',
    validate,
    destroyOnUnmount: true,
    enableReinitialize: true
})(editServiceForm)